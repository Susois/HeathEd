using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    partial class AddCaseStudyForm
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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpCaseInfo = new System.Windows.Forms.GroupBox();
            this.cboDifficultyLevel = new System.Windows.Forms.ComboBox();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.chkIsInteractive = new System.Windows.Forms.CheckBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.cboModule = new System.Windows.Forms.ComboBox();
            this.lblModule = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.txtSymptoms = new System.Windows.Forms.TextBox();
            this.lblSymptoms = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtCaseTitle = new System.Windows.Forms.TextBox();
            this.lblCaseTitle = new System.Windows.Forms.Label();
            this.grpPatientInfo = new System.Windows.Forms.GroupBox();
            this.txtPatientHistory = new System.Windows.Forms.TextBox();
            this.lblPatientHistory = new System.Windows.Forms.Label();
            this.cboPatientGender = new System.Windows.Forms.ComboBox();
            this.lblPatientGender = new System.Windows.Forms.Label();
            this.txtPatientAge = new System.Windows.Forms.TextBox();
            this.lblPatientAge = new System.Windows.Forms.Label();
            this.grpExamResults = new System.Windows.Forms.GroupBox();
            this.btnRemoveExamResult = new System.Windows.Forms.Button();
            this.lstExamResults = new System.Windows.Forms.ListBox();
            this.lblAddedExams = new System.Windows.Forms.Label();
            this.btnAddExamResult = new System.Windows.Forms.Button();
            this.txtInterpretation = new System.Windows.Forms.TextBox();
            this.lblInterpretation = new System.Windows.Forms.Label();
            this.txtNormalRange = new System.Windows.Forms.TextBox();
            this.lblNormalRange = new System.Windows.Forms.Label();
            this.txtResultData = new System.Windows.Forms.TextBox();
            this.lblResultData = new System.Windows.Forms.Label();
            this.cboExamType = new System.Windows.Forms.ComboBox();
            this.lblExamType = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpCaseInfo.SuspendLayout();
            this.grpPatientInfo.SuspendLayout();
            this.grpExamResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(336, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÊM CA BỆNH MỚI";
            // 
            // grpCaseInfo
            // 
            this.grpCaseInfo.Controls.Add(this.cboDifficultyLevel);
            this.grpCaseInfo.Controls.Add(this.lblDifficulty);
            this.grpCaseInfo.Controls.Add(this.chkIsInteractive);
            this.grpCaseInfo.Controls.Add(this.chkIsActive);
            this.grpCaseInfo.Controls.Add(this.cboModule);
            this.grpCaseInfo.Controls.Add(this.lblModule);
            this.grpCaseInfo.Controls.Add(this.txtDiagnosis);
            this.grpCaseInfo.Controls.Add(this.lblDiagnosis);
            this.grpCaseInfo.Controls.Add(this.txtSymptoms);
            this.grpCaseInfo.Controls.Add(this.lblSymptoms);
            this.grpCaseInfo.Controls.Add(this.txtDescription);
            this.grpCaseInfo.Controls.Add(this.lblDescription);
            this.grpCaseInfo.Controls.Add(this.txtCaseTitle);
            this.grpCaseInfo.Controls.Add(this.lblCaseTitle);
            this.grpCaseInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpCaseInfo.Location = new System.Drawing.Point(30, 80);
            this.grpCaseInfo.Name = "grpCaseInfo";
            this.grpCaseInfo.Size = new System.Drawing.Size(600, 450);
            this.grpCaseInfo.TabIndex = 1;
            this.grpCaseInfo.TabStop = false;
            this.grpCaseInfo.Text = "Thông tin ca bệnh";
            // 
            // cboDifficultyLevel
            // 
            this.cboDifficultyLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDifficultyLevel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDifficultyLevel.FormattingEnabled = true;
            this.cboDifficultyLevel.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.cboDifficultyLevel.Location = new System.Drawing.Point(450, 405);
            this.cboDifficultyLevel.Name = "cboDifficultyLevel";
            this.cboDifficultyLevel.Size = new System.Drawing.Size(130, 36);
            this.cboDifficultyLevel.TabIndex = 13;
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDifficulty.Location = new System.Drawing.Point(370, 408);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(80, 28);
            this.lblDifficulty.TabIndex = 12;
            this.lblDifficulty.Text = "Độ khó:";
            // 
            // chkIsInteractive
            // 
            this.chkIsInteractive.AutoSize = true;
            this.chkIsInteractive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkIsInteractive.Location = new System.Drawing.Point(200, 407);
            this.chkIsInteractive.Name = "chkIsInteractive";
            this.chkIsInteractive.Size = new System.Drawing.Size(126, 32);
            this.chkIsInteractive.TabIndex = 11;
            this.chkIsInteractive.Text = "Tương tác";
            this.chkIsInteractive.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkIsActive.Location = new System.Drawing.Point(20, 407);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(133, 32);
            this.chkIsActive.TabIndex = 10;
            this.chkIsActive.Text = "Hoạt động";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // cboModule
            // 
            this.cboModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModule.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboModule.FormattingEnabled = true;
            this.cboModule.Location = new System.Drawing.Point(120, 355);
            this.cboModule.Name = "cboModule";
            this.cboModule.Size = new System.Drawing.Size(460, 36);
            this.cboModule.TabIndex = 9;
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblModule.Location = new System.Drawing.Point(15, 358);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(86, 28);
            this.lblModule.TabIndex = 8;
            this.lblModule.Text = "Lớp học:";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiagnosis.Location = new System.Drawing.Point(120, 285);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(460, 60);
            this.txtDiagnosis.TabIndex = 7;
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiagnosis.Location = new System.Drawing.Point(15, 288);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(110, 28);
            this.lblDiagnosis.TabIndex = 6;
            this.lblDiagnosis.Text = "Chẩn đoán:";
            // 
            // txtSymptoms
            // 
            this.txtSymptoms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSymptoms.Location = new System.Drawing.Point(120, 215);
            this.txtSymptoms.Multiline = true;
            this.txtSymptoms.Name = "txtSymptoms";
            this.txtSymptoms.Size = new System.Drawing.Size(460, 60);
            this.txtSymptoms.TabIndex = 5;
            // 
            // lblSymptoms
            // 
            this.lblSymptoms.AutoSize = true;
            this.lblSymptoms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSymptoms.Location = new System.Drawing.Point(15, 218);
            this.lblSymptoms.Name = "lblSymptoms";
            this.lblSymptoms.Size = new System.Drawing.Size(117, 28);
            this.lblSymptoms.TabIndex = 4;
            this.lblSymptoms.Text = "Triệu chứng:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(120, 105);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(460, 100);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.Location = new System.Drawing.Point(15, 108);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(68, 28);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Mô tả:";
            // 
            // txtCaseTitle
            // 
            this.txtCaseTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCaseTitle.Location = new System.Drawing.Point(120, 35);
            this.txtCaseTitle.Name = "txtCaseTitle";
            this.txtCaseTitle.Size = new System.Drawing.Size(460, 34);
            this.txtCaseTitle.TabIndex = 1;
            // 
            // lblCaseTitle
            // 
            this.lblCaseTitle.AutoSize = true;
            this.lblCaseTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCaseTitle.Location = new System.Drawing.Point(15, 38);
            this.lblCaseTitle.Name = "lblCaseTitle";
            this.lblCaseTitle.Size = new System.Drawing.Size(79, 28);
            this.lblCaseTitle.TabIndex = 0;
            this.lblCaseTitle.Text = "Tiêu đề:";
            // 
            // grpPatientInfo
            // 
            this.grpPatientInfo.Controls.Add(this.txtPatientHistory);
            this.grpPatientInfo.Controls.Add(this.lblPatientHistory);
            this.grpPatientInfo.Controls.Add(this.cboPatientGender);
            this.grpPatientInfo.Controls.Add(this.lblPatientGender);
            this.grpPatientInfo.Controls.Add(this.txtPatientAge);
            this.grpPatientInfo.Controls.Add(this.lblPatientAge);
            this.grpPatientInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPatientInfo.Location = new System.Drawing.Point(650, 80);
            this.grpPatientInfo.Name = "grpPatientInfo";
            this.grpPatientInfo.Size = new System.Drawing.Size(500, 180);
            this.grpPatientInfo.TabIndex = 2;
            this.grpPatientInfo.TabStop = false;
            this.grpPatientInfo.Text = "Thông tin bệnh nhân";
            // 
            // txtPatientHistory
            // 
            this.txtPatientHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPatientHistory.Location = new System.Drawing.Point(130, 105);
            this.txtPatientHistory.Multiline = true;
            this.txtPatientHistory.Name = "txtPatientHistory";
            this.txtPatientHistory.Size = new System.Drawing.Size(350, 60);
            this.txtPatientHistory.TabIndex = 5;
            // 
            // lblPatientHistory
            // 
            this.lblPatientHistory.AutoSize = true;
            this.lblPatientHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPatientHistory.Location = new System.Drawing.Point(15, 92);
            this.lblPatientHistory.Name = "lblPatientHistory";
            this.lblPatientHistory.Size = new System.Drawing.Size(126, 28);
            this.lblPatientHistory.TabIndex = 4;
            this.lblPatientHistory.Text = "Tiền sử bệnh:";
            // 
            // cboPatientGender
            // 
            this.cboPatientGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatientGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPatientGender.FormattingEnabled = true;
            this.cboPatientGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboPatientGender.Location = new System.Drawing.Point(320, 35);
            this.cboPatientGender.Name = "cboPatientGender";
            this.cboPatientGender.Size = new System.Drawing.Size(160, 36);
            this.cboPatientGender.TabIndex = 3;
            // 
            // lblPatientGender
            // 
            this.lblPatientGender.AutoSize = true;
            this.lblPatientGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPatientGender.Location = new System.Drawing.Point(230, 38);
            this.lblPatientGender.Name = "lblPatientGender";
            this.lblPatientGender.Size = new System.Drawing.Size(91, 28);
            this.lblPatientGender.TabIndex = 2;
            this.lblPatientGender.Text = "Giới tính:";
            // 
            // txtPatientAge
            // 
            this.txtPatientAge.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPatientAge.Location = new System.Drawing.Point(130, 35);
            this.txtPatientAge.Name = "txtPatientAge";
            this.txtPatientAge.Size = new System.Drawing.Size(80, 34);
            this.txtPatientAge.TabIndex = 1;
            // 
            // lblPatientAge
            // 
            this.lblPatientAge.AutoSize = true;
            this.lblPatientAge.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPatientAge.Location = new System.Drawing.Point(15, 38);
            this.lblPatientAge.Name = "lblPatientAge";
            this.lblPatientAge.Size = new System.Drawing.Size(54, 28);
            this.lblPatientAge.TabIndex = 0;
            this.lblPatientAge.Text = "Tuổi:";
            // 
            // grpExamResults
            // 
            this.grpExamResults.Controls.Add(this.btnRemoveExamResult);
            this.grpExamResults.Controls.Add(this.lstExamResults);
            this.grpExamResults.Controls.Add(this.lblAddedExams);
            this.grpExamResults.Controls.Add(this.btnAddExamResult);
            this.grpExamResults.Controls.Add(this.txtInterpretation);
            this.grpExamResults.Controls.Add(this.lblInterpretation);
            this.grpExamResults.Controls.Add(this.txtNormalRange);
            this.grpExamResults.Controls.Add(this.lblNormalRange);
            this.grpExamResults.Controls.Add(this.txtResultData);
            this.grpExamResults.Controls.Add(this.lblResultData);
            this.grpExamResults.Controls.Add(this.cboExamType);
            this.grpExamResults.Controls.Add(this.lblExamType);
            this.grpExamResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpExamResults.Location = new System.Drawing.Point(650, 270);
            this.grpExamResults.Name = "grpExamResults";
            this.grpExamResults.Size = new System.Drawing.Size(500, 350);
            this.grpExamResults.TabIndex = 3;
            this.grpExamResults.TabStop = false;
            this.grpExamResults.Text = "Kết quả xét nghiệm";
            // 
            // btnRemoveExamResult
            // 
            this.btnRemoveExamResult.BackColor = System.Drawing.Color.Crimson;
            this.btnRemoveExamResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveExamResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveExamResult.ForeColor = System.Drawing.Color.White;
            this.btnRemoveExamResult.Location = new System.Drawing.Point(400, 308);
            this.btnRemoveExamResult.Name = "btnRemoveExamResult";
            this.btnRemoveExamResult.Size = new System.Drawing.Size(80, 30);
            this.btnRemoveExamResult.TabIndex = 11;
            this.btnRemoveExamResult.Text = "Xóa";
            this.btnRemoveExamResult.UseVisualStyleBackColor = false;
            this.btnRemoveExamResult.Click += new System.EventHandler(this.btnRemoveExamResult_Click);
            // 
            // lstExamResults
            // 
            this.lstExamResults.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstExamResults.FormattingEnabled = true;
            this.lstExamResults.ItemHeight = 25;
            this.lstExamResults.Location = new System.Drawing.Point(20, 228);
            this.lstExamResults.Name = "lstExamResults";
            this.lstExamResults.Size = new System.Drawing.Size(370, 104);
            this.lstExamResults.TabIndex = 10;
            // 
            // lblAddedExams
            // 
            this.lblAddedExams.AutoSize = true;
            this.lblAddedExams.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddedExams.Location = new System.Drawing.Point(15, 200);
            this.lblAddedExams.Name = "lblAddedExams";
            this.lblAddedExams.Size = new System.Drawing.Size(178, 25);
            this.lblAddedExams.TabIndex = 9;
            this.lblAddedExams.Text = "Xét nghiệm đã thêm:";
            // 
            // btnAddExamResult
            // 
            this.btnAddExamResult.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddExamResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExamResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddExamResult.ForeColor = System.Drawing.Color.White;
            this.btnAddExamResult.Location = new System.Drawing.Point(360, 160);
            this.btnAddExamResult.Name = "btnAddExamResult";
            this.btnAddExamResult.Size = new System.Drawing.Size(120, 35);
            this.btnAddExamResult.TabIndex = 8;
            this.btnAddExamResult.Text = "Thêm XN";
            this.btnAddExamResult.UseVisualStyleBackColor = false;
            this.btnAddExamResult.Click += new System.EventHandler(this.btnAddExamResult_Click);
            // 
            // txtInterpretation
            // 
            this.txtInterpretation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtInterpretation.Location = new System.Drawing.Point(130, 160);
            this.txtInterpretation.Name = "txtInterpretation";
            this.txtInterpretation.Size = new System.Drawing.Size(220, 31);
            this.txtInterpretation.TabIndex = 7;
            // 
            // lblInterpretation
            // 
            this.lblInterpretation.AutoSize = true;
            this.lblInterpretation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInterpretation.Location = new System.Drawing.Point(15, 163);
            this.lblInterpretation.Name = "lblInterpretation";
            this.lblInterpretation.Size = new System.Drawing.Size(88, 25);
            this.lblInterpretation.TabIndex = 6;
            this.lblInterpretation.Text = "Giải thích:";
            // 
            // txtNormalRange
            // 
            this.txtNormalRange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNormalRange.Location = new System.Drawing.Point(130, 120);
            this.txtNormalRange.Name = "txtNormalRange";
            this.txtNormalRange.Size = new System.Drawing.Size(350, 31);
            this.txtNormalRange.TabIndex = 5;
            // 
            // lblNormalRange
            // 
            this.lblNormalRange.AutoSize = true;
            this.lblNormalRange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNormalRange.Location = new System.Drawing.Point(15, 123);
            this.lblNormalRange.Name = "lblNormalRange";
            this.lblNormalRange.Size = new System.Drawing.Size(85, 25);
            this.lblNormalRange.TabIndex = 4;
            this.lblNormalRange.Text = "Giá trị BT:";
            // 
            // txtResultData
            // 
            this.txtResultData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtResultData.Location = new System.Drawing.Point(130, 80);
            this.txtResultData.Name = "txtResultData";
            this.txtResultData.Size = new System.Drawing.Size(350, 31);
            this.txtResultData.TabIndex = 3;
            // 
            // lblResultData
            // 
            this.lblResultData.AutoSize = true;
            this.lblResultData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResultData.Location = new System.Drawing.Point(15, 83);
            this.lblResultData.Name = "lblResultData";
            this.lblResultData.Size = new System.Drawing.Size(76, 25);
            this.lblResultData.TabIndex = 2;
            this.lblResultData.Text = "Kết quả:";
            // 
            // cboExamType
            // 
            this.cboExamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExamType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboExamType.FormattingEnabled = true;
            this.cboExamType.Location = new System.Drawing.Point(130, 35);
            this.cboExamType.Name = "cboExamType";
            this.cboExamType.Size = new System.Drawing.Size(350, 33);
            this.cboExamType.TabIndex = 1;
            // 
            // lblExamType
            // 
            this.lblExamType.AutoSize = true;
            this.lblExamType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExamType.Location = new System.Drawing.Point(15, 38);
            this.lblExamType.Name = "lblExamType";
            this.lblExamType.Size = new System.Drawing.Size(141, 25);
            this.lblExamType.TabIndex = 0;
            this.lblExamType.Text = "Loại xét nghiệm:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(850, 640);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 50);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1010, 640);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 50);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddCaseStudyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpExamResults);
            this.Controls.Add(this.grpPatientInfo);
            this.Controls.Add(this.grpCaseInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCaseStudyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HeathEd - Thêm ca bệnh mới";
            this.Load += new System.EventHandler(this.AddCaseStudyForm_Load);
            this.grpCaseInfo.ResumeLayout(false);
            this.grpCaseInfo.PerformLayout();
            this.grpPatientInfo.ResumeLayout(false);
            this.grpPatientInfo.PerformLayout();
            this.grpExamResults.ResumeLayout(false);
            this.grpExamResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpCaseInfo;
        private System.Windows.Forms.Label lblCaseTitle;
        private System.Windows.Forms.TextBox txtCaseTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblSymptoms;
        private System.Windows.Forms.TextBox txtSymptoms;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.ComboBox cboModule;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.CheckBox chkIsInteractive;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.ComboBox cboDifficultyLevel;
        private System.Windows.Forms.GroupBox grpPatientInfo;
        private System.Windows.Forms.Label lblPatientAge;
        private System.Windows.Forms.TextBox txtPatientAge;
        private System.Windows.Forms.Label lblPatientGender;
        private System.Windows.Forms.ComboBox cboPatientGender;
        private System.Windows.Forms.Label lblPatientHistory;
        private System.Windows.Forms.TextBox txtPatientHistory;
        private System.Windows.Forms.GroupBox grpExamResults;
        private System.Windows.Forms.Label lblExamType;
        private System.Windows.Forms.ComboBox cboExamType;
        private System.Windows.Forms.Label lblResultData;
        private System.Windows.Forms.TextBox txtResultData;
        private System.Windows.Forms.Label lblNormalRange;
        private System.Windows.Forms.TextBox txtNormalRange;
        private System.Windows.Forms.Label lblInterpretation;
        private System.Windows.Forms.TextBox txtInterpretation;
        private System.Windows.Forms.Button btnAddExamResult;
        private System.Windows.Forms.Label lblAddedExams;
        private System.Windows.Forms.ListBox lstExamResults;
        private System.Windows.Forms.Button btnRemoveExamResult;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
