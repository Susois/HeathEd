using HeathEd;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class LecturerMainForm : Form
    {
        private LoginForm loginForm;
        private Panel currentContentPanel;
        private Button currentSelectedButton;

        public LecturerMainForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void LecturerMainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Xin chào, {UserSession.FullName}";

            // Load Dashboard by default
            btnDashboard.PerformClick();
        }

        private void SetActiveButton(Button button)
        {
            // Reset previous button
            if (currentSelectedButton != null)
            {
                currentSelectedButton.BackColor = Color.MediumSlateBlue;
                currentSelectedButton.ForeColor = Color.White;
            }

            // Set new active button
            currentSelectedButton = button;
            button.BackColor = Color.DodgerBlue;
            button.ForeColor = Color.White;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDashboard);
            LoadDashboardContent();
        }

        private void btnManageModules_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnManageModules);
            LoadModulesContent();
        }

        private void btnManageCases_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnManageCases);
            LoadCasesContent();
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnManageStudents);
            LoadStudentsContent();
        }

        private void LoadDashboardContent()
        {
            panelContent.Controls.Clear();

            Panel dashboardPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true
            };

            // Create inner panel to hold all content
            Panel innerPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(panelContent.Width - 40, 800),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            Label titleLabel = new Label
            {
                Text = "DASHBOARD - TỔNG QUAN",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            innerPanel.Controls.Add(titleLabel);

            // Statistics Panel
            Panel statsPanel = new Panel
            {
                Location = new Point(20, 80),
                Size = new Size(innerPanel.Width - 40, 180)
            };

            // Load statistics
            LoadStatistics(statsPanel);
            innerPanel.Controls.Add(statsPanel);

            // Modules List with Dashboard buttons
            Label modulesLabel = new Label
            {
                Text = "CÁC LỚP HỌC CỦA BẠN",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(20, 280),
                AutoSize = true
            };
            innerPanel.Controls.Add(modulesLabel);

            FlowLayoutPanel modulesFlow = new FlowLayoutPanel
            {
                Location = new Point(20, 320),
                Size = new Size(innerPanel.Width - 40, 50),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };

            LoadModulesWithDashboard(modulesFlow);
            innerPanel.Controls.Add(modulesFlow);

            // Adjust inner panel height based on content
            int totalHeight = 320 + modulesFlow.Height + 40;
            innerPanel.Height = totalHeight;

            dashboardPanel.Controls.Add(innerPanel);
            panelContent.Controls.Add(dashboardPanel);
        }

        private void LoadStatistics(Panel statsPanel)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Module count
                    string moduleQuery = "SELECT COUNT(*) FROM Modules WHERE LecturerID = @LecturerID AND IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(moduleQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);
                        int moduleCount = (int)cmd.ExecuteScalar();
                        CreateStatBox(statsPanel, "Lớp học", moduleCount.ToString(), Color.MediumSlateBlue, 20);
                    }

                    // Student count
                    string studentQuery = @"
                        SELECT COUNT(DISTINCT sm.StudentID)
                        FROM StudentModules sm
                        INNER JOIN Modules m ON sm.ModuleID = m.ModuleID
                        WHERE m.LecturerID = @LecturerID";
                    using (SqlCommand cmd = new SqlCommand(studentQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);
                        int studentCount = (int)cmd.ExecuteScalar();
                        CreateStatBox(statsPanel, "Sinh viên", studentCount.ToString(), Color.SeaGreen, 300);
                    }

                    // Case count
                    string caseQuery = @"
                        SELECT COUNT(*)
                        FROM CaseStudies cs
                        INNER JOIN Modules m ON cs.ModuleID = m.ModuleID
                        WHERE m.LecturerID = @LecturerID AND cs.IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(caseQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);
                        int caseCount = (int)cmd.ExecuteScalar();
                        CreateStatBox(statsPanel, "Ca bệnh", caseCount.ToString(), Color.Coral, 580);
                    }

                    // Total attempts
                    string attemptQuery = @"
                        SELECT COUNT(*)
                        FROM StudentDiagnosisAttempts sda
                        INNER JOIN CaseStudies cs ON sda.CaseID = cs.CaseID
                        INNER JOIN Modules m ON cs.ModuleID = m.ModuleID
                        WHERE m.LecturerID = @LecturerID";
                    using (SqlCommand cmd = new SqlCommand(attemptQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);
                        int attemptCount = (int)cmd.ExecuteScalar();
                        CreateStatBox(statsPanel, "Lượt làm bài", attemptCount.ToString(), Color.DodgerBlue, 860);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thống kê: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateStatBox(Panel parent, string label, string value, Color color, int x)
        {
            GroupBox box = new GroupBox
            {
                Location = new Point(x, 10),
                Size = new Size(250, 150),
                Font = new Font("Segoe UI", 10F),
                Text = label
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 32F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(15, 50),
                Size = new Size(220, 80),
                TextAlign = ContentAlignment.MiddleCenter
            };

            box.Controls.Add(valueLabel);
            parent.Controls.Add(box);
        }

        private void LoadModulesWithDashboard(FlowLayoutPanel flow)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT m.ModuleID, m.ModuleCode, m.ModuleName, m.Description,
                               (SELECT COUNT(*) FROM StudentModules WHERE ModuleID = m.ModuleID) AS StudentCount,
                               (SELECT COUNT(*) FROM CaseStudies WHERE ModuleID = m.ModuleID AND IsActive = 1) AS CaseCount
                        FROM Modules m
                        WHERE m.LecturerID = @LecturerID AND m.IsActive = 1
                        ORDER BY m.CreatedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int moduleId = reader.GetInt32(0);
                                string moduleCode = reader.GetString(1);
                                string moduleName = reader.GetString(2);
                                string description = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                int studentCount = reader.GetInt32(4);
                                int caseCount = reader.GetInt32(5);

                                Panel modulePanel = new Panel
                                {
                                    Size = new Size(flow.Width - 40, 140),
                                    BackColor = Color.White,
                                    BorderStyle = BorderStyle.FixedSingle,
                                    Margin = new Padding(5)
                                };

                                Label codeLabel = new Label
                                {
                                    Text = moduleCode,
                                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                                    Location = new Point(15, 15),
                                    AutoSize = true
                                };

                                Label nameLabel = new Label
                                {
                                    Text = moduleName,
                                    Font = new Font("Segoe UI", 11F),
                                    Location = new Point(15, 45),
                                    Size = new Size(modulePanel.Width - 180, 25)
                                };

                                Label infoLabel = new Label
                                {
                                    Text = $"Sinh viên: {studentCount} | Ca bệnh: {caseCount}",
                                    Font = new Font("Segoe UI", 9F),
                                    ForeColor = Color.Gray,
                                    Location = new Point(15, 75),
                                    AutoSize = true
                                };

                                Button dashboardBtn = new Button
                                {
                                    Text = "Dashboard",
                                    BackColor = Color.DodgerBlue,
                                    ForeColor = Color.White,
                                    FlatStyle = FlatStyle.Flat,
                                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                                    Location = new Point(modulePanel.Width - 260, 95),
                                    Size = new Size(120, 35),
                                    Tag = moduleId
                                };
                                dashboardBtn.Click += (s, ev) =>
                                {
                                    ModuleDashboardForm dashForm = new ModuleDashboardForm(moduleId, moduleName);
                                    dashForm.ShowDialog();
                                };

                                Button editBtn = new Button
                                {
                                    Text = "Chi tiết",
                                    BackColor = Color.MediumSlateBlue,
                                    ForeColor = Color.White,
                                    FlatStyle = FlatStyle.Flat,
                                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                                    Location = new Point(modulePanel.Width - 130, 95),
                                    Size = new Size(120, 35),
                                    Tag = moduleId
                                };

                                modulePanel.Controls.Add(codeLabel);
                                modulePanel.Controls.Add(nameLabel);
                                modulePanel.Controls.Add(infoLabel);
                                modulePanel.Controls.Add(dashboardBtn);
                                modulePanel.Controls.Add(editBtn);

                                flow.Controls.Add(modulePanel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách lớp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadModulesContent()
        {
            panelContent.Controls.Clear();

            ManageModulesForm form = new ManageModulesForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelContent.Controls.Add(form);
            form.Show();
        }

        private void LoadCasesContent()
        {
            panelContent.Controls.Clear();

            ManageCasesForm form = new ManageCasesForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelContent.Controls.Add(form);
            form.Show();
        }

        private void LoadStudentsContent()
        {
            panelContent.Controls.Clear();

            // Create a panel to show module selection and students
            Panel studentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            Label titleLabel = new Label
            {
                Text = "QUẢN LÝ SINH VIÊN",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            studentPanel.Controls.Add(titleLabel);

            // Module selection dropdown
            Label lblSelectModule = new Label
            {
                Text = "Chọn lớp học:",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(20, 80),
                AutoSize = true
            };
            studentPanel.Controls.Add(lblSelectModule);

            ComboBox cmbModules = new ComboBox
            {
                Font = new Font("Segoe UI", 10F),
                Location = new Point(150, 78),
                Size = new Size(400, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            studentPanel.Controls.Add(cmbModules);

            // Load modules into combo box
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT ModuleID, ModuleCode, ModuleName
                        FROM Modules
                        WHERE LecturerID = @LecturerID AND IsActive = 1
                        ORDER BY ModuleCode";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LecturerID", UserSession.UserId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbModules.Items.Add(new ComboBoxItem
                                {
                                    Value = reader.GetInt32(0),
                                    Text = $"{reader.GetString(1)} - {reader.GetString(2)}"
                                });
                            }
                        }
                    }
                }

                if (cmbModules.Items.Count > 0)
                {
                    cmbModules.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách lớp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Panel to embed ModuleStudentsForm
            Panel studentsContainer = new Panel
            {
                Location = new Point(20, 130),
                Size = new Size(panelContent.Width - 40, panelContent.Height - 150),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            studentPanel.Controls.Add(studentsContainer);

            // Handle module selection change
            cmbModules.SelectedIndexChanged += (s, ev) =>
            {
                if (cmbModules.SelectedItem != null)
                {
                    ComboBoxItem selected = (ComboBoxItem)cmbModules.SelectedItem;
                    int moduleId = selected.Value;
                    string moduleName = selected.Text;

                    studentsContainer.Controls.Clear();

                    ModuleStudentsForm form = new ModuleStudentsForm(moduleId, moduleName)
                    {
                        TopLevel = false,
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill
                    };
                    studentsContainer.Controls.Add(form);
                    form.Show();
                }
            };

            // Trigger initial load
            if (cmbModules.Items.Count > 0)
            {
                cmbModules.SelectedIndex = 0;
            }

            panelContent.Controls.Add(studentPanel);
        }

        // Helper class for ComboBox items
        private class ComboBoxItem
        {
            public int Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
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

                if (loginForm != null)
                {
                    loginForm.ResetForm();
                    loginForm.Show();
                }

                this.Close();
            }
        }

        private void LecturerMainForm_Load_1(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Xin chào, {UserSession.FullName}";
            btnDashboard.PerformClick();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
