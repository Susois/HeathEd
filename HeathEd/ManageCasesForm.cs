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
            // Mở form thêm ca bệnh mới với đầy đủ thông tin
            AddCaseStudyForm addForm = new AddCaseStudyForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh danh sách ca bệnh
                ClearForm();
                LoadCases();
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

            // Mở form cập nhật ca bệnh với dữ liệu có sẵn
            EditCaseStudyForm editForm = new EditCaseStudyForm(selectedCaseId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh danh sách ca bệnh
                ClearForm();
                LoadCases();
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
                "Bạn có chắc muốn xóa ca bệnh này?\n\nLƯU Ý: Tất cả dữ liệu liên quan (kết quả xét nghiệm, bài làm của sinh viên, hình ảnh...) sẽ bị xóa vĩnh viễn!",
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

                        // Sử dụng transaction để đảm bảo tính toàn vẹn dữ liệu
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // 1. Xóa StudentDiagnosisSubmissions (qua AttemptID)
                                string deleteSubmissions = @"
                                    DELETE FROM StudentDiagnosisSubmissions
                                    WHERE AttemptID IN (SELECT AttemptID FROM StudentDiagnosisAttempts WHERE CaseID = @CaseID)";
                                using (SqlCommand cmd = new SqlCommand(deleteSubmissions, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CaseID", selectedCaseId);
                                    cmd.ExecuteNonQuery();
                                }

                                // 2. Xóa StudentExaminationRequests (qua AttemptID)
                                string deleteExamRequests = @"
                                    DELETE FROM StudentExaminationRequests
                                    WHERE AttemptID IN (SELECT AttemptID FROM StudentDiagnosisAttempts WHERE CaseID = @CaseID)";
                                using (SqlCommand cmd = new SqlCommand(deleteExamRequests, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CaseID", selectedCaseId);
                                    cmd.ExecuteNonQuery();
                                }

                                // 3. Xóa StudentDiagnosisAttempts
                                string deleteAttempts = "DELETE FROM StudentDiagnosisAttempts WHERE CaseID = @CaseID";
                                using (SqlCommand cmd = new SqlCommand(deleteAttempts, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CaseID", selectedCaseId);
                                    cmd.ExecuteNonQuery();
                                }

                                // 4. Xóa CaseExaminationResults
                                string deleteExamResults = "DELETE FROM CaseExaminationResults WHERE CaseID = @CaseID";
                                using (SqlCommand cmd = new SqlCommand(deleteExamResults, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CaseID", selectedCaseId);
                                    cmd.ExecuteNonQuery();
                                }

                                // 5. Xóa CaseImages
                                string deleteImages = "DELETE FROM CaseImages WHERE CaseID = @CaseID";
                                using (SqlCommand cmd = new SqlCommand(deleteImages, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CaseID", selectedCaseId);
                                    cmd.ExecuteNonQuery();
                                }

                                // 6. Cuối cùng xóa CaseStudies
                                string deleteCase = "DELETE FROM CaseStudies WHERE CaseID = @CaseID";
                                using (SqlCommand cmd = new SqlCommand(deleteCase, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CaseID", selectedCaseId);
                                    cmd.ExecuteNonQuery();
                                }

                                // Commit transaction
                                transaction.Commit();

                                MessageBox.Show("Xóa ca bệnh thành công!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ClearForm();
                                LoadCases();
                            }
                            catch (Exception ex)
                            {
                                // Rollback nếu có lỗi
                                transaction.Rollback();
                                throw ex;
                            }
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

        private void lblDiagnosis_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
