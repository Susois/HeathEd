using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HeathEd
{
    public partial class ExaminationResultsForm : Form
    {
        private int caseId;
        private int attemptId;
        private bool isLoadingData = false; // Flag để ngăn vòng lặp vô hạn

        public ExaminationResultsForm(int caseId, int attemptId)
        {
            InitializeComponent();
            this.caseId = caseId;
            this.attemptId = attemptId;
        }

        private void ExaminationResultsForm_Load(object sender, EventArgs e)
        {
            // Thêm handler cho DataError để tránh hiển thị dialog lỗi
            dgvExaminations.DataError += dgvExaminations_DataError;
            LoadRequestedExaminations();
        }

        private void dgvExaminations_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Suppress DataError để tránh hiển thị dialog lỗi
            e.ThrowException = false;
            System.Diagnostics.Debug.WriteLine($"DataGridView DataError: {e.Exception?.Message}");
        }

        private void LoadRequestedExaminations()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            ser.RequestID,
                            et.ExaminationName,
                            et.Cost,
                            ser.RequestedDate,
                            ser.IsViewed
                        FROM StudentExaminationRequests ser
                        INNER JOIN ExaminationTypes et ON ser.ExaminationTypeID = et.ExaminationTypeID
                        WHERE ser.AttemptID = @AttemptID
                        ORDER BY ser.RequestedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AttemptID", attemptId);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvExaminations.DataSource = dt;

                        // Customize columns
                        if (dgvExaminations.Columns["RequestID"] != null)
                            dgvExaminations.Columns["RequestID"].Visible = false;

                        if (dgvExaminations.Columns["ExaminationName"] != null)
                        {
                            dgvExaminations.Columns["ExaminationName"].HeaderText = "Tên xét nghiệm";
                            dgvExaminations.Columns["ExaminationName"].Width = 250;
                        }

                        if (dgvExaminations.Columns["Cost"] != null)
                        {
                            dgvExaminations.Columns["Cost"].HeaderText = "Chi phí";
                            dgvExaminations.Columns["Cost"].DefaultCellStyle.Format = "N0";
                            dgvExaminations.Columns["Cost"].Width = 120;
                        }

                        if (dgvExaminations.Columns["RequestedDate"] != null)
                        {
                            dgvExaminations.Columns["RequestedDate"].HeaderText = "Ngày yêu cầu";
                            dgvExaminations.Columns["RequestedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                            dgvExaminations.Columns["RequestedDate"].Width = 150;
                        }

                        if (dgvExaminations.Columns["IsViewed"] != null)
                        {
                            dgvExaminations.Columns["IsViewed"].HeaderText = "Đã xem";
                            dgvExaminations.Columns["IsViewed"].Width = 80;
                        }

                        lblExamCount.Text = $"Tổng số xét nghiệm: {dt.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách xét nghiệm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvExaminations_SelectionChanged(object sender, EventArgs e)
        {
            // Ngăn vòng lặp vô hạn khi đang load data
            if (isLoadingData) return;

            if (dgvExaminations.SelectedRows.Count > 0)
            {
                int requestId = Convert.ToInt32(dgvExaminations.SelectedRows[0].Cells["RequestID"].Value);
                LoadExaminationResult(requestId);
            }
        }

        private void LoadExaminationResult(int requestId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Get examination type ID from request
                    string getExamTypeQuery = @"
                        SELECT ExaminationTypeID
                        FROM StudentExaminationRequests
                        WHERE RequestID = @RequestID";

                    int examinationTypeId;
                    using (SqlCommand cmd = new SqlCommand(getExamTypeQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@RequestID", requestId);
                        examinationTypeId = (int)cmd.ExecuteScalar();
                    }

                    // Get examination result
                    string query = @"
                        SELECT
                            cer.ResultData,
                            cer.ImagePath,
                            cer.NormalRange,
                            cer.Interpretation,
                            et.ExaminationName
                        FROM CaseExaminationResults cer
                        INNER JOIN ExaminationTypes et ON cer.ExaminationTypeID = et.ExaminationTypeID
                        WHERE cer.CaseID = @CaseID AND cer.ExaminationTypeID = @ExaminationTypeID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CaseID", caseId);
                        cmd.Parameters.AddWithValue("@ExaminationTypeID", examinationTypeId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string examName = reader.GetString(4);
                                string resultData = reader.GetString(0);
                                string normalRange = reader.IsDBNull(2) ? "N/A" : reader.GetString(2);
                                string interpretation = reader.IsDBNull(3) ? "" : reader.GetString(3);

                                // Display result
                                txtResults.Clear();
                                txtResults.AppendText($"XÉT NGHIỆM: {examName}\n");
                                txtResults.AppendText($"{'=',60}\n\n");

                                // Parse JSON result data
                                try
                                {
                                    var json = JObject.Parse(resultData);
                                    txtResults.AppendText("KẾT QUẢ:\n");
                                    foreach (var item in json)
                                    {
                                        txtResults.AppendText($"  • {item.Key}: {item.Value}\n");
                                    }
                                }
                                catch
                                {
                                    txtResults.AppendText($"KẾT QUẢ:\n{resultData}\n");
                                }

                                txtResults.AppendText($"\n{'=',60}\n");
                                txtResults.AppendText($"GIÁ TRỊ BÌNH THƯỜNG:\n{normalRange}\n");
                                txtResults.AppendText($"\n{'=',60}\n");
                                txtResults.AppendText($"GIẢI THÍCH:\n{interpretation}");

                                // Handle image if exists
                                if (!reader.IsDBNull(1))
                                {
                                    string imagePath = reader.GetString(1);
                                    lblImageInfo.Text = $"Hình ảnh: {imagePath}";
                                    lblImageInfo.Visible = true;
                                    // TODO: Load actual image into picImage
                                }
                                else
                                {
                                    lblImageInfo.Visible = false;
                                    picImage.Image = null;
                                }

                                // Mark as viewed
                                MarkAsViewed(requestId);
                            }
                            else
                            {
                                txtResults.Text = "Không tìm thấy kết quả xét nghiệm.";
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

        private void MarkAsViewed(int requestId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE StudentExaminationRequests
                        SET IsViewed = 1, ViewedDate = GETDATE()
                        WHERE RequestID = @RequestID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RequestID", requestId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Cập nhật trực tiếp giá trị IsViewed trong DataGridView mà không reload toàn bộ data
                // Điều này tránh vòng lặp vô hạn
                if (dgvExaminations.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvExaminations.SelectedRows[0];
                    if (selectedRow.Cells["IsViewed"] != null)
                    {
                        // Cập nhật giá trị trực tiếp trong DataTable
                        DataRowView drv = selectedRow.DataBoundItem as DataRowView;
                        if (drv != null)
                        {
                            drv["IsViewed"] = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Silent fail - không cần thông báo lỗi
                System.Diagnostics.Debug.WriteLine($"Error marking as viewed: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // TODO: Implement print functionality
            MessageBox.Show("Chức năng in kết quả sẽ được phát triển trong phiên bản sau.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
