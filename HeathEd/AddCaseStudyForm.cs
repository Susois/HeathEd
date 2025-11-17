using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HeathEd
{
    public partial class AddCaseStudyForm : Form
    {
        private int newCaseId = 0;
        private List<ExaminationResultEntry> examinationResults = new List<ExaminationResultEntry>();

        public AddCaseStudyForm()
        {
            InitializeComponent();
        }

        private void AddCaseStudyForm_Load(object sender, EventArgs e)
        {
            LoadModules();
            LoadExaminationTypes();
            chkIsActive.Checked = true;
            chkIsInteractive.Checked = true;
            cboDifficultyLevel.SelectedIndex = 1; // Medium
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

        private void LoadExaminationTypes()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT ExaminationTypeID, ExaminationCode, ExaminationName
                        FROM ExaminationTypes
                        WHERE IsActive = 1
                        ORDER BY ExaminationCode";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cboExamType.DataSource = dt;
                        cboExamType.DisplayMember = "ExaminationName";
                        cboExamType.ValueMember = "ExaminationTypeID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách xét nghiệm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddExamResult_Click(object sender, EventArgs e)
        {
            if (cboExamType.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại xét nghiệm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtResultData.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu kết quả xét nghiệm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int examTypeId = Convert.ToInt32(cboExamType.SelectedValue);
            string examName = cboExamType.Text;

            // Kiểm tra xem đã thêm xét nghiệm này chưa
            if (examinationResults.Exists(x => x.ExaminationTypeID == examTypeId))
            {
                MessageBox.Show("Xét nghiệm này đã được thêm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExaminationResultEntry entry = new ExaminationResultEntry
            {
                ExaminationTypeID = examTypeId,
                ExaminationName = examName,
                ResultData = txtResultData.Text.Trim(),
                NormalRange = txtNormalRange.Text.Trim(),
                Interpretation = txtInterpretation.Text.Trim()
            };

            examinationResults.Add(entry);
            lstExamResults.Items.Add($"{examName}: {txtResultData.Text.Trim()}");

            // Clear fields
            txtResultData.Clear();
            txtNormalRange.Clear();
            txtInterpretation.Clear();

            MessageBox.Show("Đã thêm kết quả xét nghiệm!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemoveExamResult_Click(object sender, EventArgs e)
        {
            if (lstExamResults.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn xét nghiệm cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = lstExamResults.SelectedIndex;
            examinationResults.RemoveAt(index);
            lstExamResults.Items.RemoveAt(index);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input
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

            if (string.IsNullOrWhiteSpace(txtSymptoms.Text))
            {
                MessageBox.Show("Vui lòng nhập triệu chứng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSymptoms.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Vui lòng nhập chẩn đoán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagnosis.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Insert CaseStudies
                            string insertCase = @"
                                INSERT INTO CaseStudies (CaseTitle, Description, Symptoms, Diagnosis, ModuleID,
                                    IsActive, IsInteractive, DifficultyLevel, PatientAge, PatientGender, PatientHistory, CreatedDate)
                                VALUES (@CaseTitle, @Description, @Symptoms, @Diagnosis, @ModuleID,
                                    @IsActive, @IsInteractive, @DifficultyLevel, @PatientAge, @PatientGender, @PatientHistory, GETDATE());
                                SELECT SCOPE_IDENTITY();";

                            using (SqlCommand cmd = new SqlCommand(insertCase, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@CaseTitle", txtCaseTitle.Text.Trim());
                                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                                cmd.Parameters.AddWithValue("@Symptoms", txtSymptoms.Text.Trim());
                                cmd.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text.Trim());
                                cmd.Parameters.AddWithValue("@ModuleID", cboModule.SelectedValue);
                                cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                                cmd.Parameters.AddWithValue("@IsInteractive", chkIsInteractive.Checked);
                                cmd.Parameters.AddWithValue("@DifficultyLevel", cboDifficultyLevel.Text);
                                cmd.Parameters.AddWithValue("@PatientAge", string.IsNullOrEmpty(txtPatientAge.Text) ? (object)DBNull.Value : Convert.ToInt32(txtPatientAge.Text));
                                cmd.Parameters.AddWithValue("@PatientGender", cboPatientGender.Text);
                                cmd.Parameters.AddWithValue("@PatientHistory", txtPatientHistory.Text.Trim());

                                newCaseId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // 2. Insert CaseExaminationResults
                            foreach (var examResult in examinationResults)
                            {
                                string insertExamResult = @"
                                    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
                                    VALUES (@CaseID, @ExaminationTypeID, @ResultData, @NormalRange, @Interpretation)";

                                using (SqlCommand cmd = new SqlCommand(insertExamResult, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CaseID", newCaseId);
                                    cmd.Parameters.AddWithValue("@ExaminationTypeID", examResult.ExaminationTypeID);
                                    cmd.Parameters.AddWithValue("@ResultData", examResult.ResultData);
                                    cmd.Parameters.AddWithValue("@NormalRange", string.IsNullOrEmpty(examResult.NormalRange) ? (object)DBNull.Value : examResult.NormalRange);
                                    cmd.Parameters.AddWithValue("@Interpretation", string.IsNullOrEmpty(examResult.Interpretation) ? (object)DBNull.Value : examResult.Interpretation);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            MessageBox.Show($"Thêm ca bệnh thành công!\nĐã thêm {examinationResults.Count} kết quả xét nghiệm.", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm ca bệnh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Helper class để lưu thông tin xét nghiệm
        private class ExaminationResultEntry
        {
            public int ExaminationTypeID { get; set; }
            public string ExaminationName { get; set; }
            public string ResultData { get; set; }
            public string NormalRange { get; set; }
            public string Interpretation { get; set; }
        }
    }
}
