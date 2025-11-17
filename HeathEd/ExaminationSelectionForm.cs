using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class ExaminationSelectionForm : Form
    {
        private int caseId;
        private int attemptId;
        private List<int> requestedExaminations;

        public ExaminationSelectionForm(int caseId, int attemptId, List<int> requestedExaminations)
        {
            InitializeComponent();
            this.caseId = caseId;
            this.attemptId = attemptId;
            this.requestedExaminations = requestedExaminations;
        }

        private void ExaminationSelectionForm_Load(object sender, EventArgs e)
        {
            LoadAvailableExaminations();
        }

        private void LoadAvailableExaminations()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Chỉ hiển thị các xét nghiệm có kết quả trong database cho ca bệnh này
                    string query = @"
                        SELECT et.ExaminationTypeID, et.ExaminationCode, et.ExaminationName, et.Description, et.Cost
                        FROM ExaminationTypes et
                        INNER JOIN CaseExaminationResults cer ON et.ExaminationTypeID = cer.ExaminationTypeID
                        WHERE et.IsActive = 1 AND cer.CaseID = @CaseID
                        ORDER BY et.ExaminationCode";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CaseID", caseId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            lstExaminations.Items.Clear();

                            while (reader.Read())
                            {
                                int examId = reader.GetInt32(0);
                                string examCode = reader.GetString(1);
                                string examName = reader.GetString(2);
                                string description = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                decimal cost = reader.GetDecimal(4);

                                // Tạo item cho ListBox
                                ExaminationItem item = new ExaminationItem
                                {
                                    ExaminationTypeID = examId,
                                    DisplayText = $"{examCode} - {examName} ({cost:N0} VNĐ)"
                                };

                                lstExaminations.Items.Add(item);
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

        private void lstExaminations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstExaminations.SelectedItem != null)
            {
                ExaminationItem item = (ExaminationItem)lstExaminations.SelectedItem;
                LoadExaminationDetails(item.ExaminationTypeID);
            }
        }

        private void LoadExaminationDetails(int examinationTypeID)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT ExaminationName, Description, Cost
                        FROM ExaminationTypes
                        WHERE ExaminationTypeID = @ExaminationTypeID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ExaminationTypeID", examinationTypeID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtExamDetails.Clear();
                                txtExamDetails.AppendText($"TÊN XÉT NGHIỆM: {reader.GetString(0)}\r\n\r\n");
                                txtExamDetails.AppendText($"MÔ TẢ:\r\n{reader.GetString(1)}\r\n\r\n");
                                txtExamDetails.AppendText($"CHI PHÍ: {reader.GetDecimal(2):N0} VNĐ");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chi tiết xét nghiệm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRequestExam_Click(object sender, EventArgs e)
        {
            if (lstExaminations.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn xét nghiệm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExaminationItem item = (ExaminationItem)lstExaminations.SelectedItem;

            // Kiểm tra xem đã yêu cầu xét nghiệm này chưa
            if (requestedExaminations.Contains(item.ExaminationTypeID))
            {
                MessageBox.Show("Bạn đã yêu cầu xét nghiệm này rồi!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra xem ca bệnh này có kết quả xét nghiệm không
                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM CaseExaminationResults
                        WHERE CaseID = @CaseID AND ExaminationTypeID = @ExaminationTypeID";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@CaseID", caseId);
                        checkCmd.Parameters.AddWithValue("@ExaminationTypeID", item.ExaminationTypeID);

                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Ca bệnh này không có kết quả cho xét nghiệm bạn chọn!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Lưu yêu cầu xét nghiệm
                    string insertQuery = @"
                        INSERT INTO StudentExaminationRequests (AttemptID, ExaminationTypeID, RequestedDate, IsViewed)
                        VALUES (@AttemptID, @ExaminationTypeID, GETDATE(), 0)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@AttemptID", attemptId);
                        cmd.Parameters.AddWithValue("@ExaminationTypeID", item.ExaminationTypeID);
                        cmd.ExecuteNonQuery();

                        requestedExaminations.Add(item.ExaminationTypeID);

                        MessageBox.Show("Đã yêu cầu xét nghiệm thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi yêu cầu xét nghiệm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Helper class để lưu thông tin xét nghiệm trong ListBox
        private class ExaminationItem
        {
            public int ExaminationTypeID { get; set; }
            public string DisplayText { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }
    }
}
