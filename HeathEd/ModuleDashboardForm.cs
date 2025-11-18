using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HeathEd
{
    public partial class ModuleDashboardForm : Form
    {
        private int moduleId;
        private string moduleName;

        public ModuleDashboardForm(int moduleId, string moduleName)
        {
            InitializeComponent();
            this.moduleId = moduleId;
            this.moduleName = moduleName;
        }

        private void ModuleDashboardForm_Load(object sender, EventArgs e)
        {
            lblModuleName.Text = $"Dashboard - {moduleName}";
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Load statistics
                    LoadStatistics(conn);

                    // Load student list with progress
                    LoadStudentProgress(conn);

                    // Load charts
                    LoadCompletionChart(conn);
                    LoadAccuracyChart(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics(SqlConnection conn)
        {
            // Total students
            string studentQuery = "SELECT COUNT(*) FROM StudentModules WHERE ModuleID = @ModuleID";
            using (SqlCommand cmd = new SqlCommand(studentQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                int totalStudents = (int)cmd.ExecuteScalar();
                lblTotalStudents.Text = totalStudents.ToString();
            }

            // Students who completed at least one assignment
            string activeQuery = @"
                SELECT COUNT(DISTINCT sda.StudentID)
                FROM StudentDiagnosisAttempts sda
                INNER JOIN CaseStudies cs ON sda.CaseID = cs.CaseID
                WHERE cs.ModuleID = @ModuleID AND sda.IsCompleted = 1";
            using (SqlCommand cmd = new SqlCommand(activeQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                int activeStudents = (int)cmd.ExecuteScalar();
                lblActiveStudents.Text = activeStudents.ToString();
            }

            // Students who haven't started
            string noAttemptQuery = @"
                SELECT COUNT(DISTINCT sm.StudentID)
                FROM StudentModules sm
                WHERE sm.ModuleID = @ModuleID
                AND sm.StudentID NOT IN (
                    SELECT DISTINCT sda.StudentID
                    FROM StudentDiagnosisAttempts sda
                    INNER JOIN CaseStudies cs ON sda.CaseID = cs.CaseID
                    WHERE cs.ModuleID = @ModuleID
                )";
            using (SqlCommand cmd = new SqlCommand(noAttemptQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                int noAttempt = (int)cmd.ExecuteScalar();
                lblNoAttempt.Text = noAttempt.ToString();
            }

            // Completion rate
            string completionQuery = @"
                SELECT
                    COUNT(*) as Total,
                    SUM(CASE WHEN IsCompleted = 1 THEN 1 ELSE 0 END) as Completed
                FROM StudentDiagnosisAttempts sda
                INNER JOIN CaseStudies cs ON sda.CaseID = cs.CaseID
                WHERE cs.ModuleID = @ModuleID";
            using (SqlCommand cmd = new SqlCommand(completionQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int total = reader.GetInt32(0);
                        int completed = reader.GetInt32(1);

                        if (total > 0)
                        {
                            decimal rate = (decimal)completed / total * 100;
                            lblCompletionRate.Text = $"{rate:F1}%";
                            progressCompletion.Value = (int)Math.Min(rate, 100);
                        }
                        else
                        {
                            lblCompletionRate.Text = "0%";
                            progressCompletion.Value = 0;
                        }
                    }
                }
            }

            // Accuracy rate
            string accuracyQuery = @"
                SELECT
                    COUNT(*) as Total,
                    SUM(CASE WHEN sds.IsCorrect = 1 THEN 1 ELSE 0 END) as Correct
                FROM StudentDiagnosisAttempts sda
                INNER JOIN StudentDiagnosisSubmissions sds ON sda.AttemptID = sds.AttemptID
                INNER JOIN CaseStudies cs ON sda.CaseID = cs.CaseID
                WHERE cs.ModuleID = @ModuleID AND sda.IsCompleted = 1";
            using (SqlCommand cmd = new SqlCommand(accuracyQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int total = reader.GetInt32(0);
                        int correct = reader.GetInt32(1);

                        if (total > 0)
                        {
                            decimal rate = (decimal)correct / total * 100;
                            lblAccuracyRate.Text = $"{rate:F1}%";
                            progressAccuracy.Value = (int)Math.Min(rate, 100);
                        }
                        else
                        {
                            lblAccuracyRate.Text = "Chưa có dữ liệu";
                            progressAccuracy.Value = 0;
                        }
                    }
                }
            }

            // Average score
            string avgScoreQuery = @"
                SELECT AVG(Score)
                FROM StudentDiagnosisAttempts sda
                INNER JOIN CaseStudies cs ON sda.CaseID = cs.CaseID
                WHERE cs.ModuleID = @ModuleID AND sda.IsCompleted = 1 AND sda.Score IS NOT NULL";
            using (SqlCommand cmd = new SqlCommand(avgScoreQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    decimal avgScore = Convert.ToDecimal(result);
                    lblAvgScore.Text = $"{avgScore:F2}";
                }
                else
                {
                    lblAvgScore.Text = "0.00";
                }
            }
        }

        private void LoadStudentProgress(SqlConnection conn)
        {
            string query = @"
                SELECT
                    u.FullName,
                    COUNT(DISTINCT sda.AttemptID) as TotalAttempts,
                    SUM(CASE WHEN sda.IsCompleted = 1 THEN 1 ELSE 0 END) as CompletedAttempts,
                    AVG(CASE WHEN sda.IsCompleted = 1 AND sda.Score IS NOT NULL THEN sda.Score ELSE NULL END) as AvgScore,
                    SUM(CASE WHEN sds.IsCorrect = 1 THEN 1 ELSE 0 END) as CorrectCount,
                    COUNT(DISTINCT CASE WHEN sda.IsCompleted = 1 THEN sda.AttemptID END) as CompletedCount
                FROM StudentModules sm
                INNER JOIN Users u ON sm.StudentID = u.UserID
                LEFT JOIN StudentDiagnosisAttempts sda ON sm.StudentID = sda.StudentID
                    AND sda.CaseID IN (SELECT CaseID FROM CaseStudies WHERE ModuleID = @ModuleID)
                LEFT JOIN StudentDiagnosisSubmissions sds ON sda.AttemptID = sds.AttemptID
                WHERE sm.ModuleID = @ModuleID
                GROUP BY u.FullName
                ORDER BY u.FullName";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ModuleID", moduleId);

                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                // Add display columns
                dt.Columns.Add("ScoreDisplay", typeof(string));
                dt.Columns.Add("AccuracyDisplay", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    // Score display
                    if (row["AvgScore"] != DBNull.Value)
                    {
                        row["ScoreDisplay"] = $"{Convert.ToDecimal(row["AvgScore"]):F2}";
                    }
                    else
                    {
                        row["ScoreDisplay"] = "-";
                    }

                    // Accuracy display
                    int completed = Convert.ToInt32(row["CompletedCount"]);
                    int correct = Convert.ToInt32(row["CorrectCount"]);
                    if (completed > 0)
                    {
                        decimal accuracy = (decimal)correct / completed * 100;
                        row["AccuracyDisplay"] = $"{accuracy:F1}%";
                    }
                    else
                    {
                        row["AccuracyDisplay"] = "-";
                    }
                }

                dgvStudentProgress.DataSource = dt;

                // Format DataGridView
                if (dgvStudentProgress.Columns.Count > 0)
                {
                    dgvStudentProgress.Columns["FullName"].HeaderText = "Tên sinh viên";
                    dgvStudentProgress.Columns["TotalAttempts"].HeaderText = "Tổng lần làm";
                    dgvStudentProgress.Columns["CompletedAttempts"].HeaderText = "Đã hoàn thành";
                    dgvStudentProgress.Columns["ScoreDisplay"].HeaderText = "Điểm TB";
                    dgvStudentProgress.Columns["AccuracyDisplay"].HeaderText = "Tỉ lệ đúng";

                    // Hide unnecessary columns
                    dgvStudentProgress.Columns["AvgScore"].Visible = false;
                    dgvStudentProgress.Columns["CorrectCount"].Visible = false;
                    dgvStudentProgress.Columns["CompletedCount"].Visible = false;

                    // Auto size columns
                    dgvStudentProgress.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvStudentProgress.Columns["TotalAttempts"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvStudentProgress.Columns["CompletedAttempts"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvStudentProgress.Columns["ScoreDisplay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvStudentProgress.Columns["AccuracyDisplay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void LoadCompletionChart(SqlConnection conn)
        {
            // Giữ nguyên ChartArea từ Designer
            chartCompletion.Series.Clear();
            chartCompletion.Titles.Clear();
            chartCompletion.Titles.Add("Tỉ lệ sinh viên làm bài");

            // Dùng Legend2 có sẵn trong Designer
            chartCompletion.Legends["Legend2"].Enabled = true;
            chartCompletion.Legends["Legend2"].Docking = Docking.Bottom;
            chartCompletion.Legends["Legend2"].Alignment = StringAlignment.Center;

            Series series = new Series("Sinh viên");
            series.ChartType = SeriesChartType.Pie;
            series.Legend = "Legend2"; // <-- GÁN CHÍNH XÁC LEGEND

            string query = @"
        SELECT
            SUM(CASE WHEN AttemptCount > 0 THEN 1 ELSE 0 END) as Active,
            SUM(CASE WHEN AttemptCount = 0 THEN 1 ELSE 0 END) as Inactive
        FROM (
            SELECT
                sm.StudentID,
                COUNT(sda.AttemptID) as AttemptCount
            FROM StudentModules sm
            LEFT JOIN StudentDiagnosisAttempts sda ON sm.StudentID = sda.StudentID
                AND sda.CaseID IN (SELECT CaseID FROM CaseStudies WHERE ModuleID = @ModuleID)
            WHERE sm.ModuleID = @ModuleID
            GROUP BY sm.StudentID
        ) subquery";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int active = reader.GetInt32(0);
                        int inactive = reader.GetInt32(1);

                        series.Points.AddXY("Đã làm bài", active);
                        series.Points.AddXY("Chưa làm bài", inactive);

                        series.Points[0].Color = Color.SeaGreen;
                        series.Points[1].Color = Color.IndianRed;
                    }
                }
            }

            chartCompletion.Series.Add(series);
        }
        private void LoadAccuracyChart(SqlConnection conn)
        {
            chartAccuracy.Series.Clear();
            chartAccuracy.Titles.Clear();
            chartAccuracy.Titles.Add("Tỉ lệ đoán đúng/sai");

            // Dùng Legend1 có sẵn trong Designer
            chartAccuracy.Legends["Legend1"].Enabled = true;
            chartAccuracy.Legends["Legend1"].Docking = Docking.Bottom;
            chartAccuracy.Legends["Legend1"].Alignment = StringAlignment.Center;

            Series series = new Series("Kết quả");
            series.ChartType = SeriesChartType.Pie;
            series.Legend = "Legend1"; // <-- GÁN ĐÚNG LEGEND

            string query = @"
        SELECT
            SUM(CASE WHEN sds.IsCorrect = 1 THEN 1 ELSE 0 END) as Correct,
            SUM(CASE WHEN sds.IsCorrect = 0 THEN 1 ELSE 0 END) as Incorrect
        FROM StudentDiagnosisAttempts sda
        INNER JOIN StudentDiagnosisSubmissions sds ON sda.AttemptID = sds.AttemptID
        INNER JOIN CaseStudies cs ON sda.CaseID = cs.CaseID
        WHERE cs.ModuleID = @ModuleID AND sda.IsCompleted = 1";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int correct = reader.GetInt32(0);
                        int incorrect = reader.GetInt32(1);

                        if (correct > 0 || incorrect > 0)
                        {
                            series.Points.AddXY("Đúng", correct);
                            series.Points.AddXY("Sai", incorrect);

                            series.Points[0].Color = Color.DodgerBlue;
                            series.Points[1].Color = Color.Coral;
                        }
                        else
                        {
                            series.Points.AddXY("Chưa có dữ liệu", 1);
                            series.Points[0].Color = Color.Gray;
                        }
                    }
                }
            }

            chartAccuracy.Series.Add(series);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressCompletion_Click(object sender, EventArgs e)
        {

        }

        private void chartAccuracy_Click(object sender, EventArgs e)
        {

        }
    }
}

