namespace HeathEd
{
    partial class CourseDetailForm
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
            this.lblModuleName = new System.Windows.Forms.Label();
            this.lblModuleCode = new System.Windows.Forms.Label();
            this.lblLecturer = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCases = new System.Windows.Forms.DataGridView();
            this.lblCaseCount = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCaseDetail = new System.Windows.Forms.TextBox();
            this.btnStartDiagnosis = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(234, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHI TIẾT LỚP HỌC";
            //
            // lblModuleName
            //
            this.lblModuleName.AutoSize = true;
            this.lblModuleName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblModuleName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblModuleName.Location = new System.Drawing.Point(22, 65);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(106, 25);
            this.lblModuleName.TabIndex = 1;
            this.lblModuleName.Text = "Tên lớp học";
            //
            // lblModuleCode
            //
            this.lblModuleCode.AutoSize = true;
            this.lblModuleCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblModuleCode.ForeColor = System.Drawing.Color.Gray;
            this.lblModuleCode.Location = new System.Drawing.Point(24, 95);
            this.lblModuleCode.Name = "lblModuleCode";
            this.lblModuleCode.Size = new System.Drawing.Size(57, 19);
            this.lblModuleCode.TabIndex = 2;
            this.lblModuleCode.Text = "Mã lớp:";
            //
            // lblLecturer
            //
            this.lblLecturer.AutoSize = true;
            this.lblLecturer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLecturer.ForeColor = System.Drawing.Color.Gray;
            this.lblLecturer.Location = new System.Drawing.Point(24, 120);
            this.lblLecturer.Name = "lblLecturer";
            this.lblLecturer.Size = new System.Drawing.Size(82, 19);
            this.lblLecturer.TabIndex = 3;
            this.lblLecturer.Text = "Giảng viên:";
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.ForeColor = System.Drawing.Color.Gray;
            this.lblEmail.Location = new System.Drawing.Point(24, 145);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(45, 19);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            //
            // groupBox1
            //
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(26, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1050, 120);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mô tả lớp học";
            //
            // txtDescription
            //
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(15, 30);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(1020, 75);
            this.txtDescription.TabIndex = 0;
            //
            // groupBox2
            //
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblCaseCount);
            this.groupBox2.Controls.Add(this.dgvCases);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(26, 315);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 270);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách ca bệnh";
            //
            // dgvCases
            //
            this.dgvCases.AllowUserToAddRows = false;
            this.dgvCases.AllowUserToDeleteRows = false;
            this.dgvCases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCases.BackgroundColor = System.Drawing.Color.White;
            this.dgvCases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvCases.ColumnHeadersHeight = 35;
            this.dgvCases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCases.Location = new System.Drawing.Point(15, 30);
            this.dgvCases.MultiSelect = false;
            this.dgvCases.Name = "dgvCases";
            this.dgvCases.ReadOnly = true;
            this.dgvCases.RowHeadersVisible = false;
            this.dgvCases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCases.Size = new System.Drawing.Size(490, 200);
            this.dgvCases.TabIndex = 0;
            this.dgvCases.SelectionChanged += new System.EventHandler(this.dgvCases_SelectionChanged);
            //
            // lblCaseCount
            //
            this.lblCaseCount.AutoSize = true;
            this.lblCaseCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCaseCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblCaseCount.Location = new System.Drawing.Point(15, 240);
            this.lblCaseCount.Name = "lblCaseCount";
            this.lblCaseCount.Size = new System.Drawing.Size(107, 15);
            this.lblCaseCount.TabIndex = 1;
            this.lblCaseCount.Text = "Tổng số: 0 ca bệnh";
            //
            // groupBox3
            //
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtCaseDetail);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(556, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(520, 270);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết ca bệnh";
            //
            // txtCaseDetail
            //
            this.txtCaseDetail.BackColor = System.Drawing.Color.White;
            this.txtCaseDetail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCaseDetail.Location = new System.Drawing.Point(15, 30);
            this.txtCaseDetail.Multiline = true;
            this.txtCaseDetail.Name = "txtCaseDetail";
            this.txtCaseDetail.ReadOnly = true;
            this.txtCaseDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCaseDetail.Size = new System.Drawing.Size(490, 225);
            this.txtCaseDetail.TabIndex = 0;
            //
            // btnStartDiagnosis
            //
            this.btnStartDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartDiagnosis.BackColor = System.Drawing.Color.Crimson;
            this.btnStartDiagnosis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartDiagnosis.FlatAppearance.BorderSize = 0;
            this.btnStartDiagnosis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartDiagnosis.ForeColor = System.Drawing.Color.White;
            this.btnStartDiagnosis.Location = new System.Drawing.Point(726, 595);
            this.btnStartDiagnosis.Name = "btnStartDiagnosis";
            this.btnStartDiagnosis.Size = new System.Drawing.Size(240, 40);
            this.btnStartDiagnosis.TabIndex = 8;
            this.btnStartDiagnosis.Text = "🎯 Thực hành chẩn đoán";
            this.btnStartDiagnosis.UseVisualStyleBackColor = false;
            this.btnStartDiagnosis.Click += new System.EventHandler(this.btnStartDiagnosis_Click);
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Gray;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(976, 595);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // CourseDetailForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartDiagnosis);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblLecturer);
            this.Controls.Add(this.lblModuleCode);
            this.Controls.Add(this.lblModuleName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "CourseDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết lớp học";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CourseDetailForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblModuleName;
        private System.Windows.Forms.Label lblModuleCode;
        private System.Windows.Forms.Label lblLecturer;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCases;
        private System.Windows.Forms.Label lblCaseCount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCaseDetail;
        private System.Windows.Forms.Button btnStartDiagnosis;
        private System.Windows.Forms.Button btnClose;
    }
}
