using HeathEd;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class StudentMainForm : Form
    {
        public StudentMainForm()
        {
            InitializeComponent();
        }

        private void StudentMainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Xin chào, {UserSession.FullName}";
            LoadModules();
        }

        private void LoadModules()
        {
            flowPanelModules.Controls.Clear();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT m.ModuleID, m.ModuleCode, m.ModuleName, m.Description, u.FullName AS LecturerName
                        FROM Modules m
                        INNER JOIN StudentModules sm ON m.ModuleID = sm.ModuleID
                        INNER JOIN Users u ON m.LecturerID = u.UserID
                        WHERE sm.StudentID = @StudentID AND m.IsActive = 1
                        ORDER BY m.ModuleCode";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", UserSession.UserId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int moduleId = reader.GetInt32(0);
                                string moduleCode = reader.GetString(1);
                                string moduleName = reader.GetString(2);
                                string description = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                string lecturerName = reader.GetString(4);

                                // Tạo GroupBox cho mỗi học phần
                                GroupBox grpModule = new GroupBox();
                                grpModule.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                                grpModule.Size = new Size(420, 180);
                                grpModule.Text = moduleCode;
                                grpModule.Margin = new Padding(10);

                                Label lblModuleName = new Label();
                                lblModuleName.Text = moduleName;
                                lblModuleName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                                lblModuleName.Location = new Point(15, 30);
                                lblModuleName.AutoSize = true;

                                Label lblLecturer = new Label();
                                lblLecturer.Text = $"GV: {lecturerName}";
                                lblLecturer.Location = new Point(15, 60);
                                lblLecturer.AutoSize = true;

                                Label lblDesc = new Label();
                                lblDesc.Text = description;
                                lblDesc.Location = new Point(15, 85);
                                lblDesc.Size = new Size(380, 40);
                                lblDesc.Font = new Font("Segoe UI", 9F);
                                lblDesc.ForeColor = Color.Gray;

                                Button btnDetail = new Button();
                                btnDetail.Text = "Xem chi tiết";
                                btnDetail.BackColor = Color.MediumSlateBlue;
                                btnDetail.ForeColor = Color.White;
                                btnDetail.FlatStyle = FlatStyle.Flat;
                                btnDetail.Location = new Point(270, 130);
                                btnDetail.Size = new Size(130, 35);
                                btnDetail.Tag = moduleId;
                                btnDetail.Click += (s, ev) => BtnDetail_Click(moduleId, moduleName);

                                grpModule.Controls.Add(lblModuleName);
                                grpModule.Controls.Add(lblLecturer);
                                grpModule.Controls.Add(lblDesc);
                                grpModule.Controls.Add(btnDetail);

                                flowPanelModules.Controls.Add(grpModule);
                            }

                            if (flowPanelModules.Controls.Count == 0)
                            {
                                Label lblEmpty = new Label();
                                lblEmpty.Text = "Bạn chưa được ghi danh vào lớp nào.";
                                lblEmpty.Font = new Font("Segoe UI", 12F);
                                lblEmpty.ForeColor = Color.Gray;
                                lblEmpty.AutoSize = true;
                                flowPanelModules.Controls.Add(lblEmpty);
                            }
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

        private void BtnDetail_Click(int moduleId, string moduleName)
        {
            CourseDetailForm form = new CourseDetailForm(moduleId, moduleName);
            form.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadModules();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UserSession.Clear();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void StudentMainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}