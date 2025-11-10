using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HeathEd
{
    public partial class PatientDiagnosisForm : Form
    {
        private int caseId;
        private int attemptId;
        private decimal totalCost = 0;
        private DateTime startTime;
        private List<int> requestedExaminations = new List<int>();

        public PatientDiagnosisForm(int caseId)
        {
            InitializeComponent();
            this.caseId = caseId;
            this.startTime = DateTime.Now;
        }

        private void PatientDiagnosisForm_Load(object sender, EventArgs e)
        {
            CreateNewAttempt();
            LoadCaseInfo();
            LoadPatientImages();
            UpdateCostDisplay();
        }

        private void CreateNewAttempt()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO StudentDiagnosisAttempts (StudentID, CaseID, AttemptDate, IsCompleted, TotalCost)
                        VALUES (@StudentID, @CaseID, GETDATE(), 0, 0);
                        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", UserSession.UserId);
                        cmd.Parameters.AddWithValue("@CaseID", caseId);

                        attemptId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo phiên chẩn đoán: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadCaseInfo()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT CaseTitle, Description, Symptoms, PatientAge, PatientGender, PatientHistory
                        FROM CaseStudies
                        WHERE CaseID = @CaseID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CaseID", caseId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblCaseTitle.Text = reader.GetString(0);
                                txtPatientInfo.Clear();
                                txtPatientInfo.AppendText($"MÔ TẢ: {reader.GetString(1)}\r\n\r\n");
                                txtPatientInfo.AppendText($"TUỔI: {(reader.IsDBNull(3) ? "N/A" : reader.GetInt32(3).ToString())}\r\n");
                                txtPatientInfo.AppendText($"GIỚI TÍNH: {(reader.IsDBNull(4) ? "N/A" : reader.GetString(4))}\r\n\r\n");
                                txtPatientInfo.AppendText($"TIỀN SỬ BỆNH:\r\n{(reader.IsDBNull(5) ? "Không có" : reader.GetString(5))}\r\n\r\n");
                                txtPatientInfo.AppendText($"TRIỆU CHỨNG BAN ĐẦU:\r\n{reader.GetString(2)}");
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

        private void LoadPatientImages()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT ImagePath, ImageType, Description
                        FROM CaseImages
                        WHERE CaseID = @CaseID AND IsInitiallyVisible = 1
                        ORDER BY DisplayOrder";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CaseID", caseId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            lstImages.Items.Clear();
                            while (reader.Read())
                            {
                                string imagePath = reader.GetString(0);
                                string imageType = reader.IsDBNull(1) ? "Hình ảnh" : reader.GetString(1);
                                string description = reader.IsDBNull(2) ? "" : reader.GetString(2);

                                lstImages.Items.Add($"{imageType}: {description}");
                            }

                            if (lstImages.Items.Count == 0)
                            {
                                lstImages.Items.Add("Chưa có hình ảnh ban đầu");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải hình ảnh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRequestExamination_Click(object sender, EventArgs e)
        {
            // Mở form chọn xét nghiệm
            ExaminationSelectionForm examForm = new ExaminationSelectionForm(caseId, attemptId, requestedExaminations);
            if (examForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh danh sách xét nghiệm đã yêu cầu
                LoadRequestedExaminations();
                UpdateCostDisplay();
            }
        }

        private void LoadRequestedExaminations()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT et.ExaminationName, et.Cost, ser.RequestedDate, ser.IsViewed
                        FROM StudentExaminationRequests ser
                        INNER JOIN ExaminationTypes et ON ser.ExaminationTypeID = et.ExaminationTypeID
                        WHERE ser.AttemptID = @AttemptID
                        ORDER BY ser.RequestedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AttemptID", attemptId);

                        lstExaminations.Items.Clear();
                        totalCost = 0;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string examName = reader.GetString(0);
                                decimal cost = reader.GetDecimal(1);
                                bool isViewed = reader.GetBoolean(3);
                                string status = isViewed ? "✓" : "○";

                                lstExaminations.Items.Add($"{status} {examName} - {cost:N0} VNĐ");
                                totalCost += cost;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách xét nghiệm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            // Mở form xem kết quả xét nghiệm
            ExaminationResultsForm resultsForm = new ExaminationResultsForm(caseId, attemptId);
            resultsForm.ShowDialog();
            LoadRequestedExaminations(); // Refresh để cập nhật trạng thái đã xem
        }

        private void btnSubmitDiagnosis_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Vui lòng nhập chẩn đoán của bạn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn nộp bài chẩn đoán? Sau khi nộp bạn không thể chỉnh sửa!",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SubmitDiagnosis();
            }
        }

        private void SubmitDiagnosis()
        {
            try
            {
                int timeSpent = (int)(DateTime.Now - startTime).TotalMinutes;

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Lấy chẩn đoán đúng
                    string correctDiagnosis = "";
                    string queryCorrect = "SELECT Diagnosis FROM CaseStudies WHERE CaseID = @CaseID";
                    using (SqlCommand cmd = new SqlCommand(queryCorrect, conn))
                    {
                        cmd.Parameters.AddWithValue("@CaseID", caseId);
                        correctDiagnosis = cmd.ExecuteScalar()?.ToString() ?? "";
                    }

                    // Tính điểm tương đồng (đơn giản - so sánh chuỗi)
                    decimal similarityScore = CalculateSimilarity(txtDiagnosis.Text.Trim(), correctDiagnosis);
                    bool isCorrect = similarityScore >= 70;

                    // Lưu chẩn đoán của sinh viên
                    string query = @"
                        INSERT INTO StudentDiagnosisSubmissions (AttemptID, DiagnosisText, TreatmentPlan, SubmittedDate, IsCorrect, SimilarityScore, FeedbackText)
                        VALUES (@AttemptID, @DiagnosisText, @TreatmentPlan, GETDATE(), @IsCorrect, @SimilarityScore, @FeedbackText)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AttemptID", attemptId);
                        cmd.Parameters.AddWithValue("@DiagnosisText", txtDiagnosis.Text.Trim());
                        cmd.Parameters.AddWithValue("@TreatmentPlan", txtTreatment.Text.Trim());
                        cmd.Parameters.AddWithValue("@IsCorrect", isCorrect);
                        cmd.Parameters.AddWithValue("@SimilarityScore", similarityScore);
                        cmd.Parameters.AddWithValue("@FeedbackText", GenerateFeedback(similarityScore, correctDiagnosis));
                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật attempt
                    string updateQuery = @"
                        UPDATE StudentDiagnosisAttempts
                        SET IsCompleted = 1, TotalCost = @TotalCost, TimeSpent = @TimeSpent, Score = @Score
                        WHERE AttemptID = @AttemptID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@AttemptID", attemptId);
                        cmd.Parameters.AddWithValue("@TotalCost", totalCost);
                        cmd.Parameters.AddWithValue("@TimeSpent", timeSpent);
                        cmd.Parameters.AddWithValue("@Score", similarityScore);
                        cmd.ExecuteNonQuery();
                    }

                    // Hiển thị kết quả
                    ShowResults(isCorrect, similarityScore, correctDiagnosis);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nộp bài: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalculateSimilarity(string studentAnswer, string correctAnswer)
        {
            // Thuật toán đơn giản: đếm số từ khóa khớp
            // Trong thực tế, nên dùng thuật toán phức tạp hơn (Levenshtein, cosine similarity, etc.)

            string[] correctKeywords = correctAnswer.ToLower().Split(new[] { ' ', ',', '.', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string studentAnswerLower = studentAnswer.ToLower();

            int matchCount = 0;
            foreach (string keyword in correctKeywords)
            {
                if (keyword.Length > 3 && studentAnswerLower.Contains(keyword))
                {
                    matchCount++;
                }
            }

            decimal similarity = (decimal)matchCount / correctKeywords.Length * 100;
            return Math.Min(similarity, 100);
        }

        private string GenerateFeedback(decimal score, string correctDiagnosis)
        {
            string feedback = "";

            if (score >= 90)
                feedback = "Xuất sắc! Chẩn đoán của bạn rất chính xác.\n\n";
            else if (score >= 70)
                feedback = "Tốt! Chẩn đoán của bạn khá chính xác nhưng còn một số điểm cần cải thiện.\n\n";
            else if (score >= 50)
                feedback = "Được! Bạn đã nắm được một phần nhưng cần xem xét kỹ hơn các triệu chứng.\n\n";
            else
                feedback = "Chưa chính xác. Hãy xem lại các triệu chứng và kết quả xét nghiệm.\n\n";

            feedback += $"Chẩn đoán đúng:\n{correctDiagnosis}";

            return feedback;
        }

        private void ShowResults(bool isCorrect, decimal score, string correctDiagnosis)
        {
            string message = $"KẾT QUẢ CHẨN ĐOÁN\n\n";
            message += $"Điểm số: {score:F1}/100\n";
            message += $"Trạng thái: {(isCorrect ? "✓ ĐÚNG" : "✗ CHƯA CHÍNH XÁC")}\n";
            message += $"Tổng chi phí xét nghiệm: {totalCost:N0} VNĐ\n";
            message += $"Thời gian: {(DateTime.Now - startTime).TotalMinutes:F1} phút\n\n";
            message += $"Chẩn đoán đúng:\n{correctDiagnosis}";

            MessageBox.Show(message, "Kết quả", MessageBoxButtons.OK,
                isCorrect ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            this.Close();
        }

        private void UpdateCostDisplay()
        {
            lblTotalCost.Text = $"Tổng chi phí: {totalCost:N0} VNĐ";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn chưa hoàn thành bài chẩn đoán. Bạn có chắc muốn thoát?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtDiagnosis_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPatientInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpPatientInfo_Enter(object sender, EventArgs e)
        {

        }

        private void txtTreatment_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTreatmentPrompt_Click(object sender, EventArgs e)
        {

        }
    }
}
