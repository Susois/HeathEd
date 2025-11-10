using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HeathEd
{
    public partial class StudentDashboardForm : Form
    {
        public StudentDashboardForm()
        {
            InitializeComponent();
        }

        private void StudentDashboardForm_Load(object sender, EventArgs e)
        {
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

                    // Load attempt history
                    LoadAttemptHistory(conn);

                    // Load charts
                    LoadPerformanceChart(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu dashboard: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics(SqlConnection conn)
        {
            // Tổng số lớp học đã tham gia
            string queryModules = @"
                SELECT COUNT(*)
                FROM StudentModules
                WHERE StudentID = @StudentID";

            using (SqlCommand cmd = new SqlCommand(queryModules, conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", UserSession.UserId);
                int totalModules = Convert.ToInt32(cmd.ExecuteScalar());
                lblTotalModules.Text = totalModules.ToString();
            }

            // Tổng số lần làm bài
            string queryAttempts = @"
                SELECT COUNT(*)
                FROM StudentDiagnosisAttempts
                WHERE StudentID = @StudentID";

            using (SqlCommand cmd = new SqlCommand(queryAttempts, conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", UserSession.UserId);
                int totalAttempts = Convert.ToInt32(cmd.ExecuteScalar());
                lblTotalAttempts.Text = totalAttempts.ToString();
            }

            // Tỉ lệ hoàn thành bài tập
            string queryCompletion = @"
                SELECT
                    COUNT(*) as Total,
                    SUM(CASE WHEN IsCompleted = 1 THEN 1 ELSE 0 END) as Completed
                FROM StudentDiagnosisAttempts
                WHERE StudentID = @StudentID";

            using (SqlCommand cmd = new SqlCommand(queryCompletion, conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", UserSession.UserId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int total = reader.GetInt32(0);
                        int completed = reader.GetInt32(1);

                        if (total > 0)
                        {
                            decimal completionRate = (decimal)completed / total * 100;
                            lblCompletionRate.Text = $"{completionRate:F1}%";
                            progressCompletion.Value = (int)Math.Min(completionRate, 100);
                        }
                        else
                        {
                            lblCompletionRate.Text = "0%";
                            progressCompletion.Value = 0;
                        }
                    }
                }
            }

            // Tỉ lệ đoán đúng
            string queryAccuracy = @"
                SELECT
                    COUNT(*) as Total,
                    SUM(CASE WHEN sds.IsCorrect = 1 THEN 1 ELSE 0 END) as Correct
                FROM StudentDiagnosisAttempts sda
                INNER JOIN StudentDiagnosisSubmissions sds ON sda.AttemptID = sds.AttemptID
                WHERE sda.StudentID = @StudentID AND sda.IsCompleted = 1";

            using (SqlCommand cmd = new SqlCommand(queryAccuracy, conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", UserSession.UserId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int total = reader.GetInt32(0);
                        int correct = reader.GetInt32(1);

                        if (total > 0)
                        {
                            decimal accuracy = (decimal)correct / total * 100;
                            lblAccuracyRate.Text = $"{accuracy:F1}%";
                            progressAccuracy.Value = (int)Math.Min(accuracy, 100);
                        }
                        else
                        {
                            lblAccuracyRate.Text = "Chưa có dữ liệu";
                            progressAccuracy.Value = 0;
                        }
                    }
                }
            }

            // Điểm trung bình
            string queryAvgScore = @"
                SELECT AVG(Score)
                FROM StudentDiagnosisAttempts
                WHERE StudentID = @StudentID AND IsCompleted = 1 AND Score IS NOT NULL";

            using (SqlCommand cmd = new SqlCommand(queryAvgScore, conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", UserSession.UserId);
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

        private void LoadAttemptHistory(SqlConnection conn)
        {
            string query = @"
                SELECT
                    cs.CaseTitle,
                    m.ModuleName,
                    sda.AttemptDate,
                    sda.IsCompleted,
                    sda.Score,
                    CASE
                        WHEN sds.IsCorrect = 1 THEN N'Đúng'
                        WHEN sds.IsCorrect = 0 THEN N'Sai'
                        ELSE N'Chưa chấm'
                    END as DiagnosisResult,
                    sda.TimeSpent,
                    sda.TotalCost
                FROM StudentDiagnosisAttempts sda
                INNER JOIN CaseStudies cs ON sda.CaseID = cs.CaseID
                INNER JOIN Modules m ON cs.ModuleID = m.ModuleID
                LEFT JOIN StudentDiagnosisSubmissions sds ON sda.AttemptID = sds.AttemptID
                WHERE sda.StudentID = @StudentID
                ORDER BY sda.AttemptDate DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", UserSession.UserId);

                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                // Add display columns
                dt.Columns.Add("CompletionStatus", typeof(string));
                dt.Columns.Add("ScoreDisplay", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    bool isCompleted = Convert.ToBoolean(row["IsCompleted"]);
                    row["CompletionStatus"] = isCompleted ? "Hoàn thành" : "Chưa hoàn thành";

                    if (isCompleted && row["Score"] != DBNull.Value)
                    {
                        row["ScoreDisplay"] = $"{Convert.ToDecimal(row["Score"]):F2}";
                    }
                    else
                    {
                        row["ScoreDisplay"] = "-";
                    }
                }

                dgvAttemptHistory.DataSource = dt;

                // Format DataGridView
                if (dgvAttemptHistory.Columns.Count > 0)
                {
                    dgvAttemptHistory.Columns["CaseTitle"].HeaderText = "Tên ca bệnh";
                    dgvAttemptHistory.Columns["ModuleName"].HeaderText = "Học phần";
                    dgvAttemptHistory.Columns["AttemptDate"].HeaderText = "Ngày làm bài";
                    dgvAttemptHistory.Columns["CompletionStatus"].HeaderText = "Trạng thái";
                    dgvAttemptHistory.Columns["ScoreDisplay"].HeaderText = "Điểm";
                    dgvAttemptHistory.Columns["DiagnosisResult"].HeaderText = "Kết quả chẩn đoán";
                    dgvAttemptHistory.Columns["TimeSpent"].HeaderText = "Thời gian (phút)";
                    dgvAttemptHistory.Columns["TotalCost"].HeaderText = "Chi phí (VNĐ)";

                    // Hide unnecessary columns
                    dgvAttemptHistory.Columns["IsCompleted"].Visible = false;
                    dgvAttemptHistory.Columns["Score"].Visible = false;

                    // Auto size columns
                    dgvAttemptHistory.Columns["CaseTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvAttemptHistory.Columns["ModuleName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvAttemptHistory.Columns["AttemptDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvAttemptHistory.Columns["CompletionStatus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvAttemptHistory.Columns["ScoreDisplay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvAttemptHistory.Columns["DiagnosisResult"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvAttemptHistory.Columns["TimeSpent"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvAttemptHistory.Columns["TotalCost"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void LoadPerformanceChart(SqlConnection conn)
        {
            string query = @"
                SELECT
                    CONVERT(DATE, sda.AttemptDate) as AttemptDate,
                    AVG(CASE WHEN sda.Score IS NOT NULL THEN sda.Score ELSE 0 END) as AvgScore,
                    COUNT(*) as TotalAttempts
                FROM StudentDiagnosisAttempts sda
                WHERE sda.StudentID = @StudentID AND sda.IsCompleted = 1
                GROUP BY CONVERT(DATE, sda.AttemptDate)
                ORDER BY AttemptDate DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", UserSession.UserId);

                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                if (dt.Rows.Count > 0)
                {
                    chartPerformance.Series["Score"].Points.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime date = Convert.ToDateTime(row["AttemptDate"]);
                        decimal avgScore = Convert.ToDecimal(row["AvgScore"]);

                        var point = chartPerformance.Series["Score"].Points.AddXY(
                            date.ToString("dd/MM"), avgScore);
                    }

                    chartPerformance.ChartAreas[0].AxisY.Maximum = 100;
                    chartPerformance.ChartAreas[0].AxisY.Minimum = 0;
                    chartPerformance.ChartAreas[0].AxisY.Title = "Điểm";
                    chartPerformance.ChartAreas[0].AxisX.Title = "Ngày";
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressAccuracy_Click(object sender, EventArgs e)
        {

        }

        private void lblAccuracyRate_Click(object sender, EventArgs e)
        {

        }
    }
}
