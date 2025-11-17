using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HeathEd
{
    public partial class EditCaseStudyForm : Form
    {
        private int caseId;
        private List<ExaminationResultEntry> examinationResults = new List<ExaminationResultEntry>();

        public EditCaseStudyForm(int caseId)
        {
            InitializeComponent();
            this.caseId = caseId;
        }

        private void EditCaseStudyForm_Load(object sender, EventArgs e)
        {
            LoadModules();
            LoadExaminationTypes();
            LoadCaseData();
            LoadExistingExamResults();
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

        private void LoadCaseData()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT CaseTitle, Description, Symptoms, Diagnosis, ModuleID,
                               IsActive, ISNULL(IsInteractive, 0) AS IsInteractive,
                               ISNULL(DifficultyLevel, 'Medium') AS DifficultyLevel,
                               PatientAge, PatientGender, PatientHistory
                        FROM CaseStudies
                        WHERE CaseID = @CaseID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CaseID", caseId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCaseTitle.Text = reader.GetString(0);
                                txtDescription.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                txtSymptoms.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                txtDiagnosis.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);

                                // Set Module
                                int moduleId = reader.GetInt32(4);
                                cboModule.SelectedValue = moduleId;

                                chkIsActive.Checked = reader.GetBoolean(5);
                                chkIsInteractive.Checked = reader.GetBoolean(6);

                                // Set Difficulty Level
                                string difficulty = reader.GetString(7);
                                cboDifficultyLevel.SelectedItem = difficulty;

                                // Patient Info
                                if (!reader.IsDBNull(8))
                                    txtPatientAge.Text = reader.GetInt32(8).ToString();

                                if (!reader.IsDBNull(9))
                                    cboPatientGender.SelectedItem = reader.GetString(9);

                                if (!reader.IsDBNull(10))
                                    txtPatientHistory.Text = reader.GetString(10);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin ca bệnh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExistingExamResults()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT cer.ExaminationTypeID, et.ExaminationName, cer.ResultData, cer.NormalRange, cer.Interpretation
                        FROM CaseExaminationResults cer
                        INNER JOIN ExaminationTypes et ON cer.ExaminationTypeID = et.ExaminationTypeID
                        WHERE cer.CaseID = @CaseID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CaseID", caseId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            lstExamResults.Items.Clear();
                            examinationResults.Clear();

                            while (reader.Read())
                            {
                                ExaminationResultEntry entry = new ExaminationResultEntry
                                {
                                    ExaminationTypeID = reader.GetInt32(0),
                                    ExaminationName = reader.GetString(1),
                                    ResultData = reader.GetString(2),
                                    NormalRange = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    Interpretation = reader.IsDBNull(4) ? "" : reader.GetString(4)
                                };

                                examinationResults.Add(entry);
                                lstExamResults.Items.Add($"{entry.ExaminationName}: {entry.ResultData}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải kết quả xét nghiệm: {ex.Message}", "Lỗi",
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
                            // 1. Update CaseStudies
                            string updateCase = @"
                                UPDATE CaseStudies
                                SET CaseTitle = @CaseTitle,
                                    Description = @Description,
                                    Symptoms = @Symptoms,
                                    Diagnosis = @Diagnosis,
                                    ModuleID = @ModuleID,
                                    IsActive = @IsActive,
                                    IsInteractive = @IsInteractive,
                                    DifficultyLevel = @DifficultyLevel,
                                    PatientAge = @PatientAge,
                                    PatientGender = @PatientGender,
                                    PatientHistory = @PatientHistory
                                WHERE CaseID = @CaseID";

                            using (SqlCommand cmd = new SqlCommand(updateCase, conn, transaction))
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
                                cmd.Parameters.AddWithValue("@CaseID", caseId);

                                cmd.ExecuteNonQuery();
                            }

                            // 2. Delete existing CaseExaminationResults
                            string deleteExamResults = "DELETE FROM CaseExaminationResults WHERE CaseID = @CaseID";
                            using (SqlCommand cmd = new SqlCommand(deleteExamResults, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@CaseID", caseId);
                                cmd.ExecuteNonQuery();
                            }

                            // 3. Insert new CaseExaminationResults
                            foreach (var examResult in examinationResults)
                            {
                                string insertExamResult = @"
                                    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
                                    VALUES (@CaseID, @ExaminationTypeID, @ResultData, @NormalRange, @Interpretation)";

                                using (SqlCommand cmd = new SqlCommand(insertExamResult, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CaseID", caseId);
                                    cmd.Parameters.AddWithValue("@ExaminationTypeID", examResult.ExaminationTypeID);
                                    cmd.Parameters.AddWithValue("@ResultData", examResult.ResultData);
                                    cmd.Parameters.AddWithValue("@NormalRange", string.IsNullOrEmpty(examResult.NormalRange) ? (object)DBNull.Value : examResult.NormalRange);
                                    cmd.Parameters.AddWithValue("@Interpretation", string.IsNullOrEmpty(examResult.Interpretation) ? (object)DBNull.Value : examResult.Interpretation);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            MessageBox.Show($"Cập nhật ca bệnh thành công!\nTổng số {examinationResults.Count} kết quả xét nghiệm.", "Thành công",
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
                MessageBox.Show($"Lỗi khi cập nhật ca bệnh: {ex.Message}", "Lỗi",
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
