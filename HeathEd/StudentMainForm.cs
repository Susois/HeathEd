using HeathEd;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class StudentMainForm : Form
    {
        private LoginForm loginForm;
        private Button btnChatbot;
        private ChatbotForm chatbotForm;

        public StudentMainForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            CreateFloatingChatbotButton();
        }

        private void CreateFloatingChatbotButton()
        {
            // Tạo nút chatbot tròn floating
            btnChatbot = new Button();
            btnChatbot.Size = new Size(60, 60);
            btnChatbot.Location = new Point(this.ClientSize.Width - 80, this.ClientSize.Height - 80);
            btnChatbot.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnChatbot.BackColor = Color.FromArgb(0, 122, 204);
            btnChatbot.ForeColor = Color.White;
            btnChatbot.FlatStyle = FlatStyle.Flat;
            btnChatbot.FlatAppearance.BorderSize = 0;
            btnChatbot.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btnChatbot.Text = "AI";
            btnChatbot.Cursor = Cursors.Hand;

            // Làm nút tròn
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, btnChatbot.Width, btnChatbot.Height);
            btnChatbot.Region = new Region(path);

            // Tooltip
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(btnChatbot, "Chatbot Y Te AI");

            // Event click
            btnChatbot.Click += BtnChatbot_Click;

            // Hover effect
            btnChatbot.MouseEnter += (s, e) => btnChatbot.BackColor = Color.FromArgb(0, 100, 180);
            btnChatbot.MouseLeave += (s, e) => btnChatbot.BackColor = Color.FromArgb(0, 122, 204);

            this.Controls.Add(btnChatbot);
            btnChatbot.BringToFront();
        }

        private void BtnChatbot_Click(object sender, EventArgs e)
        {
            if (chatbotForm == null || chatbotForm.IsDisposed)
            {
                chatbotForm = new ChatbotForm();

                // Đặt vị trí chatbot ở góc phải dưới màn hình
                int x = this.Location.X + this.Width - chatbotForm.Width - 20;
                int y = this.Location.Y + this.Height - chatbotForm.Height - 80;

                // Đảm bảo không vượt ra ngoài màn hình
                if (x < 0) x = 10;
                if (y < 0) y = 10;

                chatbotForm.Location = new Point(x, y);
                chatbotForm.Show();
            }
            else
            {
                if (chatbotForm.Visible)
                {
                    chatbotForm.Hide();
                }
                else
                {
                    chatbotForm.Show();
                    chatbotForm.BringToFront();
                }
            }
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
                            // Tính toán kích thước động để hiển thị 3 lớp/hàng
                            int panelWidth = flowPanelModules.ClientSize.Width - flowPanelModules.Padding.Horizontal;
                            int margin = 10;
                            int moduleWidth = (panelWidth - (margin * 8)) / 3; // Chia cho 3 cột
                            if (moduleWidth < 300) moduleWidth = 300; // Tối thiểu 300px
                            if (moduleWidth > 400) moduleWidth = 400; // Tối đa 400px

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
                                grpModule.Size = new Size(moduleWidth, 180);
                                grpModule.Text = moduleCode;
                                grpModule.Margin = new Padding(margin);

                                Label lblModuleName = new Label();
                                lblModuleName.Text = moduleName;
                                lblModuleName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                                lblModuleName.Location = new Point(15, 30);
                                lblModuleName.MaximumSize = new Size(moduleWidth - 30, 50);
                                lblModuleName.AutoSize = true;

                                Label lblLecturer = new Label();
                                lblLecturer.Text = $"GV: {lecturerName}";
                                lblLecturer.Location = new Point(15, 60);
                                lblLecturer.MaximumSize = new Size(moduleWidth - 30, 20);
                                lblLecturer.AutoSize = true;

                                Label lblDesc = new Label();
                                lblDesc.Text = description;
                                lblDesc.Location = new Point(15, 85);
                                lblDesc.Size = new Size(moduleWidth - 30, 40);
                                lblDesc.Font = new Font("Segoe UI", 9F);
                                lblDesc.ForeColor = Color.Gray;

                                Button btnDetail = new Button();
                                btnDetail.Text = "Xem chi tiết";
                                btnDetail.BackColor = Color.MediumSlateBlue;
                                btnDetail.ForeColor = Color.White;
                                btnDetail.FlatStyle = FlatStyle.Flat;
                                btnDetail.Location = new Point(moduleWidth - 145, 130);
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            StudentDashboardForm dashboardForm = new StudentDashboardForm();
            dashboardForm.ShowDialog();
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

                // Reset login form fields
                if (loginForm != null)
                {
                    loginForm.ResetForm();
                    loginForm.Show();
                }

                this.Close();
            }
        }

        private void StudentMainForm_Load_1(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Xin chào, {UserSession.FullName}";
            LoadModules();
        }
    }
}