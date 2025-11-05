using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class SelectModuleForm : Form
    {
        public int SelectedModuleId { get; private set; }
        public string SelectedModuleName { get; private set; }

        public SelectModuleForm()
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

        private void SelectModuleForm_Load(object sender, EventArgs e)
        {
            LoadModules();
        }

        private void LoadModules()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT ModuleID, ModuleCode, ModuleName, Description,
                               (SELECT COUNT(*) FROM StudentModules WHERE ModuleID = m.ModuleID) AS StudentCount
                        FROM Modules m
                        WHERE LecturerID = @LecturerID AND IsActive = 1
                        ORDER BY ModuleCode";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvModules.DataSource = dt;

                        // Ẩn cột ModuleID
                        if (dgvModules.Columns["ModuleID"] != null)
                            dgvModules.Columns["ModuleID"].Visible = false;

                        // Đổi tên và thiết lập độ rộng các cột
                        if (dgvModules.Columns["ModuleCode"] != null)
                        {
                            dgvModules.Columns["ModuleCode"].HeaderText = "Mã lớp";
                            dgvModules.Columns["ModuleCode"].Width = 120;
                        }

                        if (dgvModules.Columns["ModuleName"] != null)
                        {
                            dgvModules.Columns["ModuleName"].HeaderText = "Tên lớp";
                            dgvModules.Columns["ModuleName"].Width = 250;
                        }

                        if (dgvModules.Columns["Description"] != null)
                        {
                            dgvModules.Columns["Description"].HeaderText = "Mô tả";
                            dgvModules.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                        if (dgvModules.Columns["StudentCount"] != null)
                        {
                            dgvModules.Columns["StudentCount"].HeaderText = "SL Sinh viên";
                            dgvModules.Columns["StudentCount"].Width = 100;
                            dgvModules.Columns["StudentCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }

                        // Cập nhật label đếm số lượng
                        UpdateCountLabel(dt.Rows.Count);

                        // Tự động chọn dòng đầu tiên nếu có
                        if (dgvModules.Rows.Count > 0)
                        {
                            dgvModules.Rows[0].Selected = true;
                            btnSelect.Enabled = true;
                        }
                        else
                        {
                            btnSelect.Enabled = false;
                            lblCount.Text = "Bạn chưa có lớp học nào";
                            lblCount.ForeColor = Color.Crimson;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCountLabel(int count)
        {
            lblCount.Text = $"Tổng số: {count} lớp học";
            lblCount.ForeColor = Color.DimGray;
        }

        private void dgvModules_SelectionChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = dgvModules.SelectedRows.Count > 0;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectModule();
        }

        private void dgvModules_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectModule();
            }
        }

        private void SelectModule()
        {
            if (dgvModules.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvModules.SelectedRows[0];
                SelectedModuleId = Convert.ToInt32(row.Cells["ModuleID"].Value);
                SelectedModuleName = row.Cells["ModuleName"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lớp học!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
