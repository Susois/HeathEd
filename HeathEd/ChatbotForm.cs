using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace HeathEd
{
    public partial class ChatbotForm : Form
    {
        private GeminiRagService ragService;
        private bool isInitialized = false;
        private string pdfFolderPath;
        private const string API_KEY = "AIzaSyDiXL6zmoafxGQEz0tPPhuwpkiVFOx_Kq4";

        public ChatbotForm()
        {
            InitializeComponent();
            // Tạo thư mục PDFs nếu chưa có
            pdfFolderPath = Path.Combine(Application.StartupPath, "PDFs");
            if (!Directory.Exists(pdfFolderPath))
            {
                Directory.CreateDirectory(pdfFolderPath);
            }
        }

        private async void ChatbotForm_Load(object sender, EventArgs e)
        {
            // Ẩn panel API Key vì đã có sẵn
            pnlApiKey.Visible = false;
            txtChat.Location = new Point(10, 60);
            txtChat.Height = txtChat.Height + 80;

            txtChat.AppendText("=== CHATBOT Y TE - HeathEd ===\r\n\r\n");
            txtChat.AppendText("Chao mung ban den voi tro ly y te thong minh!\r\n\r\n");

            // Tự động khởi tạo RAG
            await InitializeRAGAutomatically();
        }

        private async Task InitializeRAGAutomatically()
        {
            try
            {
                txtChat.AppendText("Dang khoi tao he thong RAG...\r\n");

                ragService = new GeminiRagService(API_KEY);

                // Tạo corpus
                txtChat.AppendText("Dang tao kho du lieu...\r\n");
                await ragService.CreateFileSearchStoreAsync($"HeathEd-{DateTime.Now:yyyyMMddHHmmss}");
                txtChat.AppendText("Da tao kho du lieu thanh cong!\r\n");

                // Upload các file PDF
                string[] pdfFiles = Directory.GetFiles(pdfFolderPath, "*.pdf");

                if (pdfFiles.Length == 0)
                {
                    txtChat.AppendText($"Khong tim thay file PDF trong thu muc: {pdfFolderPath}\r\n");
                    txtChat.AppendText("Ban co the them file PDF vao thu muc va khoi dong lai.\r\n");
                    txtChat.AppendText("Hoac chat truc tiep - chatbot se tra loi dua tren kien thuc chung.\r\n\r\n");
                }
                else
                {
                    txtChat.AppendText($"Tim thay {pdfFiles.Length} file PDF\r\n");

                    foreach (var pdf in pdfFiles)
                    {
                        string fileName = Path.GetFileName(pdf);
                        txtChat.AppendText($"Dang upload: {fileName}...\r\n");
                        txtChat.ScrollToCaret();

                        try
                        {
                            await ragService.UploadAndIndexPdfAsync(pdf);
                            txtChat.AppendText($"Hoan thanh: {fileName}\r\n");
                        }
                        catch (Exception ex)
                        {
                            txtChat.AppendText($"Loi upload {fileName}: {ex.Message}\r\n");
                        }
                    }
                }

                isInitialized = true;
                btnSend.Enabled = true;
                txtChat.AppendText("\r\n=== HE THONG SAN SANG ===\r\n");
                txtChat.AppendText("Ban co the bat dau dat cau hoi!\r\n\r\n");
                txtChat.ScrollToCaret();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                txtChat.AppendText($"Loi khoi tao: {ex.Message}\r\n");
                txtChat.AppendText("Chuyen sang che do chat don gian...\r\n\r\n");

                // Fallback to simple chat
                ragService = new GeminiRagService(API_KEY);
                isInitialized = false;
                btnSend.Enabled = true;
                txtMessage.Focus();
            }
        }

        private async void btnInitRAG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApiKey.Text))
            {
                MessageBox.Show("Vui lòng nhập Gemini API Key!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnInitRAG.Enabled = false;
                btnSimpleChat.Enabled = false;
                txtChat.AppendText("🔄 Đang khởi tạo hệ thống RAG...\r\n");

                ragService = new GeminiRagService(txtApiKey.Text.Trim());

                // Tạo corpus
                txtChat.AppendText("📁 Đang tạo kho dữ liệu...\r\n");
                await ragService.CreateFileSearchStoreAsync($"HeathEd-{DateTime.Now:yyyyMMddHHmmss}");
                txtChat.AppendText("✓ Đã tạo kho dữ liệu thành công!\r\n");

                // Upload các file PDF
                string[] pdfFiles = Directory.GetFiles(pdfFolderPath, "*.pdf");

                if (pdfFiles.Length == 0)
                {
                    txtChat.AppendText($"⚠️ Không tìm thấy file PDF trong thư mục: {pdfFolderPath}\r\n");
                    txtChat.AppendText("Bạn có thể chat đơn giản hoặc thêm file PDF vào thư mục.\r\n\r\n");
                }
                else
                {
                    txtChat.AppendText($"📚 Tìm thấy {pdfFiles.Length} file PDF\r\n");

                    foreach (var pdf in pdfFiles)
                    {
                        string fileName = Path.GetFileName(pdf);
                        txtChat.AppendText($"⏳ Đang upload: {fileName}...\r\n");
                        txtChat.ScrollToCaret();

                        try
                        {
                            await ragService.UploadAndIndexPdfAsync(pdf);
                            txtChat.AppendText($"✓ Hoàn thành: {fileName}\r\n");
                        }
                        catch (Exception ex)
                        {
                            txtChat.AppendText($"❌ Lỗi upload {fileName}: {ex.Message}\r\n");
                        }
                    }
                }

                isInitialized = true;
                btnSend.Enabled = true;
                txtChat.AppendText("\r\n=== HỆ THỐNG SẴN SÀNG ===\r\n");
                txtChat.AppendText("Bạn có thể bắt đầu đặt câu hỏi!\r\n\r\n");
                txtChat.ScrollToCaret();
            }
            catch (Exception ex)
            {
                txtChat.AppendText($"❌ Lỗi khởi tạo: {ex.Message}\r\n\r\n");
            }
            finally
            {
                btnInitRAG.Enabled = true;
                btnSimpleChat.Enabled = true;
            }
        }

        private void btnSimpleChat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApiKey.Text))
            {
                MessageBox.Show("Vui lòng nhập Gemini API Key!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ragService = new GeminiRagService(txtApiKey.Text.Trim());
            isInitialized = false; // Simple chat mode
            btnSend.Enabled = true;

            txtChat.AppendText("✓ Chế độ chat đơn giản đã được kích hoạt!\r\n");
            txtChat.AppendText("(Không sử dụng RAG - trả lời dựa trên kiến thức chung)\r\n\r\n");
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (ragService == null)
            {
                MessageBox.Show("Vui lòng khởi tạo chatbot trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            string userMessage = txtMessage.Text.Trim();
            txtChat.AppendText($"👤 BẠN: {userMessage}\r\n\r\n");
            txtMessage.Clear();
            txtChat.ScrollToCaret();

            try
            {
                btnSend.Enabled = false;
                txtChat.AppendText("🤖 CHATBOT: Đang xử lý...\r\n");
                txtChat.ScrollToCaret();

                string response;
                if (ragService.IsInitialized)
                {
                    // RAG mode
                    response = await ragService.ChatWithRAGAsync(userMessage);
                }
                else
                {
                    // Simple chat mode
                    response = await ragService.SimpleChatAsync(userMessage);
                }

                // Xóa dòng "Đang xử lý..."
                int lastIndex = txtChat.Text.LastIndexOf("🤖 CHATBOT: Đang xử lý...");
                if (lastIndex >= 0)
                {
                    txtChat.Text = txtChat.Text.Substring(0, lastIndex);
                }

                txtChat.AppendText($"🤖 CHATBOT: {response}\r\n\r\n");
                txtChat.AppendText("─────────────────────────────────────\r\n\r\n");
                txtChat.ScrollToCaret();
            }
            catch (Exception ex)
            {
                txtChat.AppendText($"❌ Lỗi: {ex.Message}\r\n\r\n");
            }
            finally
            {
                btnSend.Enabled = true;
                txtMessage.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtChat.Clear();
            txtChat.AppendText("=== CHATBOT Y TẾ - HeathEd ===\r\n\r\n");
            txtChat.AppendText("Lịch sử chat đã được xóa.\r\n\r\n");
        }

        private void btnOpenPdfFolder_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", pdfFolderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở thư mục: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                if (btnSend.Enabled)
                {
                    btnSend_Click(sender, e);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
