using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    partial class StudentMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private Label lblTitle;
        private FlowLayoutPanel flowPanelModules;
        private Button btnRefresh;
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
            this.flowPanelModules = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblWelcome.Location = new System.Drawing.Point(34, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(206, 30);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Xin chào, Sinh viên";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(338, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(392, 45);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "DANH SÁCH HỌC PHẦN";
            // 
            // flowPanelModules
            // 
            this.flowPanelModules.AutoScroll = true;
            this.flowPanelModules.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowPanelModules.Location = new System.Drawing.Point(34, 120);
            this.flowPanelModules.Name = "flowPanelModules";
            this.flowPanelModules.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.flowPanelModules.Size = new System.Drawing.Size(1058, 450);
            this.flowPanelModules.TabIndex = 2;
            // 
            // btnRefresh
            //
            this.btnRefresh.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(788, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(135, 40);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLogout
            //
            this.btnLogout.BackColor = System.Drawing.Color.LightGray;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(956, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(135, 40);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "🚪 Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // StudentMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1125, 600);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.flowPanelModules);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StudentMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeathEd - Sinh viên";
            this.Load += new System.EventHandler(this.StudentMainForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}