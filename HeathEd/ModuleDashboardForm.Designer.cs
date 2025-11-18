namespace HeathEd
{
    partial class ModuleDashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblModuleName = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblActiveStudents = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNoAttempt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblAvgScore = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressAccuracy = new System.Windows.Forms.ProgressBar();
            this.lblAccuracyRate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressCompletion = new System.Windows.Forms.ProgressBar();
            this.lblCompletionRate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelStudents = new System.Windows.Forms.Panel();
            this.dgvStudentProgress = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCharts = new System.Windows.Forms.Panel();
            this.chartAccuracy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCompletion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelTop.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentProgress)).BeginInit();
            this.panelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAccuracy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCompletion)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.lblModuleName);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1125, 70);
            this.panelTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(860, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Lam moi";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.IndianRed;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(990, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Dong";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblModuleName
            // 
            this.lblModuleName.AutoSize = true;
            this.lblModuleName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblModuleName.ForeColor = System.Drawing.Color.White;
            this.lblModuleName.Location = new System.Drawing.Point(20, 18);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(203, 48);
            this.lblModuleName.TabIndex = 0;
            this.lblModuleName.Text = "Dashboard";
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.groupBox6);
            this.panelStats.Controls.Add(this.groupBox1);
            this.panelStats.Controls.Add(this.groupBox2);
            this.panelStats.Controls.Add(this.groupBox5);
            this.panelStats.Controls.Add(this.groupBox4);
            this.panelStats.Controls.Add(this.groupBox3);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 70);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.panelStats.Size = new System.Drawing.Size(1125, 180);
            this.panelStats.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblTotalStudents);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox6.Location = new System.Drawing.Point(30, 30);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(170, 130);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tổng quan";
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalStudents.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.lblTotalStudents.Location = new System.Drawing.Point(15, 60);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(140, 67);
            this.lblTotalStudents.TabIndex = 1;
            this.lblTotalStudents.Text = "0";
            this.lblTotalStudents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sinh viên";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblActiveStudents);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox1.Location = new System.Drawing.Point(220, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hoạt động";
            // 
            // lblActiveStudents
            // 
            this.lblActiveStudents.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblActiveStudents.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblActiveStudents.Location = new System.Drawing.Point(15, 60);
            this.lblActiveStudents.Name = "lblActiveStudents";
            this.lblActiveStudents.Size = new System.Drawing.Size(140, 67);
            this.lblActiveStudents.TabIndex = 1;
            this.lblActiveStudents.Text = "0";
            this.lblActiveStudents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(15, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Đã làm bài";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNoAttempt);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox2.Location = new System.Drawing.Point(410, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 130);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chưa làm";
            // 
            // lblNoAttempt
            // 
            this.lblNoAttempt.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblNoAttempt.ForeColor = System.Drawing.Color.IndianRed;
            this.lblNoAttempt.Location = new System.Drawing.Point(15, 60);
            this.lblNoAttempt.Name = "lblNoAttempt";
            this.lblNoAttempt.Size = new System.Drawing.Size(140, 67);
            this.lblNoAttempt.TabIndex = 1;
            this.lblNoAttempt.Text = "0";
            this.lblNoAttempt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(15, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Chưa làm bài nào";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblAvgScore);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox5.Location = new System.Drawing.Point(940, 30);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(150, 130);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Điểm số";
            // 
            // lblAvgScore
            // 
            this.lblAvgScore.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAvgScore.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lblAvgScore.Location = new System.Drawing.Point(15, 60);
            this.lblAvgScore.Name = "lblAvgScore";
            this.lblAvgScore.Size = new System.Drawing.Size(120, 55);
            this.lblAvgScore.TabIndex = 1;
            this.lblAvgScore.Text = "0.00";
            this.lblAvgScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(15, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Điểm TB";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.progressAccuracy);
            this.groupBox4.Controls.Add(this.lblAccuracyRate);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox4.Location = new System.Drawing.Point(770, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(150, 130);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Đoán đúng";
            // 
            // progressAccuracy
            // 
            this.progressAccuracy.Location = new System.Drawing.Point(15, 95);
            this.progressAccuracy.Name = "progressAccuracy";
            this.progressAccuracy.Size = new System.Drawing.Size(120, 20);
            this.progressAccuracy.TabIndex = 2;
            // 
            // lblAccuracyRate
            // 
            this.lblAccuracyRate.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAccuracyRate.ForeColor = System.Drawing.Color.Coral;
            this.lblAccuracyRate.Location = new System.Drawing.Point(15, 50);
            this.lblAccuracyRate.Name = "lblAccuracyRate";
            this.lblAccuracyRate.Size = new System.Drawing.Size(120, 54);
            this.lblAccuracyRate.TabIndex = 1;
            this.lblAccuracyRate.Text = "0%";
            this.lblAccuracyRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(15, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tỉ lệ %";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.progressCompletion);
            this.groupBox3.Controls.Add(this.lblCompletionRate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox3.Location = new System.Drawing.Point(600, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 130);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hoàn thành";
            // 
            // progressCompletion
            // 
            this.progressCompletion.Location = new System.Drawing.Point(15, 95);
            this.progressCompletion.Name = "progressCompletion";
            this.progressCompletion.Size = new System.Drawing.Size(120, 20);
            this.progressCompletion.TabIndex = 2;
            this.progressCompletion.Click += new System.EventHandler(this.progressCompletion_Click);
            // 
            // lblCompletionRate
            // 
            this.lblCompletionRate.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCompletionRate.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCompletionRate.Location = new System.Drawing.Point(15, 50);
            this.lblCompletionRate.Name = "lblCompletionRate";
            this.lblCompletionRate.Size = new System.Drawing.Size(120, 54);
            this.lblCompletionRate.TabIndex = 1;
            this.lblCompletionRate.Text = "0%";
            this.lblCompletionRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(15, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tỉ lệ %";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelStudents);
            this.panelContent.Controls.Add(this.panelCharts);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 250);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1125, 350);
            this.panelContent.TabIndex = 2;
            // 
            // panelStudents
            // 
            this.panelStudents.Controls.Add(this.dgvStudentProgress);
            this.panelStudents.Controls.Add(this.label2);
            this.panelStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStudents.Location = new System.Drawing.Point(0, 0);
            this.panelStudents.Name = "panelStudents";
            this.panelStudents.Padding = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.panelStudents.Size = new System.Drawing.Size(625, 350);
            this.panelStudents.TabIndex = 0;
            // 
            // dgvStudentProgress
            // 
            this.dgvStudentProgress.AllowUserToAddRows = false;
            this.dgvStudentProgress.AllowUserToDeleteRows = false;
            this.dgvStudentProgress.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStudentProgress.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudentProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudentProgress.Location = new System.Drawing.Point(20, 52);
            this.dgvStudentProgress.Name = "dgvStudentProgress";
            this.dgvStudentProgress.ReadOnly = true;
            this.dgvStudentProgress.RowHeadersWidth = 51;
            this.dgvStudentProgress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudentProgress.Size = new System.Drawing.Size(595, 288);
            this.dgvStudentProgress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 10);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label2.Size = new System.Drawing.Size(209, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tiến độ sinh viên";
            // 
            // panelCharts
            // 
            this.panelCharts.Controls.Add(this.chartAccuracy);
            this.panelCharts.Controls.Add(this.chartCompletion);
            this.panelCharts.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCharts.Location = new System.Drawing.Point(625, 0);
            this.panelCharts.Name = "panelCharts";
            this.panelCharts.Padding = new System.Windows.Forms.Padding(10);
            this.panelCharts.Size = new System.Drawing.Size(500, 350);
            this.panelCharts.TabIndex = 1;
            // 
            // chartAccuracy
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAccuracy.ChartAreas.Add(chartArea1);
            this.chartAccuracy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartAccuracy.Location = new System.Drawing.Point(10, 10);
            this.chartAccuracy.Name = "chartAccuracy";
            this.chartAccuracy.Size = new System.Drawing.Size(480, 330);
            this.chartAccuracy.TabIndex = 1;
            this.chartAccuracy.Text = "chart2";
            this.chartAccuracy.Click += new System.EventHandler(this.chartAccuracy_Click);
            // 
            // chartCompletion
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCompletion.ChartAreas.Add(chartArea2);
            this.chartCompletion.Location = new System.Drawing.Point(10, 10);
            this.chartCompletion.Name = "chartCompletion";
            this.chartCompletion.Size = new System.Drawing.Size(480, 160);
            this.chartCompletion.TabIndex = 0;
            this.chartCompletion.Text = "chart1";
            // 
            // ModuleDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelTop);
            this.Name = "ModuleDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Lớp học - HeathEd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ModuleDashboardForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelStudents.ResumeLayout(false);
            this.panelStudents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentProgress)).EndInit();
            this.panelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAccuracy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCompletion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblModuleName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblActiveStudents;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblNoAttempt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressCompletion;
        private System.Windows.Forms.Label lblCompletionRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ProgressBar progressAccuracy;
        private System.Windows.Forms.Label lblAccuracyRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblAvgScore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelStudents;
        private System.Windows.Forms.DataGridView dgvStudentProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAccuracy;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCompletion;
    }
}
