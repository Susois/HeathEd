using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class LecturerDashboardForm : Form
    {
        public LecturerDashboardForm()
        {
            InitializeComponent();
        }

        private void LecturerDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Chào mừng trở lại, {UserSession.FullName}!";
            LoadStatistics();
            LoadRecentModules();
            LoadRecentCases();
        }

        private void LoadStatistics()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Đếm số lớp học
                    string moduleQuery = "SELECT COUNT(*) FROM Modules WHERE LecturerID = @LecturerID AND IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(moduleQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);
                        int moduleCount = (int)cmd.ExecuteScalar();
                        lblModuleCount.Text = moduleCount.ToString();
                    }

                    // Đếm số sinh viên
                    string studentQuery = @"
                        SELECT COUNT(DISTINCT sm.StudentID)
                        FROM StudentModules sm
                        INNER JOIN Modules m ON sm.ModuleID = m.ModuleID
                        WHERE m.LecturerID = @LecturerID";
                    using (SqlCommand cmd = new SqlCommand(studentQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);
                        int studentCount = (int)cmd.ExecuteScalar();
                        lblStudentCount.Text = studentCount.ToString();
                    }

                    // Đếm số ca bệnh
                    string caseQuery = @"
                        SELECT COUNT(*)
                        FROM CaseStudies cs
                        INNER JOIN Modules m ON cs.ModuleID = m.ModuleID
                        WHERE m.LecturerID = @LecturerID AND cs.IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(caseQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);
                        int caseCount = (int)cmd.ExecuteScalar();
                        lblCaseCount.Text = caseCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thống kê: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentModules()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP 5 m.ModuleCode, m.ModuleName,
                               (SELECT COUNT(*) FROM StudentModules WHERE ModuleID = m.ModuleID) AS StudentCount,
                               m.CreatedDate
                        FROM Modules m
                        WHERE m.LecturerID = @LecturerID AND m.IsActive = 1
                        ORDER BY m.CreatedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvRecentModules.DataSource = dt;

                        if (dgvRecentModules.Columns["ModuleCode"] != null)
                            dgvRecentModules.Columns["ModuleCode"].HeaderText = "Mã lớp";

                        if (dgvRecentModules.Columns["ModuleName"] != null)
                            dgvRecentModules.Columns["ModuleName"].HeaderText = "Tên lớp";

                        if (dgvRecentModules.Columns["StudentCount"] != null)
                            dgvRecentModules.Columns["StudentCount"].HeaderText = "SL Sinh viên";

                        if (dgvRecentModules.Columns["CreatedDate"] != null)
                            dgvRecentModules.Columns["CreatedDate"].HeaderText = "Ngày tạo";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lớp học gần đây: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentCases()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP 5 cs.CaseTitle, m.ModuleName, cs.CreatedDate
                        FROM CaseStudies cs
                        INNER JOIN Modules m ON cs.ModuleID = m.ModuleID
                        WHERE m.LecturerID = @LecturerID AND cs.IsActive = 1
                        ORDER BY cs.CreatedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvRecentCases.DataSource = dt;

                        if (dgvRecentCases.Columns["CaseTitle"] != null)
                            dgvRecentCases.Columns["CaseTitle"].HeaderText = "Tiêu đề ca bệnh";

                        if (dgvRecentCases.Columns["ModuleName"] != null)
                            dgvRecentCases.Columns["ModuleName"].HeaderText = "Lớp học";

                        if (dgvRecentCases.Columns["CreatedDate"] != null)
                            dgvRecentCases.Columns["CreatedDate"].HeaderText = "Ngày tạo";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải ca bệnh gần đây: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
