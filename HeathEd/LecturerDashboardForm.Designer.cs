namespace HeathEd
{
    partial class LecturerDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblModuleCount = new System.Windows.Forms.Label();
            this.lblModuleTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStudentCount = new System.Windows.Forms.Label();
            this.lblStudentTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCaseCount = new System.Windows.Forms.Label();
            this.lblCaseTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRecentModules = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvRecentCases = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentModules)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentCases)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(288, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DASHBOARD GIẢNG VIÊN";
            //
            // lblWelcome
            //
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWelcome.ForeColor = System.Drawing.Color.DimGray;
            this.lblWelcome.Location = new System.Drawing.Point(22, 60);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(202, 20);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Chào mừng trở lại, Giảng viên!";
            //
            // panel1
            //
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Controls.Add(this.lblModuleCount);
            this.panel1.Controls.Add(this.lblModuleTitle);
            this.panel1.Location = new System.Drawing.Point(26, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 120);
            this.panel1.TabIndex = 2;
            //
            // lblModuleCount
            //
            this.lblModuleCount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblModuleCount.ForeColor = System.Drawing.Color.White;
            this.lblModuleCount.Location = new System.Drawing.Point(15, 40);
            this.lblModuleCount.Name = "lblModuleCount";
            this.lblModuleCount.Size = new System.Drawing.Size(250, 60);
            this.lblModuleCount.TabIndex = 1;
            this.lblModuleCount.Text = "0";
            this.lblModuleCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblModuleTitle
            //
            this.lblModuleTitle.AutoSize = true;
            this.lblModuleTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblModuleTitle.ForeColor = System.Drawing.Color.White;
            this.lblModuleTitle.Location = new System.Drawing.Point(15, 15);
            this.lblModuleTitle.Name = "lblModuleTitle";
            this.lblModuleTitle.Size = new System.Drawing.Size(149, 21);
            this.lblModuleTitle.TabIndex = 0;
            this.lblModuleTitle.Text = "TỔNG SỐ LỚP HỌC";
            //
            // panel2
            //
            this.panel2.BackColor = System.Drawing.Color.SeaGreen;
            this.panel2.Controls.Add(this.lblStudentCount);
            this.panel2.Controls.Add(this.lblStudentTitle);
            this.panel2.Location = new System.Drawing.Point(326, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 120);
            this.panel2.TabIndex = 3;
            //
            // lblStudentCount
            //
            this.lblStudentCount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblStudentCount.ForeColor = System.Drawing.Color.White;
            this.lblStudentCount.Location = new System.Drawing.Point(15, 40);
            this.lblStudentCount.Name = "lblStudentCount";
            this.lblStudentCount.Size = new System.Drawing.Size(250, 60);
            this.lblStudentCount.TabIndex = 1;
            this.lblStudentCount.Text = "0";
            this.lblStudentCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblStudentTitle
            //
            this.lblStudentTitle.AutoSize = true;
            this.lblStudentTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStudentTitle.ForeColor = System.Drawing.Color.White;
            this.lblStudentTitle.Location = new System.Drawing.Point(15, 15);
            this.lblStudentTitle.Name = "lblStudentTitle";
            this.lblStudentTitle.Size = new System.Drawing.Size(164, 21);
            this.lblStudentTitle.TabIndex = 0;
            this.lblStudentTitle.Text = "TỔNG SỐ SINH VIÊN";
            //
            // panel3
            //
            this.panel3.BackColor = System.Drawing.Color.Coral;
            this.panel3.Controls.Add(this.lblCaseCount);
            this.panel3.Controls.Add(this.lblCaseTitle);
            this.panel3.Location = new System.Drawing.Point(626, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 120);
            this.panel3.TabIndex = 4;
            //
            // lblCaseCount
            //
            this.lblCaseCount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblCaseCount.ForeColor = System.Drawing.Color.White;
            this.lblCaseCount.Location = new System.Drawing.Point(15, 40);
            this.lblCaseCount.Name = "lblCaseCount";
            this.lblCaseCount.Size = new System.Drawing.Size(250, 60);
            this.lblCaseCount.TabIndex = 1;
            this.lblCaseCount.Text = "0";
            this.lblCaseCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblCaseTitle
            //
            this.lblCaseTitle.AutoSize = true;
            this.lblCaseTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCaseTitle.ForeColor = System.Drawing.Color.White;
            this.lblCaseTitle.Location = new System.Drawing.Point(15, 15);
            this.lblCaseTitle.Name = "lblCaseTitle";
            this.lblCaseTitle.Size = new System.Drawing.Size(147, 21);
            this.lblCaseTitle.TabIndex = 0;
            this.lblCaseTitle.Text = "TỔNG SỐ CA BỆNH";
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.dgvRecentModules);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(26, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 220);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lớp học gần đây";
            //
            // dgvRecentModules
            //
            this.dgvRecentModules.AllowUserToAddRows = false;
            this.dgvRecentModules.AllowUserToDeleteRows = false;
            this.dgvRecentModules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentModules.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentModules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvRecentModules.ColumnHeadersHeight = 35;
            this.dgvRecentModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecentModules.Location = new System.Drawing.Point(15, 30);
            this.dgvRecentModules.Name = "dgvRecentModules";
            this.dgvRecentModules.ReadOnly = true;
            this.dgvRecentModules.RowHeadersVisible = false;
            this.dgvRecentModules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentModules.Size = new System.Drawing.Size(850, 175);
            this.dgvRecentModules.TabIndex = 0;
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.dgvRecentCases);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(26, 475);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(880, 220);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ca bệnh gần đây";
            //
            // dgvRecentCases
            //
            this.dgvRecentCases.AllowUserToAddRows = false;
            this.dgvRecentCases.AllowUserToDeleteRows = false;
            this.dgvRecentCases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentCases.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentCases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvRecentCases.ColumnHeadersHeight = 35;
            this.dgvRecentCases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecentCases.Location = new System.Drawing.Point(15, 30);
            this.dgvRecentCases.Name = "dgvRecentCases";
            this.dgvRecentCases.ReadOnly = true;
            this.dgvRecentCases.RowHeadersVisible = false;
            this.dgvRecentCases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentCases.Size = new System.Drawing.Size(850, 175);
            this.dgvRecentCases.TabIndex = 0;
            //
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.Gray;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(806, 705);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // LecturerDashboardForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(930, 760);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LecturerDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Giảng viên";
            this.Load += new System.EventHandler(this.LecturerDashboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentModules)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentCases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblModuleCount;
        private System.Windows.Forms.Label lblModuleTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStudentCount;
        private System.Windows.Forms.Label lblStudentTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCaseCount;
        private System.Windows.Forms.Label lblCaseTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRecentModules;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvRecentCases;
        private System.Windows.Forms.Button btnClose;
    }
}
