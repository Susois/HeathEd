using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class ManageModulesForm : Form
    {
        private int selectedModuleId = 0;

        public ManageModulesForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            // Cấu hình kiểu dáng cho DataGridView
            dgvModules.EnableHeadersVisualStyles = false;
            dgvModules.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue;
            dgvModules.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvModules.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvModules.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvModules.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);

            dgvModules.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvModules.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvModules.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvModules.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);
            dgvModules.RowTemplate.Height = 35;
        }

        private void ManageModulesForm_Load(object sender, EventArgs e)
        {
            LoadModules();
        }

        private void LoadModules(string searchKeyword = "")
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT m.ModuleID, m.ModuleCode, m.ModuleName, m.Description,
                               u.FullName AS LecturerName, m.IsActive, m.CreatedDate,
                               (SELECT COUNT(*) FROM StudentModules WHERE ModuleID = m.ModuleID) AS StudentCount
                        FROM Modules m
                        INNER JOIN Users u ON m.LecturerID = u.UserID
                        WHERE m.LecturerID = @LecturerID";

                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        query += " AND (m.ModuleCode LIKE @Search OR m.ModuleName LIKE @Search)";
                    }

                    query += " ORDER BY m.CreatedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);

                        if (!string.IsNullOrEmpty(searchKeyword))
                        {
                            cmd.Parameters.AddWithValue("@Search", $"%{searchKeyword}%");
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvModules.DataSource = dt;

                        // Ẩn cột ModuleID
                        if (dgvModules.Columns["ModuleID"] != null)
                            dgvModules.Columns["ModuleID"].Visible = false;

                        if (dgvModules.Columns["LecturerName"] != null)
                            dgvModules.Columns["LecturerName"].Visible = false;

                        // Đổi tên và thiết lập độ rộng các cột
                        if (dgvModules.Columns["ModuleCode"] != null)
                        {
                            dgvModules.Columns["ModuleCode"].HeaderText = "Mã lớp";
                            dgvModules.Columns["ModuleCode"].Width = 100;
                        }

                        if (dgvModules.Columns["ModuleName"] != null)
                        {
                            dgvModules.Columns["ModuleName"].HeaderText = "Tên lớp";
                            dgvModules.Columns["ModuleName"].Width = 200;
                        }

                        if (dgvModules.Columns["Description"] != null)
                        {
                            dgvModules.Columns["Description"].HeaderText = "Mô tả";
                            dgvModules.Columns["Description"].Width = 150;
                        }

                        if (dgvModules.Columns["StudentCount"] != null)
                        {
                            dgvModules.Columns["StudentCount"].HeaderText = "SL SV";
                            dgvModules.Columns["StudentCount"].Width = 70;
                            dgvModules.Columns["StudentCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }

                        if (dgvModules.Columns["IsActive"] != null)
                        {
                            dgvModules.Columns["IsActive"].HeaderText = "Active";
                            dgvModules.Columns["IsActive"].Width = 70;
                        }

                        if (dgvModules.Columns["CreatedDate"] != null)
                            dgvModules.Columns["CreatedDate"].Visible = false;

                        // Cập nhật label đếm
                        lblCount.Text = $"Tổng số: {dt.Rows.Count} lớp học";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvModules_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvModules.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvModules.SelectedRows[0];
                selectedModuleId = Convert.ToInt32(row.Cells["ModuleID"].Value);
                txtModuleCode.Text = row.Cells["ModuleCode"].Value.ToString();
                txtModuleName.Text = row.Cells["ModuleName"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
                chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtModuleCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModuleCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtModuleName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModuleName.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra trùng mã lớp
                    string checkQuery = "SELECT COUNT(*) FROM Modules WHERE ModuleCode = @ModuleCode";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ModuleCode", txtModuleCode.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã lớp đã tồn tại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = @"
                        INSERT INTO Modules (ModuleCode, ModuleName, Description, LecturerID, IsActive, CreatedDate)
                        VALUES (@ModuleCode, @ModuleName, @Description, @LecturerID, @IsActive, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ModuleCode", txtModuleCode.Text.Trim());
                        cmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);
                        cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thêm lớp học thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearForm();
                        LoadModules();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm lớp học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedModuleId == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp học cần cập nhật!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtModuleCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModuleCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtModuleName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModuleName.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra trùng mã lớp (trừ chính nó)
                    string checkQuery = "SELECT COUNT(*) FROM Modules WHERE ModuleCode = @ModuleCode AND ModuleID != @ModuleID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ModuleCode", txtModuleCode.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@ModuleID", selectedModuleId);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã lớp đã tồn tại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = @"
                        UPDATE Modules
                        SET ModuleCode = @ModuleCode,
                            ModuleName = @ModuleName,
                            Description = @Description,
                            IsActive = @IsActive
                        WHERE ModuleID = @ModuleID AND LecturerID = @LecturerID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ModuleCode", txtModuleCode.Text.Trim());
                        cmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                        cmd.Parameters.AddWithValue("@ModuleID", selectedModuleId);
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật lớp học thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearForm();
                            LoadModules();
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật lớp học!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật lớp học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedModuleId == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp học cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa lớp học này?\nLưu ý: Tất cả dữ liệu liên quan sẽ bị xóa!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // Xóa các bản ghi liên quan trước
                                string deleteRelatedQuery = @"
                                    DELETE FROM StudentModules WHERE ModuleID = @ModuleID;
                                    DELETE FROM CaseStudies WHERE ModuleID = @ModuleID;";

                                using (SqlCommand cmd = new SqlCommand(deleteRelatedQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ModuleID", selectedModuleId);
                                    cmd.ExecuteNonQuery();
                                }

                                // Xóa lớp học
                                string deleteQuery = "DELETE FROM Modules WHERE ModuleID = @ModuleID AND LecturerID = @LecturerID";
                                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ModuleID", selectedModuleId);
                                    cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        transaction.Commit();
                                        MessageBox.Show("Xóa lớp học thành công!", "Thành công",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        ClearForm();
                                        LoadModules();
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Không thể xóa lớp học!", "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa lớp học: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadModules(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadModules();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            selectedModuleId = 0;
            txtModuleCode.Clear();
            txtModuleName.Clear();
            txtDescription.Clear();
            chkIsActive.Checked = true;
            txtModuleCode.Focus();
        }
    }
}
