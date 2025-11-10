using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    partial class LecturerMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private Label lblTitle;
        private Panel panelMenu;
        private Button btnManageModules;
        private Button btnManageStudents;
        private Button btnManageCases;
        private Button btnViewDashboard;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnManageModules = new System.Windows.Forms.Button();
            this.btnManageStudents = new System.Windows.Forms.Button();
            this.btnManageCases = new System.Windows.Forms.Button();
            this.btnViewDashboard = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            //
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblWelcome.Location = new System.Drawing.Point(34, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(249, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Xin chào, Giảng viên";
            // 
            // lblTitle
            //
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(315, 80);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(528, 45);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ GIẢNG VIÊN";
            // 
            // panelMenu
            //
            this.panelMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMenu.Controls.Add(this.btnManageModules);
            this.panelMenu.Controls.Add(this.btnManageStudents);
            this.panelMenu.Controls.Add(this.btnManageCases);
            this.panelMenu.Controls.Add(this.btnViewDashboard);
            this.panelMenu.Location = new System.Drawing.Point(169, 150);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(788, 300);
            this.panelMenu.TabIndex = 2;
            // 
            // btnManageModules
            //
            this.btnManageModules.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnManageModules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageModules.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnManageModules.ForeColor = System.Drawing.Color.White;
            this.btnManageModules.Location = new System.Drawing.Point(56, 40);
            this.btnManageModules.Name = "btnManageModules";
            this.btnManageModules.Size = new System.Drawing.Size(315, 70);
            this.btnManageModules.TabIndex = 0;
            this.btnManageModules.Text = "📚 Quản lý Lớp học";
            this.btnManageModules.UseVisualStyleBackColor = false;
            this.btnManageModules.Click += new System.EventHandler(this.btnManageModules_Click);
            // 
            // btnManageStudents
            //
            this.btnManageStudents.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnManageStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageStudents.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnManageStudents.ForeColor = System.Drawing.Color.White;
            this.btnManageStudents.Location = new System.Drawing.Point(416, 40);
            this.btnManageStudents.Name = "btnManageStudents";
            this.btnManageStudents.Size = new System.Drawing.Size(315, 70);
            this.btnManageStudents.TabIndex = 1;
            this.btnManageStudents.Text = "👥 Quản lý Sinh viên trong lớp";
            this.btnManageStudents.UseVisualStyleBackColor = false;
            this.btnManageStudents.Click += new System.EventHandler(this.btnManageStudents_Click);
            // 
            // btnManageCases
            //
            this.btnManageCases.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnManageCases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCases.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnManageCases.ForeColor = System.Drawing.Color.White;
            this.btnManageCases.Location = new System.Drawing.Point(56, 150);
            this.btnManageCases.Name = "btnManageCases";
            this.btnManageCases.Size = new System.Drawing.Size(315, 70);
            this.btnManageCases.TabIndex = 2;
            this.btnManageCases.Text = "🏥 Quản lý Ca bệnh";
            this.btnManageCases.UseVisualStyleBackColor = false;
            this.btnManageCases.Click += new System.EventHandler(this.btnManageCases_Click);
            // 
            // btnViewDashboard
            //
            this.btnViewDashboard.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnViewDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDashboard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnViewDashboard.ForeColor = System.Drawing.Color.White;
            this.btnViewDashboard.Location = new System.Drawing.Point(416, 150);
            this.btnViewDashboard.Name = "btnViewDashboard";
            this.btnViewDashboard.Size = new System.Drawing.Size(315, 70);
            this.btnViewDashboard.TabIndex = 3;
            this.btnViewDashboard.Text = "📊 Xem Dashboard & Thống kê";
            this.btnViewDashboard.UseVisualStyleBackColor = false;
            this.btnViewDashboard.Click += new System.EventHandler(this.btnViewDashboard_Click);
            // 
            // btnLogout
            //
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.BackColor = System.Drawing.Color.LightGray;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(478, 480);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(169, 45);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "🚪 Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // LecturerMainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1125, 600);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "LecturerMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeathEd - Giảng viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LecturerMainForm_Load_1);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}