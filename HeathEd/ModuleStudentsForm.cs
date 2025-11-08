using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class ModuleStudentsForm : Form
    {
        private int moduleId;
        private string moduleName;

        public ModuleStudentsForm(int moduleId, string moduleName)
        {
            InitializeComponent();
            this.moduleId = moduleId;
            this.moduleName = moduleName;
        }

        private void ModuleStudentsForm_Load(object sender, EventArgs e)
        {
            lblModuleName.Text = $"Lớp: {moduleName}";
            LoadStudents();
            LoadAvailableStudents();
        }

        private void LoadStudents()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT u.UserID, u.Username, u.FullName, u.Email, sm.EnrolledDate
                        FROM Users u
                        INNER JOIN StudentModules sm ON u.UserID = sm.StudentID
                        WHERE sm.ModuleID = @ModuleID
                        ORDER BY u.FullName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ModuleID", moduleId);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvStudents.DataSource = dt;

                        if (dgvStudents.Columns["UserID"] != null)
                            dgvStudents.Columns["UserID"].Visible = false;

                        if (dgvStudents.Columns["Username"] != null)
                            dgvStudents.Columns["Username"].HeaderText = "Tên đăng nhập";

                        if (dgvStudents.Columns["FullName"] != null)
                            dgvStudents.Columns["FullName"].HeaderText = "Họ tên";

                        if (dgvStudents.Columns["Email"] != null)
                            dgvStudents.Columns["Email"].HeaderText = "Email";

                        if (dgvStudents.Columns["EnrolledDate"] != null)
                            dgvStudents.Columns["EnrolledDate"].HeaderText = "Ngày ghi danh";

                        // Cập nhật label đếm số lượng
                        lblStudentCount.Text = $"Tổng số: {dt.Rows.Count} sinh viên";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sinh viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAvailableStudents()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT UserID, Username, FullName, Email
                        FROM Users
                        WHERE Role = 'Student'
                        AND UserID NOT IN (
                            SELECT StudentID FROM StudentModules WHERE ModuleID = @ModuleID
                        )
                        ORDER BY FullName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ModuleID", moduleId);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cboAvailableStudents.DataSource = dt;
                        cboAvailableStudents.DisplayMember = "FullName";
                        cboAvailableStudents.ValueMember = "UserID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sinh viên khả dụng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (cboAvailableStudents.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int studentId = Convert.ToInt32(cboAvailableStudents.SelectedValue);

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO StudentModules (StudentID, ModuleID, EnrolledDate)
                        VALUES (@StudentID, @ModuleID, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", studentId);
                        cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thêm sinh viên vào lớp thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadStudents();
                        LoadAvailableStudents();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sinh viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên này khỏi lớp?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int studentId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["UserID"].Value);

                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM StudentModules WHERE StudentID = @StudentID AND ModuleID = @ModuleID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", studentId);
                            cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Xóa sinh viên khỏi lớp thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadStudents();
                            LoadAvailableStudents();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sinh viên: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblStudentCount_Click(object sender, EventArgs e)
        {

        }

        private void cboAvailableStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
