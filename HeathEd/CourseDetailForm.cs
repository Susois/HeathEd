using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class CourseDetailForm : Form
    {
        private int moduleId;
        private string moduleName;

        public CourseDetailForm(int moduleId, string moduleName)
        {
            InitializeComponent();
            this.moduleId = moduleId;
            this.moduleName = moduleName;
        }

        private void CourseDetailForm_Load(object sender, EventArgs e)
        {
            lblModuleName.Text = moduleName;
            LoadModuleInfo();
            LoadCaseStudies();
        }

        private void LoadModuleInfo()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT m.ModuleCode, m.Description, u.FullName AS LecturerName, u.Email AS LecturerEmail
                        FROM Modules m
                        INNER JOIN Users u ON m.LecturerID = u.UserID
                        WHERE m.ModuleID = @ModuleID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ModuleID", moduleId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblModuleCode.Text = $"Mã lớp: {reader.GetString(0)}";
                                txtDescription.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                lblLecturer.Text = $"Giảng viên: {reader.GetString(2)}";
                                lblEmail.Text = $"Email: {reader.GetString(3)}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin lớp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCaseStudies()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT cs.CaseID, cs.CaseTitle, cs.Description, cs.Symptoms, cs.Diagnosis,
                               ISNULL(cs.IsInteractive, 0) AS IsInteractive,
                               ISNULL(cs.DifficultyLevel, 'Medium') AS DifficultyLevel,
                               CASE
                                   WHEN cs.IsInteractive = 1
                                        AND cs.Symptoms IS NOT NULL AND cs.Symptoms <> ''
                                        AND cs.Diagnosis IS NOT NULL AND cs.Diagnosis <> ''
                                        AND EXISTS (SELECT 1 FROM CaseExaminationResults cer WHERE cer.CaseID = cs.CaseID)
                                   THEN N'Có thể chẩn đoán'
                                   ELSE N'Chưa thể chẩn đoán'
                               END AS DiagnosisStatus
                        FROM CaseStudies cs
                        WHERE cs.ModuleID = @ModuleID AND cs.IsActive = 1
                        ORDER BY cs.CreatedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ModuleID", moduleId);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvCases.DataSource = dt;

                        if (dgvCases.Columns["CaseID"] != null)
                            dgvCases.Columns["CaseID"].Visible = false;

                        if (dgvCases.Columns["CaseTitle"] != null)
                            dgvCases.Columns["CaseTitle"].HeaderText = "Tiêu đề ca bệnh";

                        if (dgvCases.Columns["Description"] != null)
                            dgvCases.Columns["Description"].HeaderText = "Mô tả";

                        if (dgvCases.Columns["Symptoms"] != null)
                        {
                            dgvCases.Columns["Symptoms"].HeaderText = "Triệu chứng";
                            dgvCases.Columns["Symptoms"].Visible = false; // Ẩn cột này vì quá dài
                        }

                        if (dgvCases.Columns["Diagnosis"] != null)
                        {
                            dgvCases.Columns["Diagnosis"].Visible = false; // ẨN cột chẩn đoán
                        }

                        if (dgvCases.Columns["IsInteractive"] != null)
                            dgvCases.Columns["IsInteractive"].Visible = false;

                        if (dgvCases.Columns["DifficultyLevel"] != null)
                        {
                            dgvCases.Columns["DifficultyLevel"].HeaderText = "Độ khó";
                            dgvCases.Columns["DifficultyLevel"].Width = 80;
                        }

                        if (dgvCases.Columns["DiagnosisStatus"] != null)
                        {
                            dgvCases.Columns["DiagnosisStatus"].HeaderText = "Trạng thái";
                            dgvCases.Columns["DiagnosisStatus"].Width = 150;
                        }

                        lblCaseCount.Text = $"Tổng số: {dt.Rows.Count} ca bệnh";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách ca bệnh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCases_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCases.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCases.SelectedRows[0];

                // Check if IsInteractive column exists (database might not be updated yet)
                bool isInteractive = false;
                if (row.Cells["IsInteractive"] != null && row.Cells["IsInteractive"].Value != null)
                {
                    isInteractive = Convert.ToBoolean(row.Cells["IsInteractive"].Value);
                }

                txtCaseDetail.Clear();
                txtCaseDetail.AppendText($"TIÊU ĐỀ: {row.Cells["CaseTitle"].Value}\r\n\r\n");
                txtCaseDetail.AppendText($"MÔ TẢ:\r\n{row.Cells["Description"].Value}\r\n\r\n");
                txtCaseDetail.AppendText($"TRIỆU CHỨNG:\r\n{row.Cells["Symptoms"].Value}\r\n\r\n");

                // Ẩn chẩn đoán nếu là ca bệnh tương tác
                if (!isInteractive)
                {
                    txtCaseDetail.AppendText($"CHẨN ĐOÁN:\r\n{row.Cells["Diagnosis"].Value}");
                }
                else
                {
                    txtCaseDetail.AppendText($"CHẨN ĐOÁN:\r\n[Ẩn - Hãy thực hành chẩn đoán để xem kết quả]");
                }
            }
        }

        private void btnStartDiagnosis_Click(object sender, EventArgs e)
        {
            if (dgvCases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một ca bệnh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvCases.SelectedRows[0];
            int caseId = Convert.ToInt32(row.Cells["CaseID"].Value);
            bool isInteractive = Convert.ToBoolean(row.Cells["IsInteractive"].Value);
            string diagnosisStatus = row.Cells["DiagnosisStatus"].Value?.ToString() ?? "";

            if (!isInteractive)
            {
                MessageBox.Show("Ca bệnh này không hỗ trợ chế độ thực hành chẩn đoán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra xem ca bệnh có đầy đủ dữ liệu để chẩn đoán không
            if (diagnosisStatus != "Có thể chẩn đoán")
            {
                MessageBox.Show("Ca bệnh này chưa có đầy đủ dữ liệu để chẩn đoán!\n\n" +
                    "Cần có: Triệu chứng, Chẩn đoán và Kết quả xét nghiệm.", "Không thể chẩn đoán",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở form chẩn đoán tương tác
            PatientDiagnosisForm diagnosisForm = new PatientDiagnosisForm(caseId);
            diagnosisForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
