using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    partial class LecturerMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private Panel panelSidebar;
        private Button btnDashboard;
        private Button btnManageModules;
        private Button btnManageStudents;
        private Button btnManageCases;
        private Button btnLogout;
        private Panel panelContent;

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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManageCases = new System.Windows.Forms.Button();
            this.btnManageStudents = new System.Windows.Forms.Button();
            this.btnManageModules = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(123, 60);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Xin chào,\r\nGiảng viên";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnManageCases);
            this.panelSidebar.Controls.Add(this.btnManageStudents);
            this.panelSidebar.Controls.Add(this.btnManageModules);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.lblWelcome);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 600);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(35, 538);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(166, 50);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Dang xuat";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManageCases
            // 
            this.btnManageCases.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnManageCases.FlatAppearance.BorderSize = 0;
            this.btnManageCases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCases.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageCases.ForeColor = System.Drawing.Color.White;
            this.btnManageCases.Location = new System.Drawing.Point(20, 260);
            this.btnManageCases.Name = "btnManageCases";
            this.btnManageCases.Size = new System.Drawing.Size(210, 60);
            this.btnManageCases.TabIndex = 4;
            this.btnManageCases.Text = "Quan ly Ca benh";
            this.btnManageCases.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageCases.UseVisualStyleBackColor = false;
            this.btnManageCases.Click += new System.EventHandler(this.btnManageCases_Click);
            // 
            // btnManageStudents
            // 
            this.btnManageStudents.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnManageStudents.FlatAppearance.BorderSize = 0;
            this.btnManageStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageStudents.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageStudents.ForeColor = System.Drawing.Color.White;
            this.btnManageStudents.Location = new System.Drawing.Point(20, 200);
            this.btnManageStudents.Name = "btnManageStudents";
            this.btnManageStudents.Size = new System.Drawing.Size(210, 60);
            this.btnManageStudents.TabIndex = 3;
            this.btnManageStudents.Text = "Quan ly Sinh vien";
            this.btnManageStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageStudents.UseVisualStyleBackColor = false;
            this.btnManageStudents.Click += new System.EventHandler(this.btnManageStudents_Click);
            // 
            // btnManageModules
            // 
            this.btnManageModules.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnManageModules.FlatAppearance.BorderSize = 0;
            this.btnManageModules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageModules.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageModules.ForeColor = System.Drawing.Color.White;
            this.btnManageModules.Location = new System.Drawing.Point(20, 140);
            this.btnManageModules.Name = "btnManageModules";
            this.btnManageModules.Size = new System.Drawing.Size(210, 60);
            this.btnManageModules.TabIndex = 2;
            this.btnManageModules.Text = "Quan ly Lop hoc";
            this.btnManageModules.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageModules.UseVisualStyleBackColor = false;
            this.btnManageModules.Click += new System.EventHandler(this.btnManageModules_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(20, 80);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(210, 60);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(250, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(875, 600);
            this.panelContent.TabIndex = 1;
            // 
            // LecturerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1125, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.Name = "LecturerMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeathEd - Giảng viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LecturerMainForm_Load_1);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
