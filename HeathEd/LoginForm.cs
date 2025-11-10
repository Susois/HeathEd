using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class LoginForm : Form
    {
        private const string USERNAME_PLACEHOLDER = "Nhập tên đăng nhập...";
        private const string PASSWORD_PLACEHOLDER = "Nhập mật khẩu...";

        public LoginForm()
        {
            InitializeComponent();
            InitializePlaceholders();
        }

        private void InitializePlaceholders()
        {
            // Set placeholder for username
            txtUsername.Text = USERNAME_PLACEHOLDER;
            txtUsername.ForeColor = Color.Gray;

            // Set placeholder for password - don't use password char for placeholder
            txtPassword.Text = PASSWORD_PLACEHOLDER;
            txtPassword.ForeColor = Color.Gray;
            txtPassword.UseSystemPasswordChar = false;
        }

        public void ResetForm()
        {
            // Clear and reset username field
            txtUsername.Text = USERNAME_PLACEHOLDER;
            txtUsername.ForeColor = Color.Gray;

            // Clear and reset password field
            txtPassword.Text = PASSWORD_PLACEHOLDER;
            txtPassword.ForeColor = Color.Gray;
            txtPassword.UseSystemPasswordChar = false;

            // Focus on username field
            txtUsername.Focus();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == USERNAME_PLACEHOLDER)
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = USERNAME_PLACEHOLDER;
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == PASSWORD_PLACEHOLDER)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = PASSWORD_PLACEHOLDER;
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Get username and password
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate input
            if (username == USERNAME_PLACEHOLDER || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (password == PASSWORD_PLACEHOLDER || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Attempt login
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT UserID, Username, FullName, Email, Role
                                   FROM Users
                                   WHERE Username = @Username
                                   AND Password = @Password
                                   AND IsActive = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Save user session
                                UserSession.UserId = reader.GetInt32(0);
                                UserSession.Username = reader.GetString(1);
                                UserSession.FullName = reader.GetString(2);
                                UserSession.Email = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                UserSession.Role = reader.GetString(4);

                                // Show success message
                                MessageBox.Show($"Chào mừng {UserSession.FullName}!",
                                    "Đăng nhập thành công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                // Open appropriate form based on role
                                Form nextForm;
                                if (UserSession.IsStudent)
                                {
                                    nextForm = new StudentMainForm(this);
                                }
                                else if (UserSession.IsLecturer)
                                {
                                    nextForm = new LecturerMainForm(this);
                                }
                                else
                                {
                                    MessageBox.Show("Vai trò không hợp lệ!", "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Hide login form and show main form
                                this.Hide();
                                nextForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!",
                                    "Lỗi đăng nhập",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                // Clear password field
                                txtPassword.Text = "";
                                txtPassword.Focus();
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi kết nối database:\n{sqlEx.Message}\n\nVui lòng kiểm tra:\n1. SQL Server đã chạy chưa?\n2. Database HeathEdDB đã được tạo chưa?\n3. Connection string trong DatabaseHelper.cs đã đúng chưa?",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
