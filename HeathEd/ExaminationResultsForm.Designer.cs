using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    partial class ExaminationResultsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private GroupBox grpExamList;
        private DataGridView dgvExaminations;
        private Label lblExamCount;
        private GroupBox grpResults;
        private TextBox txtResults;
        private PictureBox picImage;
        private Label lblImageInfo;
        private Button btnPrint;
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpExamList = new System.Windows.Forms.GroupBox();
            this.dgvExaminations = new System.Windows.Forms.DataGridView();
            this.lblExamCount = new System.Windows.Forms.Label();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblImageInfo = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpExamList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminations)).BeginInit();
            this.grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "KẾT QUẢ XÉT NGHIỆM";
            //
            // grpExamList
            //
            this.grpExamList.Controls.Add(this.lblExamCount);
            this.grpExamList.Controls.Add(this.dgvExaminations);
            this.grpExamList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpExamList.Location = new System.Drawing.Point(30, 70);
            this.grpExamList.Name = "grpExamList";
            this.grpExamList.Size = new System.Drawing.Size(650, 350);
            this.grpExamList.TabIndex = 1;
            this.grpExamList.TabStop = false;
            this.grpExamList.Text = "Danh sách xét nghiệm đã yêu cầu";
            //
            // dgvExaminations
            //
            this.dgvExaminations.AllowUserToAddRows = false;
            this.dgvExaminations.AllowUserToDeleteRows = false;
            this.dgvExaminations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExaminations.BackgroundColor = System.Drawing.Color.White;
            this.dgvExaminations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExaminations.Location = new System.Drawing.Point(15, 35);
            this.dgvExaminations.MultiSelect = false;
            this.dgvExaminations.Name = "dgvExaminations";
            this.dgvExaminations.ReadOnly = true;
            this.dgvExaminations.RowHeadersWidth = 62;
            this.dgvExaminations.RowTemplate.Height = 28;
            this.dgvExaminations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExaminations.Size = new System.Drawing.Size(620, 270);
            this.dgvExaminations.TabIndex = 0;
            this.dgvExaminations.SelectionChanged += new System.EventHandler(this.dgvExaminations_SelectionChanged);
            //
            // lblExamCount
            //
            this.lblExamCount.AutoSize = true;
            this.lblExamCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExamCount.Location = new System.Drawing.Point(15, 315);
            this.lblExamCount.Name = "lblExamCount";
            this.lblExamCount.Size = new System.Drawing.Size(200, 25);
            this.lblExamCount.TabIndex = 1;
            this.lblExamCount.Text = "Tổng số xét nghiệm: 0";
            //
            // grpResults
            //
            this.grpResults.Controls.Add(this.lblImageInfo);
            this.grpResults.Controls.Add(this.picImage);
            this.grpResults.Controls.Add(this.txtResults);
            this.grpResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpResults.Location = new System.Drawing.Point(700, 70);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(550, 600);
            this.grpResults.TabIndex = 2;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Chi tiết kết quả";
            //
            // txtResults
            //
            this.txtResults.BackColor = System.Drawing.Color.White;
            this.txtResults.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtResults.Location = new System.Drawing.Point(15, 35);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(520, 350);
            this.txtResults.TabIndex = 0;
            //
            // picImage
            //
            this.picImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(15, 420);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(520, 150);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            //
            // lblImageInfo
            //
            this.lblImageInfo.AutoSize = true;
            this.lblImageInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImageInfo.Location = new System.Drawing.Point(15, 395);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(150, 25);
            this.lblImageInfo.TabIndex = 2;
            this.lblImageInfo.Text = "Hình ảnh kết quả:";
            this.lblImageInfo.Visible = false;
            //
            // btnPrint
            //
            this.btnPrint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(30, 440);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(200, 50);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "🖨️ In kết quả";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            //
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(480, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 50);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // ExaminationResultsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 700);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.grpExamList);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExaminationResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HeathEd - Kết quả xét nghiệm";
            this.Load += new System.EventHandler(this.ExaminationResultsForm_Load);
            this.grpExamList.ResumeLayout(false);
            this.grpExamList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminations)).EndInit();
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
