using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace HeathEd
{
    public class GeminiRagService
    {
        private readonly string apiKey;
        private readonly HttpClient httpClient;
        private string fileSearchStoreName;
        private List<string> uploadedFiles = new List<string>();
        private List<string> uploadedFileUris = new List<string>();

        public GeminiRagService(string apiKey)
        {
            this.apiKey = apiKey;
            this.httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(10);
        }

        // 1. Tạo File Search Store
        public async Task<string> CreateFileSearchStoreAsync(string displayName)
        {
            var url = $"https://generativelanguage.googleapis.com/v1beta/corpora?key={apiKey}";

            var body = new
            {
                display_name = displayName
            };

            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Lỗi tạo corpus: {responseContent}");
            }

            var json = JObject.Parse(responseContent);
            fileSearchStoreName = json["name"].ToString();
            return fileSearchStoreName;
        }

        // 2. Upload file PDF và tạo document trong corpus
        public async Task<string> UploadAndIndexPdfAsync(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            var fileBytes = File.ReadAllBytes(filePath);

            // Bước 1: Khởi tạo resumable upload
            var initUrl = $"https://generativelanguage.googleapis.com/upload/v1beta/files?key={apiKey}";

            var metadata = new
            {
                file = new
                {
                    display_name = fileName
                }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, initUrl);
            request.Headers.Add("X-Goog-Upload-Protocol", "resumable");
            request.Headers.Add("X-Goog-Upload-Command", "start");
            request.Headers.Add("X-Goog-Upload-Header-Content-Length", fileBytes.Length.ToString());
            request.Headers.Add("X-Goog-Upload-Header-Content-Type", "application/pdf");
            request.Content = new StringContent(JsonConvert.SerializeObject(metadata), Encoding.UTF8, "application/json");

            var initResponse = await httpClient.SendAsync(request);

            if (!initResponse.IsSuccessStatusCode)
            {
                var errorContent = await initResponse.Content.ReadAsStringAsync();
                throw new Exception($"Lỗi khởi tạo upload: {errorContent}");
            }

            // Lấy upload URL từ header
            string uploadUrl = "";
            if (initResponse.Headers.TryGetValues("X-Goog-Upload-URL", out var urls))
            {
                uploadUrl = urls.First();
            }
            else
            {
                throw new Exception("Không tìm thấy upload URL");
            }

            // Bước 2: Upload file content
            var uploadRequest = new HttpRequestMessage(HttpMethod.Post, uploadUrl);
            uploadRequest.Headers.Add("X-Goog-Upload-Command", "upload, finalize");
            uploadRequest.Headers.Add("X-Goog-Upload-Offset", "0");
            uploadRequest.Content = new ByteArrayContent(fileBytes);
            uploadRequest.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");

            var uploadResponse = await httpClient.SendAsync(uploadRequest);
            var uploadResult = await uploadResponse.Content.ReadAsStringAsync();

            if (!uploadResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Lỗi upload file: {uploadResult}");
            }

            var uploadJson = JObject.Parse(uploadResult);
            var geminiFileName = uploadJson["file"]["name"].ToString();
            var fileUri = uploadJson["file"]["uri"].ToString();

            uploadedFiles.Add(geminiFileName);

            // Lưu file URI để sử dụng khi chat
            if (!uploadedFileUris.Contains(fileUri))
            {
                uploadedFileUris.Add(fileUri);
            }

            return geminiFileName;
        }

        // 3. Chat với RAG - sử dụng file đã upload
        public async Task<string> ChatWithRAGAsync(string userMessage)
        {
            var generateUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={apiKey}";

            // Tạo parts với file references nếu có
            var contentParts = new List<object>();

            // Thêm các file đã upload
            foreach (var fileUri in uploadedFileUris)
            {
                contentParts.Add(new
                {
                    file_data = new
                    {
                        file_uri = fileUri
                    }
                });
            }

            // Thêm câu hỏi của user
            contentParts.Add(new { text = userMessage });

            var generateBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = contentParts.ToArray()
                    }
                },
                systemInstruction = new
                {
                    parts = new[]
                    {
                        new
                        {
                            text = @"Ban la tro ly y te thong minh cua he thong HeathEd.
                            Nhiem vu cua ban la tra loi cac cau hoi ve y khoa dua tren tai lieu PDF da duoc cung cap.
                            - Tra loi bang tieng Viet
                            - Neu khong tim thay thong tin trong tai lieu, hay noi ro dieu do
                            - Dua ra cau tra loi chinh xac, ngan gon va de hieu
                            - Neu can, hay giai thich them cac thuat ngu y khoa
                            - Trich dan nguon tu tai lieu khi co the"
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = 0.3,
                    maxOutputTokens = 4096
                }
            };

            var generateContent = new StringContent(JsonConvert.SerializeObject(generateBody), Encoding.UTF8, "application/json");
            var generateResponse = await httpClient.PostAsync(generateUrl, generateContent);
            var generateResult = await generateResponse.Content.ReadAsStringAsync();

            if (!generateResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Lỗi generate: {generateResult}");
            }

            var generateJson = JObject.Parse(generateResult);
            var responseText = generateJson["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

            return responseText ?? "Khong the tao cau tra loi.";
        }

        // 4. Chat đơn giản với Gemini (không RAG)
        public async Task<string> SimpleChatAsync(string userMessage)
        {
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={apiKey}";

            var body = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = userMessage }
                        }
                    }
                },
                systemInstruction = new
                {
                    parts = new[]
                    {
                        new
                        {
                            text = @"Bạn là trợ lý y tế thông minh của hệ thống HeathEd.
                            Trả lời các câu hỏi về y khoa bằng tiếng Việt.
                            Đưa ra câu trả lời chính xác, ngắn gọn và dễ hiểu."
                        }
                    }
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Lỗi: {responseContent}");
            }

            var json = JObject.Parse(responseContent);
            return json["candidates"][0]["content"]["parts"][0]["text"].ToString();
        }

        public bool IsInitialized => !string.IsNullOrEmpty(fileSearchStoreName);
    }
}
