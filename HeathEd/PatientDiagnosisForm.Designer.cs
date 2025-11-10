using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    partial class PatientDiagnosisForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCaseTitle;
        private GroupBox grpPatientInfo;
        private TextBox txtPatientInfo;
        private GroupBox grpImages;
        private ListBox lstImages;
        private GroupBox grpExaminations;
        private ListBox lstExaminations;
        private Button btnRequestExamination;
        private Button btnViewResults;
        private GroupBox grpDiagnosis;
        private Label lblDiagnosisPrompt;
        private TextBox txtDiagnosis;
        private Label lblTreatmentPrompt;
        private TextBox txtTreatment;
        private Button btnSubmitDiagnosis;
        private Label lblTotalCost;
        private Button btnClose;

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
            this.lblCaseTitle = new System.Windows.Forms.Label();
            this.grpPatientInfo = new System.Windows.Forms.GroupBox();
            this.txtPatientInfo = new System.Windows.Forms.TextBox();
            this.grpImages = new System.Windows.Forms.GroupBox();
            this.lstImages = new System.Windows.Forms.ListBox();
            this.grpExaminations = new System.Windows.Forms.GroupBox();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.btnRequestExamination = new System.Windows.Forms.Button();
            this.lstExaminations = new System.Windows.Forms.ListBox();
            this.grpDiagnosis = new System.Windows.Forms.GroupBox();
            this.btnSubmitDiagnosis = new System.Windows.Forms.Button();
            this.txtTreatment = new System.Windows.Forms.TextBox();
            this.lblTreatmentPrompt = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.lblDiagnosisPrompt = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpPatientInfo.SuspendLayout();
            this.grpImages.SuspendLayout();
            this.grpExaminations.SuspendLayout();
            this.grpDiagnosis.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaseTitle
            // 
            this.lblCaseTitle.AutoSize = true;
            this.lblCaseTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCaseTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblCaseTitle.Location = new System.Drawing.Point(30, 20);
            this.lblCaseTitle.Name = "lblCaseTitle";
            this.lblCaseTitle.Size = new System.Drawing.Size(318, 38);
            this.lblCaseTitle.TabIndex = 0;
            this.lblCaseTitle.Text = "CHẨN ĐOÁN CA BỆNH";
            // 
            // grpPatientInfo
            // 
            this.grpPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpPatientInfo.Controls.Add(this.txtPatientInfo);
            this.grpPatientInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPatientInfo.Location = new System.Drawing.Point(30, 70);
            this.grpPatientInfo.Name = "grpPatientInfo";
            this.grpPatientInfo.Size = new System.Drawing.Size(550, 306);
            this.grpPatientInfo.TabIndex = 1;
            this.grpPatientInfo.TabStop = false;
            this.grpPatientInfo.Text = "Thông tin bệnh nhân";
            this.grpPatientInfo.Enter += new System.EventHandler(this.grpPatientInfo_Enter);
            // 
            // txtPatientInfo
            // 
            this.txtPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatientInfo.BackColor = System.Drawing.Color.White;
            this.txtPatientInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPatientInfo.Location = new System.Drawing.Point(15, 30);
            this.txtPatientInfo.Multiline = true;
            this.txtPatientInfo.Name = "txtPatientInfo";
            this.txtPatientInfo.ReadOnly = true;
            this.txtPatientInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPatientInfo.Size = new System.Drawing.Size(520, 261);
            this.txtPatientInfo.TabIndex = 0;
            this.txtPatientInfo.TextChanged += new System.EventHandler(this.txtPatientInfo_TextChanged);
            // 
            // grpImages
            // 
            this.grpImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImages.Controls.Add(this.lstImages);
            this.grpImages.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpImages.Location = new System.Drawing.Point(600, 70);
            this.grpImages.Name = "grpImages";
            this.grpImages.Size = new System.Drawing.Size(550, 160);
            this.grpImages.TabIndex = 2;
            this.grpImages.TabStop = false;
            this.grpImages.Text = "Hình ảnh ban đầu";
            // 
            // lstImages
            // 
            this.lstImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstImages.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstImages.FormattingEnabled = true;
            this.lstImages.ItemHeight = 25;
            this.lstImages.Location = new System.Drawing.Point(15, 30);
            this.lstImages.Name = "lstImages";
            this.lstImages.Size = new System.Drawing.Size(520, 104);
            this.lstImages.TabIndex = 0;
            // 
            // grpExaminations
            // 
            this.grpExaminations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExaminations.Controls.Add(this.btnViewResults);
            this.grpExaminations.Controls.Add(this.btnRequestExamination);
            this.grpExaminations.Controls.Add(this.lstExaminations);
            this.grpExaminations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpExaminations.Location = new System.Drawing.Point(600, 250);
            this.grpExaminations.Name = "grpExaminations";
            this.grpExaminations.Size = new System.Drawing.Size(550, 300);
            this.grpExaminations.TabIndex = 3;
            this.grpExaminations.TabStop = false;
            this.grpExaminations.Text = "Xét nghiệm đã yêu cầu";
            // 
            // btnViewResults
            // 
            this.btnViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewResults.BackColor = System.Drawing.Color.SeaGreen;
            this.btnViewResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewResults.ForeColor = System.Drawing.Color.White;
            this.btnViewResults.Location = new System.Drawing.Point(285, 230);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(250, 50);
            this.btnViewResults.TabIndex = 2;
            this.btnViewResults.Text = "📋 Xem kết quả";
            this.btnViewResults.UseVisualStyleBackColor = false;
            this.btnViewResults.Click += new System.EventHandler(this.btnViewResults_Click);
            // 
            // btnRequestExamination
            // 
            this.btnRequestExamination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRequestExamination.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRequestExamination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestExamination.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRequestExamination.ForeColor = System.Drawing.Color.White;
            this.btnRequestExamination.Location = new System.Drawing.Point(15, 230);
            this.btnRequestExamination.Name = "btnRequestExamination";
            this.btnRequestExamination.Size = new System.Drawing.Size(250, 50);
            this.btnRequestExamination.TabIndex = 1;
            this.btnRequestExamination.Text = "🔬 Yêu cầu xét nghiệm";
            this.btnRequestExamination.UseVisualStyleBackColor = false;
            this.btnRequestExamination.Click += new System.EventHandler(this.btnRequestExamination_Click);
            // 
            // lstExaminations
            // 
            this.lstExaminations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstExaminations.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstExaminations.FormattingEnabled = true;
            this.lstExaminations.ItemHeight = 25;
            this.lstExaminations.Location = new System.Drawing.Point(15, 30);
            this.lstExaminations.Name = "lstExaminations";
            this.lstExaminations.Size = new System.Drawing.Size(520, 179);
            this.lstExaminations.TabIndex = 0;
            // 
            // grpDiagnosis
            // 
            this.grpDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpDiagnosis.Controls.Add(this.btnSubmitDiagnosis);
            this.grpDiagnosis.Controls.Add(this.txtTreatment);
            this.grpDiagnosis.Controls.Add(this.lblTreatmentPrompt);
            this.grpDiagnosis.Controls.Add(this.txtDiagnosis);
            this.grpDiagnosis.Controls.Add(this.lblDiagnosisPrompt);
            this.grpDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDiagnosis.Location = new System.Drawing.Point(30, 382);
            this.grpDiagnosis.Name = "grpDiagnosis";
            this.grpDiagnosis.Size = new System.Drawing.Size(550, 343);
            this.grpDiagnosis.TabIndex = 4;
            this.grpDiagnosis.TabStop = false;
            this.grpDiagnosis.Text = "Chẩn đoán của bạn";
            // 
            // btnSubmitDiagnosis
            // 
            this.btnSubmitDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitDiagnosis.BackColor = System.Drawing.Color.Crimson;
            this.btnSubmitDiagnosis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitDiagnosis.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmitDiagnosis.ForeColor = System.Drawing.Color.White;
            this.btnSubmitDiagnosis.Location = new System.Drawing.Point(20, 285);
            this.btnSubmitDiagnosis.Name = "btnSubmitDiagnosis";
            this.btnSubmitDiagnosis.Size = new System.Drawing.Size(520, 52);
            this.btnSubmitDiagnosis.TabIndex = 4;
            this.btnSubmitDiagnosis.Text = "✓ NỘP BÀI CHẨN ĐOÁN";
            this.btnSubmitDiagnosis.UseVisualStyleBackColor = false;
            this.btnSubmitDiagnosis.Click += new System.EventHandler(this.btnSubmitDiagnosis_Click);
            // 
            // txtTreatment
            // 
            this.txtTreatment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTreatment.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTreatment.Location = new System.Drawing.Point(15, 212);
            this.txtTreatment.Multiline = true;
            this.txtTreatment.Name = "txtTreatment";
            this.txtTreatment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTreatment.Size = new System.Drawing.Size(520, 50);
            this.txtTreatment.TabIndex = 3;
            this.txtTreatment.TextChanged += new System.EventHandler(this.txtTreatment_TextChanged);
            // 
            // lblTreatmentPrompt
            // 
            this.lblTreatmentPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTreatmentPrompt.AutoSize = true;
            this.lblTreatmentPrompt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTreatmentPrompt.Location = new System.Drawing.Point(15, 176);
            this.lblTreatmentPrompt.Name = "lblTreatmentPrompt";
            this.lblTreatmentPrompt.Size = new System.Drawing.Size(322, 25);
            this.lblTreatmentPrompt.TabIndex = 2;
            this.lblTreatmentPrompt.Text = "Phương án điều trị (không bắt buộc):";
            this.lblTreatmentPrompt.Click += new System.EventHandler(this.lblTreatmentPrompt_Click);
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagnosis.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiagnosis.Location = new System.Drawing.Point(15, 65);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosis.Size = new System.Drawing.Size(520, 98);
            this.txtDiagnosis.TabIndex = 1;
            this.txtDiagnosis.TextChanged += new System.EventHandler(this.txtDiagnosis_TextChanged);
            // 
            // lblDiagnosisPrompt
            // 
            this.lblDiagnosisPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiagnosisPrompt.AutoSize = true;
            this.lblDiagnosisPrompt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDiagnosisPrompt.Location = new System.Drawing.Point(15, 35);
            this.lblDiagnosisPrompt.Name = "lblDiagnosisPrompt";
            this.lblDiagnosisPrompt.Size = new System.Drawing.Size(275, 25);
            this.lblDiagnosisPrompt.TabIndex = 0;
            this.lblDiagnosisPrompt.Text = "Bệnh nhân bị bệnh gì? Tại sao?";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalCost.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalCost.Location = new System.Drawing.Point(600, 570);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(220, 30);
            this.lblTotalCost.TabIndex = 5;
            this.lblTotalCost.Text = "Tổng chi phí: 0 VNĐ";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(1000, 680);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 45);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PatientDiagnosisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1219, 762);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.grpDiagnosis);
            this.Controls.Add(this.grpExaminations);
            this.Controls.Add(this.grpImages);
            this.Controls.Add(this.grpPatientInfo);
            this.Controls.Add(this.lblCaseTitle);
            this.Name = "PatientDiagnosisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "HeathEd - Chẩn đoán tương tác";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PatientDiagnosisForm_Load);
            this.grpPatientInfo.ResumeLayout(false);
            this.grpPatientInfo.PerformLayout();
            this.grpImages.ResumeLayout(false);
            this.grpExaminations.ResumeLayout(false);
            this.grpDiagnosis.ResumeLayout(false);
            this.grpDiagnosis.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
