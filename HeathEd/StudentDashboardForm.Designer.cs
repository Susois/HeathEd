namespace HeathEd
{
    partial class StudentDashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalAttempts = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalModules = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.dgvAttemptHistory = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelChart = new System.Windows.Forms.Panel();
            this.chartPerformance = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttemptHistory)).BeginInit();
            this.panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformance)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.lblTitle);
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
            this.btnRefresh.Location = new System.Drawing.Point(1140, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm mới";
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
            this.btnClose.Location = new System.Drawing.Point(880, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(372, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard Sinh Viên";
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.groupBox5);
            this.panelStats.Controls.Add(this.groupBox4);
            this.panelStats.Controls.Add(this.groupBox3);
            this.panelStats.Controls.Add(this.groupBox2);
            this.panelStats.Controls.Add(this.groupBox1);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 70);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.panelStats.Size = new System.Drawing.Size(1125, 200);
            this.panelStats.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblAvgScore);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox5.Location = new System.Drawing.Point(1117, 30);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(250, 157);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Điểm số";
            // 
            // lblAvgScore
            // 
            this.lblAvgScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvgScore.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblAvgScore.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lblAvgScore.Location = new System.Drawing.Point(15, 60);
            this.lblAvgScore.Name = "lblAvgScore";
            this.lblAvgScore.Size = new System.Drawing.Size(220, 88);
            this.lblAvgScore.TabIndex = 1;
            this.lblAvgScore.Text = "0.00";
            this.lblAvgScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.Location = new System.Drawing.Point(15, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 28);
            this.label9.TabIndex = 0;
            this.label9.Text = "Điểm trung bình";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.progressAccuracy);
            this.groupBox4.Controls.Add(this.lblAccuracyRate);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox4.Location = new System.Drawing.Point(840, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 157);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Độ chính xác";
            // 
            // progressAccuracy
            // 
            this.progressAccuracy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressAccuracy.Location = new System.Drawing.Point(15, 122);
            this.progressAccuracy.Name = "progressAccuracy";
            this.progressAccuracy.Size = new System.Drawing.Size(220, 20);
            this.progressAccuracy.TabIndex = 2;
            this.progressAccuracy.Click += new System.EventHandler(this.progressAccuracy_Click);
            // 
            // lblAccuracyRate
            // 
            this.lblAccuracyRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAccuracyRate.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblAccuracyRate.ForeColor = System.Drawing.Color.Coral;
            this.lblAccuracyRate.Location = new System.Drawing.Point(15, 58);
            this.lblAccuracyRate.Name = "lblAccuracyRate";
            this.lblAccuracyRate.Size = new System.Drawing.Size(220, 59);
            this.lblAccuracyRate.TabIndex = 1;
            this.lblAccuracyRate.Text = "0%";
            this.lblAccuracyRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAccuracyRate.Click += new System.EventHandler(this.lblAccuracyRate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(15, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tỉ lệ đoán đúng";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.progressCompletion);
            this.groupBox3.Controls.Add(this.lblCompletionRate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox3.Location = new System.Drawing.Point(570, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 157);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hoàn thành";
            // 
            // progressCompletion
            // 
            this.progressCompletion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressCompletion.Location = new System.Drawing.Point(15, 122);
            this.progressCompletion.Name = "progressCompletion";
            this.progressCompletion.Size = new System.Drawing.Size(220, 20);
            this.progressCompletion.TabIndex = 2;
            // 
            // lblCompletionRate
            // 
            this.lblCompletionRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompletionRate.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCompletionRate.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCompletionRate.Location = new System.Drawing.Point(15, 58);
            this.lblCompletionRate.Name = "lblCompletionRate";
            this.lblCompletionRate.Size = new System.Drawing.Size(220, 59);
            this.lblCompletionRate.TabIndex = 1;
            this.lblCompletionRate.Text = "0%";
            this.lblCompletionRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(15, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tỉ lệ hoàn thành bài tập";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalAttempts);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox2.Location = new System.Drawing.Point(300, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 157);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hoạt động";
            // 
            // lblTotalAttempts
            // 
            this.lblTotalAttempts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAttempts.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalAttempts.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTotalAttempts.Location = new System.Drawing.Point(7, 58);
            this.lblTotalAttempts.Name = "lblTotalAttempts";
            this.lblTotalAttempts.Size = new System.Drawing.Size(220, 84);
            this.lblTotalAttempts.TabIndex = 1;
            this.lblTotalAttempts.Text = "0";
            this.lblTotalAttempts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(15, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng lần làm bài";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalModules);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox1.Location = new System.Drawing.Point(30, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng quan";
            // 
            // lblTotalModules
            // 
            this.lblTotalModules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalModules.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalModules.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.lblTotalModules.Location = new System.Drawing.Point(20, 65);
            this.lblTotalModules.Name = "lblTotalModules";
            this.lblTotalModules.Size = new System.Drawing.Size(207, 84);
            this.lblTotalModules.TabIndex = 1;
            this.lblTotalModules.Text = "0";
            this.lblTotalModules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lớp học đã tham gia";
            // 
            // panelHistory
            // 
            this.panelHistory.Controls.Add(this.dgvAttemptHistory);
            this.panelHistory.Controls.Add(this.label2);
            this.panelHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHistory.Location = new System.Drawing.Point(0, 270);
            this.panelHistory.Name = "panelHistory";
            this.panelHistory.Padding = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.panelHistory.Size = new System.Drawing.Size(625, 330);
            this.panelHistory.TabIndex = 2;
            // 
            // dgvAttemptHistory
            // 
            this.dgvAttemptHistory.AllowUserToAddRows = false;
            this.dgvAttemptHistory.AllowUserToDeleteRows = false;
            this.dgvAttemptHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAttemptHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttemptHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttemptHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttemptHistory.Location = new System.Drawing.Point(20, 52);
            this.dgvAttemptHistory.Name = "dgvAttemptHistory";
            this.dgvAttemptHistory.ReadOnly = true;
            this.dgvAttemptHistory.RowHeadersWidth = 51;
            this.dgvAttemptHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttemptHistory.Size = new System.Drawing.Size(595, 268);
            this.dgvAttemptHistory.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 10);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label2.Size = new System.Drawing.Size(184, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lịch sử làm bài";
            // 
            // panelChart
            // 
            this.panelChart.Controls.Add(this.chartPerformance);
            this.panelChart.Controls.Add(this.label4);
            this.panelChart.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelChart.Location = new System.Drawing.Point(625, 270);
            this.panelChart.Name = "panelChart";
            this.panelChart.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.panelChart.Size = new System.Drawing.Size(500, 330);
            this.panelChart.TabIndex = 3;
            // 
            // chartPerformance
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPerformance.ChartAreas.Add(chartArea1);
            this.chartPerformance.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartPerformance.Legends.Add(legend1);
            this.chartPerformance.Location = new System.Drawing.Point(10, 52);
            this.chartPerformance.Name = "chartPerformance";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Score";
            this.chartPerformance.Series.Add(series1);
            this.chartPerformance.Size = new System.Drawing.Size(470, 268);
            this.chartPerformance.TabIndex = 1;
            this.chartPerformance.Text = "chart1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label4.Size = new System.Drawing.Size(222, 42);
            this.label4.TabIndex = 0;
            this.label4.Text = "Biểu đồ thành tích";
            // 
            // StudentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 600);
            this.Controls.Add(this.panelHistory);
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelTop);
            this.Name = "StudentDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Sinh Viên - HeathEd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StudentDashboardForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelHistory.ResumeLayout(false);
            this.panelHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttemptHistory)).EndInit();
            this.panelChart.ResumeLayout(false);
            this.panelChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalModules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalAttempts;
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
        private System.Windows.Forms.Panel panelHistory;
        private System.Windows.Forms.DataGridView dgvAttemptHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPerformance;
    }
}
