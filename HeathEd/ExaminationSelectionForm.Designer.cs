using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    partial class ExaminationSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private GroupBox grpExaminations;
        private ListBox lstExaminations;
        private GroupBox grpDetails;
        private TextBox txtExamDetails;
        private Button btnRequestExam;
        private Button btnCancel;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpExaminations = new System.Windows.Forms.GroupBox();
            this.lstExaminations = new System.Windows.Forms.ListBox();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.txtExamDetails = new System.Windows.Forms.TextBox();
            this.btnRequestExam = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpExaminations.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(277, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHỌN XÉT NGHIỆM";
            // 
            // grpExaminations
            // 
            this.grpExaminations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpExaminations.Controls.Add(this.lstExaminations);
            this.grpExaminations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpExaminations.Location = new System.Drawing.Point(30, 70);
            this.grpExaminations.Name = "grpExaminations";
            this.grpExaminations.Size = new System.Drawing.Size(500, 450);
            this.grpExaminations.TabIndex = 1;
            this.grpExaminations.TabStop = false;
            this.grpExaminations.Text = "Danh sách xét nghiệm có sẵn";
            // 
            // lstExaminations
            // 
            this.lstExaminations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstExaminations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstExaminations.FormattingEnabled = true;
            this.lstExaminations.ItemHeight = 28;
            this.lstExaminations.Location = new System.Drawing.Point(15, 35);
            this.lstExaminations.Name = "lstExaminations";
            this.lstExaminations.Size = new System.Drawing.Size(470, 396);
            this.lstExaminations.TabIndex = 0;
            this.lstExaminations.SelectedIndexChanged += new System.EventHandler(this.lstExaminations_SelectedIndexChanged);
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Controls.Add(this.txtExamDetails);
            this.grpDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDetails.Location = new System.Drawing.Point(550, 70);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(450, 450);
            this.grpDetails.TabIndex = 2;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Chi tiết xét nghiệm";
            // 
            // txtExamDetails
            // 
            this.txtExamDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExamDetails.BackColor = System.Drawing.Color.White;
            this.txtExamDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtExamDetails.Location = new System.Drawing.Point(15, 35);
            this.txtExamDetails.Multiline = true;
            this.txtExamDetails.Name = "txtExamDetails";
            this.txtExamDetails.ReadOnly = true;
            this.txtExamDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExamDetails.Size = new System.Drawing.Size(420, 396);
            this.txtExamDetails.TabIndex = 0;
            // 
            // btnRequestExam
            // 
            this.btnRequestExam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequestExam.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRequestExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestExam.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRequestExam.ForeColor = System.Drawing.Color.White;
            this.btnRequestExam.Location = new System.Drawing.Point(550, 540);
            this.btnRequestExam.Name = "btnRequestExam";
            this.btnRequestExam.Size = new System.Drawing.Size(220, 50);
            this.btnRequestExam.TabIndex = 3;
            this.btnRequestExam.Text = "✓ Yêu cầu xét nghiệm";
            this.btnRequestExam.UseVisualStyleBackColor = false;
            this.btnRequestExam.Click += new System.EventHandler(this.btnRequestExam_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(780, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(220, 50);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "✗ Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ExaminationSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 620);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRequestExam);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpExaminations);
            this.Controls.Add(this.lblTitle);
            this.MinimizeBox = false;
            this.Name = "ExaminationSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HeathEd - Chọn xét nghiệm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExaminationSelectionForm_Load);
            this.grpExaminations.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
