using HeathEd;
using System;
using System.Windows.Forms;

namespace HeathEd
{
    public partial class LecturerMainForm : Form
    {
        public LecturerMainForm()
        {
            InitializeComponent();
        }

        private void LecturerMainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Xin chào, {UserSession.FullName}";
        }

        private void btnManageModules_Click(object sender, EventArgs e)
        {
            ManageModulesForm form = new ManageModulesForm();
            form.ShowDialog();
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            // Chọn lớp trước khi quản lý sinh viên
            SelectModuleForm selectForm = new SelectModuleForm();
            if (selectForm.ShowDialog() == DialogResult.OK)
            {
                int moduleId = selectForm.SelectedModuleId;
                string moduleName = selectForm.SelectedModuleName;

                ModuleStudentsForm form = new ModuleStudentsForm(moduleId, moduleName);
                form.ShowDialog();
            }
        }

        private void btnManageCases_Click(object sender, EventArgs e)
        {
            ManageCasesForm form = new ManageCasesForm();
            form.ShowDialog();
        }

        private void btnViewDashboard_Click(object sender, EventArgs e)
        {
            LecturerDashboardForm form = new LecturerDashboardForm();
            form.ShowDialog();
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

        private void LecturerMainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}