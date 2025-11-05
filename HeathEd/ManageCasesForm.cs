using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class ManageCasesForm : Form
    {
        private int selectedCaseId = 0;

        public ManageCasesForm()
        {
            InitializeComponent();
        }

        private void ManageCasesForm_Load(object sender, EventArgs e)
        {
            LoadModules();
            LoadCases();
        }

        private void LoadModules()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT ModuleID, ModuleName
                        FROM Modules
                        WHERE LecturerID = @LecturerID AND IsActive = 1
                        ORDER BY ModuleName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cboModule.DataSource = dt;
                        cboModule.DisplayMember = "ModuleName";
                        cboModule.ValueMember = "ModuleID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách lớp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCases(string searchKeyword = "")
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT c.CaseID, c.CaseTitle, c.Description, c.Symptoms, c.Diagnosis,
                               m.ModuleName, c.IsActive, c.CreatedDate
                        FROM CaseStudies c
                        INNER JOIN Modules m ON c.ModuleID = m.ModuleID
                        WHERE m.LecturerID = @LecturerID";

                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        query += " AND (c.CaseTitle LIKE @Search OR c.Description LIKE @Search)";
                    }

                    query += " ORDER BY c.CreatedDate DESC";

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

                        dgvCases.DataSource = dt;

                        if (dgvCases.Columns["CaseID"] != null)
                            dgvCases.Columns["CaseID"].Visible = false;

                        if (dgvCases.Columns["CaseTitle"] != null)
                            dgvCases.Columns["CaseTitle"].HeaderText = "Tiêu đề";

                        if (dgvCases.Columns["Description"] != null)
                            dgvCases.Columns["Description"].HeaderText = "Mô tả";

                        if (dgvCases.Columns["Symptoms"] != null)
                            dgvCases.Columns["Symptoms"].HeaderText = "Triệu chứng";

                        if (dgvCases.Columns["Diagnosis"] != null)
                            dgvCases.Columns["Diagnosis"].HeaderText = "Chẩn đoán";

                        if (dgvCases.Columns["ModuleName"] != null)
                            dgvCases.Columns["ModuleName"].HeaderText = "Lớp học";

                        if (dgvCases.Columns["IsActive"] != null)
                            dgvCases.Columns["IsActive"].HeaderText = "Hoạt động";

                        if (dgvCases.Columns["CreatedDate"] != null)
                            dgvCases.Columns["CreatedDate"].HeaderText = "Ngày tạo";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCases_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCases.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCases.SelectedRows[0];
                selectedCaseId = Convert.ToInt32(row.Cells["CaseID"].Value);
                txtCaseTitle.Text = row.Cells["CaseTitle"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
                txtSymptoms.Text = row.Cells["Symptoms"].Value?.ToString() ?? "";
                txtDiagnosis.Text = row.Cells["Diagnosis"].Value?.ToString() ?? "";
                chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);

                // Tìm và chọn Module tương ứng
                string moduleName = row.Cells["ModuleName"].Value.ToString();
                for (int i = 0; i < cboModule.Items.Count; i++)
                {
                    DataRowView drv = (DataRowView)cboModule.Items[i];
                    if (drv["ModuleName"].ToString() == moduleName)
                    {
                        cboModule.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCaseTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề ca bệnh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCaseTitle.Focus();
                return;
            }

            if (cboModule.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp học!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO CaseStudies (CaseTitle, Description, Symptoms, Diagnosis, ModuleID, IsActive, CreatedDate)
                        VALUES (@CaseTitle, @Description, @Symptoms, @Diagnosis, @ModuleID, @IsActive, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CaseTitle", txtCaseTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@Symptoms", txtSymptoms.Text.Trim());
                        cmd.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text.Trim());
                        cmd.Parameters.AddWithValue("@ModuleID", cboModule.SelectedValue);
                        cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thêm ca bệnh thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearForm();
                        LoadCases();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm ca bệnh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCaseId == 0)
            {
                MessageBox.Show("Vui lòng chọn ca bệnh cần cập nhật!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCaseTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề ca bệnh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCaseTitle.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE CaseStudies
                        SET CaseTitle = @CaseTitle,
                            Description = @Description,
                            Symptoms = @Symptoms,
                            Diagnosis = @Diagnosis,
                            ModuleID = @ModuleID,
                            IsActive = @IsActive
                        WHERE CaseID = @CaseID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CaseTitle", txtCaseTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@Symptoms", txtSymptoms.Text.Trim());
                        cmd.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text.Trim());
                        cmd.Parameters.AddWithValue("@ModuleID", cboModule.SelectedValue);
                        cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                        cmd.Parameters.AddWithValue("@CaseID", selectedCaseId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật ca bệnh thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearForm();
                            LoadCases();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật ca bệnh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCaseId == 0)
            {
                MessageBox.Show("Vui lòng chọn ca bệnh cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa ca bệnh này?",
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
                        string query = "DELETE FROM CaseStudies WHERE CaseID = @CaseID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CaseID", selectedCaseId);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Xóa ca bệnh thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearForm();
                            LoadCases();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa ca bệnh: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCases(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadCases();
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
            selectedCaseId = 0;
            txtCaseTitle.Clear();
            txtDescription.Clear();
            txtSymptoms.Clear();
            txtDiagnosis.Clear();
            chkIsActive.Checked = true;
            if (cboModule.Items.Count > 0)
                cboModule.SelectedIndex = 0;
            txtCaseTitle.Focus();
        }
    }
}
