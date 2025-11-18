using System.Drawing;
using System.Windows.Forms;

namespace HeathEd
{
    partial class ChatbotForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlApiKey = new System.Windows.Forms.Panel();
            this.btnOpenPdfFolder = new System.Windows.Forms.Button();
            this.btnSimpleChat = new System.Windows.Forms.Button();
            this.btnInitRAG = new System.Windows.Forms.Button();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.txtChat = new System.Windows.Forms.RichTextBox();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlApiKey.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(500, 50);
            this.pnlHeader.TabIndex = 0;
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(460, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(252, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHATBOT Y TE - HeathEd";
            //
            // pnlApiKey
            //
            this.pnlApiKey.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlApiKey.Controls.Add(this.btnOpenPdfFolder);
            this.pnlApiKey.Controls.Add(this.btnSimpleChat);
            this.pnlApiKey.Controls.Add(this.btnInitRAG);
            this.pnlApiKey.Controls.Add(this.txtApiKey);
            this.pnlApiKey.Controls.Add(this.lblApiKey);
            this.pnlApiKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlApiKey.Location = new System.Drawing.Point(0, 50);
            this.pnlApiKey.Name = "pnlApiKey";
            this.pnlApiKey.Size = new System.Drawing.Size(500, 90);
            this.pnlApiKey.TabIndex = 1;
            //
            // btnOpenPdfFolder
            //
            this.btnOpenPdfFolder.BackColor = System.Drawing.Color.Gray;
            this.btnOpenPdfFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenPdfFolder.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnOpenPdfFolder.ForeColor = System.Drawing.Color.White;
            this.btnOpenPdfFolder.Location = new System.Drawing.Point(380, 50);
            this.btnOpenPdfFolder.Name = "btnOpenPdfFolder";
            this.btnOpenPdfFolder.Size = new System.Drawing.Size(110, 30);
            this.btnOpenPdfFolder.TabIndex = 4;
            this.btnOpenPdfFolder.Text = "Mo thu muc PDF";
            this.btnOpenPdfFolder.UseVisualStyleBackColor = false;
            this.btnOpenPdfFolder.Click += new System.EventHandler(this.btnOpenPdfFolder_Click);
            //
            // btnSimpleChat
            //
            this.btnSimpleChat.BackColor = System.Drawing.Color.Orange;
            this.btnSimpleChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpleChat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSimpleChat.ForeColor = System.Drawing.Color.White;
            this.btnSimpleChat.Location = new System.Drawing.Point(240, 50);
            this.btnSimpleChat.Name = "btnSimpleChat";
            this.btnSimpleChat.Size = new System.Drawing.Size(130, 30);
            this.btnSimpleChat.TabIndex = 3;
            this.btnSimpleChat.Text = "Chat don gian";
            this.btnSimpleChat.UseVisualStyleBackColor = false;
            this.btnSimpleChat.Click += new System.EventHandler(this.btnSimpleChat_Click);
            //
            // btnInitRAG
            //
            this.btnInitRAG.BackColor = System.Drawing.Color.ForestGreen;
            this.btnInitRAG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInitRAG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInitRAG.ForeColor = System.Drawing.Color.White;
            this.btnInitRAG.Location = new System.Drawing.Point(100, 50);
            this.btnInitRAG.Name = "btnInitRAG";
            this.btnInitRAG.Size = new System.Drawing.Size(130, 30);
            this.btnInitRAG.TabIndex = 2;
            this.btnInitRAG.Text = "Khoi tao RAG";
            this.btnInitRAG.UseVisualStyleBackColor = false;
            this.btnInitRAG.Click += new System.EventHandler(this.btnInitRAG_Click);
            //
            // txtApiKey
            //
            this.txtApiKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApiKey.Location = new System.Drawing.Point(100, 10);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.PasswordChar = '*';
            this.txtApiKey.Size = new System.Drawing.Size(390, 30);
            this.txtApiKey.TabIndex = 1;
            //
            // lblApiKey
            //
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblApiKey.Location = new System.Drawing.Point(10, 13);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(84, 23);
            this.lblApiKey.TabIndex = 0;
            this.lblApiKey.Text = "API Key:";
            //
            // txtChat
            //
            this.txtChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChat.BackColor = System.Drawing.Color.White;
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtChat.Location = new System.Drawing.Point(10, 150);
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(480, 380);
            this.txtChat.TabIndex = 2;
            this.txtChat.Text = "";
            //
            // pnlInput
            //
            this.pnlInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInput.Controls.Add(this.btnClear);
            this.pnlInput.Controls.Add(this.btnSend);
            this.pnlInput.Controls.Add(this.txtMessage);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInput.Location = new System.Drawing.Point(0, 540);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(500, 60);
            this.pnlInput.TabIndex = 3;
            //
            // btnClear
            //
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(430, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 40);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Xoa";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnSend
            //
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(360, 10);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(65, 40);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Gui";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            //
            // txtMessage
            //
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMessage.Location = new System.Drawing.Point(10, 15);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(345, 32);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            //
            // ChatbotForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.pnlApiKey);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChatbotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chatbot Y Te";
            this.Load += new System.EventHandler(this.ChatbotForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlApiKey.ResumeLayout(false);
            this.pnlApiKey.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlApiKey;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Button btnInitRAG;
        private System.Windows.Forms.Button btnSimpleChat;
        private System.Windows.Forms.Button btnOpenPdfFolder;
        private System.Windows.Forms.RichTextBox txtChat;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
    }
}
