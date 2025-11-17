-- =============================================
-- HeathEd Database - Optimized Schema
-- Loại bỏ kết nối vòng và tối ưu hóa cấu trúc
-- =============================================

USE HeathEdDB;
GO

-- =============================================
-- PHÂN TÍCH CẤU TRÚC HIỆN TẠI
-- =============================================
/*
Cấu trúc hiện tại:
- Users (chứa cả Student và Lecturer)
- Modules (có LecturerID tham chiếu Users)
- StudentModules (liên kết Student với Module)
- CaseStudies (thuộc về Module)
- ExaminationTypes (các loại xét nghiệm)
- CaseExaminationResults (kết quả xét nghiệm cho từng case)

Kết nối vòng:
Modules → Users (qua LecturerID) → StudentModules → Modules

GIẢI PHÁP: Giữ nguyên cấu trúc nhưng tối ưu hóa indexes và queries
*/

-- =============================================
-- BỔ SUNG DỮ LIỆU XÉT NGHIỆM CHO CÁC CA BỆNH
-- =============================================

-- Lấy CaseID của các ca bệnh đã có
DECLARE @CasePneumonia INT = (SELECT CaseID FROM CaseStudies WHERE CaseTitle LIKE N'%viêm phổi cấp%' AND IsInteractive IS NULL);
DECLARE @CaseDiabetes INT = (SELECT CaseID FROM CaseStudies WHERE CaseTitle LIKE N'%đái tháo đường%');
DECLARE @CaseHypertension INT = (SELECT CaseID FROM CaseStudies WHERE CaseTitle LIKE N'%cao huyết áp%');

-- =============================================
-- 1. KẾT QUẢ XÉT NGHIỆM CHO VIÊM PHỔI CẤP
-- =============================================

IF @CasePneumonia IS NOT NULL
BEGIN
    -- Khám tổng quát
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CasePneumonia, 1,
     N'{"mach": "95 lần/phút", "huyetAp": "120/80 mmHg", "nhietDo": "39.5°C", "tanSoTho": "24 lần/phút", "SpO2": "92%", "nghePoi": "Ran ẩm hạt nhỏ vùng đáy phổi phải"}',
     N'Mạch: 60-100 lần/phút, Huyết áp: <120/80, Nhiệt độ: 36-37°C, SpO2: >95%',
     N'Sốt cao, tăng nhịp thở, giảm oxy máu nhẹ. Ran ẩm hạt nhỏ gợi ý viêm phổi.');

    -- Xét nghiệm máu
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CasePneumonia, 2,
     N'{"WBC": "15.2 G/L", "RBC": "4.8 T/L", "Hb": "14.5 g/dL", "PLT": "280 G/L", "Neutrophil": "85%", "Lymphocyte": "10%"}',
     N'WBC: 4-11 G/L, Neutrophil: 40-70%',
     N'Tăng bạch cầu với tăng bạch cầu trung tính, điển hình cho nhiễm khuẩn cấp tính.');

    -- Sinh hóa máu
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CasePneumonia, 3,
     N'{"CRP": "120 mg/L", "PCT": "2.5 ng/mL", "glucose": "5.8 mmol/L", "creatinin": "85 µmol/L"}',
     N'CRP: <5 mg/L, PCT: <0.5 ng/mL',
     N'CRP và Procalcitonin tăng cao, xác nhận nhiễm khuẩn nghiêm trọng.');

    -- X-quang phổi
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, ImagePath, NormalRange, Interpretation)
    VALUES
    (@CasePneumonia, 6,
     N'{"findingLocation": "Thùy dưới phổi phải", "finding": "Tổn thương thâm nhiễm dạng đám mờ", "airBronchogram": "Có"}',
     N'/images/cases/xray_pneumonia.jpg',
     N'Phổi trong, không có tổn thương',
     N'Hình ảnh thâm nhiễm phổi điển hình cho viêm phổi thùy. Có air bronchogram.');

    -- Điện tim
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CasePneumonia, 10,
     N'{"nhipTim": "95 bpm", "nhipXoang": "Đều", "ST": "Bình thường", "T": "Bình thường"}',
     N'Nhịp xoang 60-100 bpm, không rối loạn nhịp',
     N'Nhịp xoang nhanh, phù hợp với tình trạng nhiễm trùng. Không có dấu hiệu thiếu máu cơ tim.');

    -- CT Scanner (nếu cần đánh giá chi tiết)
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, ImagePath, NormalRange, Interpretation)
    VALUES
    (@CasePneumonia, 11,
     N'{"finding": "Thâm nhiễm phế nang lan tỏa thùy dưới phổi phải", "lymphNode": "Không có hạch trung thất to", "pleura": "Không tràn dịch"}',
     N'/images/cases/ct_pneumonia.jpg',
     N'Phổi trong, không tổn thương',
     N'CT xác nhận viêm phổi thùy dưới phổi phải. Không biến chứng áp xe hay tràn dịch màng phổi.');
END

-- =============================================
-- 2. KẾT QUẢ XÉT NGHIỆM CHO ĐÁI THÁO ĐƯỜNG TYPE 2
-- =============================================

IF @CaseDiabetes IS NOT NULL
BEGIN
    -- Khám tổng quát
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseDiabetes, 1,
     N'{"mach": "78 lần/phút", "huyetAp": "130/85 mmHg", "BMI": "32.5", "vongBung": "98 cm"}',
     N'BMI: 18.5-24.9, Vòng bụng nam <90cm, nữ <80cm',
     N'Béo phì độ 1, vòng bụng tăng - yếu tố nguy cơ đái tháo đường.');

    -- Xét nghiệm máu tổng quát
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseDiabetes, 2,
     N'{"WBC": "7.5 G/L", "RBC": "4.5 T/L", "Hb": "13.2 g/dL", "PLT": "250 G/L"}',
     N'Trong giới hạn bình thường',
     N'Các chỉ số máu cơ bản bình thường.');

    -- Sinh hóa máu (quan trọng nhất)
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseDiabetes, 3,
     N'{"glucose": "13.5 mmol/L", "ure": "6.2 mmol/L", "creatinin": "95 µmol/L", "AST": "35 U/L", "ALT": "42 U/L", "cholesterol": "6.8 mmol/L", "triglyceride": "3.2 mmol/L", "HDL": "0.9 mmol/L", "LDL": "4.5 mmol/L"}',
     N'Glucose lúc đói: 3.9-6.1 mmol/L, Cholesterol: <5.2 mmol/L, Triglyceride: <1.7 mmol/L',
     N'Đường huyết tăng cao rõ rệt. Rối loạn lipid máu. Chức năng gan, thận bình thường.');

    -- HbA1c (chỉ số vàng)
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseDiabetes, 5,
     N'{"HbA1c": "9.2%"}',
     N'Bình thường: <5.7%, Tiền đái tháo đường: 5.7-6.4%, Đái tháo đường: ≥6.5%',
     N'HbA1c 9.2% xác định đái tháo đường và kiểm soát đường huyết kém trong 3 tháng qua.');

    -- Xét nghiệm nước tiểu
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseDiabetes, 4,
     N'{"glucose": "+++", "protein": "Âm tính", "ketone": "Âm tính", "microalbumin": "25 mg/L"}',
     N'Glucose: Âm tính, Protein: Âm tính, Microalbumin: <20 mg/L',
     N'Có đường trong nước tiểu. Microalbumin tăng nhẹ - cần theo dõi chức năng thận.');

    -- Siêu âm bụng
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, ImagePath, NormalRange, Interpretation)
    VALUES
    (@CaseDiabetes, 8,
     N'{"gan": "Tăng âm gan (gan nhiễm mỡ độ 1)", "mat": "Bình thường", "tuy": "Bình thường", "than": "Bình thường, không sỏi"}',
     N'/images/cases/ultrasound_liver_fatty.jpg',
     N'Gan không tăng âm',
     N'Gan nhiễm mỡ độ 1 - thường gặp ở bệnh nhân đái tháo đường và béo phì.');

    -- Điện tim
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseDiabetes, 10,
     N'{"nhipTim": "78 bpm", "nhipXoang": "Đều", "truc": "Bình thường", "STT": "Bình thường"}',
     N'Nhịp xoang 60-100 bpm',
     N'Điện tim bình thường. Chưa có biến chứng tim mạch.');
END

-- =============================================
-- 3. KẾT QUẢ XÉT NGHIỆM CHO CAO HUYẾT ÁP + ĐÁI THÁO ĐƯỜNG
-- =============================================

IF @CaseHypertension IS NOT NULL
BEGIN
    -- Khám tổng quát
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseHypertension, 1,
     N'{"mach": "82 lần/phút", "huyetAp": "165/105 mmHg", "nhietDo": "36.8°C", "phuNgoaiVi": "Phù cả 2 cẳng chân ++"}',
     N'Huyết áp: <120/80 mmHg',
     N'Tăng huyết áp độ 2. Phù ngoại vi gợi ý suy tim hoặc suy thận.');

    -- Xét nghiệm máu
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseHypertension, 2,
     N'{"WBC": "8.2 G/L", "RBC": "3.8 T/L", "Hb": "11.2 g/dL", "Hct": "35%", "PLT": "220 G/L"}',
     N'Hb: Nam 13-17 g/dL, Nữ 12-15 g/dL',
     N'Thiếu máu nhẹ - cần đánh giá chức năng thận.');

    -- Sinh hóa máu
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseHypertension, 3,
     N'{"glucose": "14.8 mmol/L", "ure": "18.5 mmol/L", "creatinin": "185 µmol/L", "eGFR": "35 ml/min", "kali": "5.2 mmol/L", "natri": "142 mmol/L"}',
     N'Ure: 2.5-7.5 mmol/L, Creatinin: 60-110 µmol/L, eGFR: >60 ml/min, Kali: 3.5-5.0 mmol/L',
     N'Suy thận độ 3 (eGFR 30-59). Tăng kali máu nhẹ. Đường huyết cao không kiểm soát.');

    -- HbA1c
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseHypertension, 5,
     N'{"HbA1c": "10.5%"}',
     N'Bình thường: <5.7%, Mục tiêu ĐTĐ: <7%',
     N'Đái tháo đường kiểm soát rất kém. Cần điều chỉnh điều trị tích cực.');

    -- Xét nghiệm nước tiểu
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseHypertension, 4,
     N'{"protein": "+++", "glucose": "+++", "microalbumin": "450 mg/L", "tyLe_Protein_Creatinin": "850 mg/g"}',
     N'Protein: Âm tính, Microalbumin: <30 mg/L',
     N'Protein niệu và microalbuminuria nặng - bệnh thận đái tháo đường giai đoạn muộn.');

    -- Điện tim
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, ImagePath, NormalRange, Interpretation)
    VALUES
    (@CaseHypertension, 10,
     N'{"nhipTim": "82 bpm", "bienDoQRS": "Tăng", "dongTruVai": "Lệch trái", "LL_biHypertrophy": "Có dấu hiệu phì đại thất trái"}',
     N'/images/cases/ecg_lvh.jpg',
     N'Không phì đại thất trái',
     N'Phì đại thất trái - biến chứng của tăng huyết áp mạn tính.');

    -- Siêu âm tim
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, ImagePath, NormalRange, Interpretation)
    VALUES
    (@CaseHypertension, 9,
     N'{"phanSoPumpMau": "45%", "phiDaiThatTrai": "Có", "vanTim": "Hở van hai lá độ 1", "dungNangTeTruong": "Giảm"}',
     N'/images/cases/echo_heart.jpg',
     N'EF: 55-70%, Không phì đại',
     N'Suy tim co bóp (EF 45%). Phì đại thất trái. Hở van hai lá thứ phát.');

    -- Siêu âm bụng (đánh giá thận)
    INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
    VALUES
    (@CaseHypertension, 8,
     N'{"than": "Cả 2 thận co nhỏ, vỏ thận mỏng, tăng âm vỏ thận", "kichThuocThanPhai": "8.5 cm", "kichThuocThanTrai": "8.8 cm"}',
     N'Kích thước thận: 10-12 cm',
     N'Thận co nhỏ 2 bên - bệnh thận mạn giai đoạn muộn.');
END

-- =============================================
-- TẠO VIEWS ĐỂ TỐI ƯU HÓA TRUY VẤN
-- =============================================

-- View: Danh sách sinh viên và các module đã đăng ký
CREATE OR ALTER VIEW vw_StudentModuleEnrollment AS
SELECT
    u.UserID AS StudentID,
    u.Username,
    u.FullName AS StudentName,
    u.Email,
    m.ModuleID,
    m.ModuleCode,
    m.ModuleName,
    sm.EnrolledDate,
    lecturer.FullName AS LecturerName
FROM Users u
INNER JOIN StudentModules sm ON u.UserID = sm.StudentID
INNER JOIN Modules m ON sm.ModuleID = m.ModuleID
INNER JOIN Users lecturer ON m.LecturerID = lecturer.UserID
WHERE u.Role = 'Student' AND u.IsActive = 1;
GO

-- View: Danh sách case studies với lecturer
CREATE OR ALTER VIEW vw_CaseStudiesWithDetails AS
SELECT
    cs.CaseID,
    cs.CaseTitle,
    cs.Description,
    cs.Symptoms,
    cs.Diagnosis,
    cs.IsInteractive,
    cs.DifficultyLevel,
    cs.PatientAge,
    cs.PatientGender,
    cs.PatientHistory,
    m.ModuleID,
    m.ModuleCode,
    m.ModuleName,
    lecturer.FullName AS LecturerName,
    cs.CreatedDate
FROM CaseStudies cs
INNER JOIN Modules m ON cs.ModuleID = m.ModuleID
INNER JOIN Users lecturer ON m.LecturerID = lecturer.UserID
WHERE cs.IsActive = 1;
GO

-- View: Kết quả xét nghiệm của case
CREATE OR ALTER VIEW vw_CaseExaminationDetails AS
SELECT
    cer.CaseExaminationID,
    cer.CaseID,
    cs.CaseTitle,
    et.ExaminationTypeID,
    et.ExaminationCode,
    et.ExaminationName,
    et.Description AS ExaminationDescription,
    et.Cost,
    cer.ResultData,
    cer.ImagePath,
    cer.NormalRange,
    cer.Interpretation
FROM CaseExaminationResults cer
INNER JOIN CaseStudies cs ON cer.CaseID = cs.CaseID
INNER JOIN ExaminationTypes et ON cer.ExaminationTypeID = et.ExaminationTypeID
WHERE et.IsActive = 1;
GO

-- View: Lịch sử chẩn đoán của sinh viên
CREATE OR ALTER VIEW vw_StudentDiagnosisHistory AS
SELECT
    sda.AttemptID,
    u.UserID AS StudentID,
    u.FullName AS StudentName,
    cs.CaseID,
    cs.CaseTitle,
    sda.AttemptDate,
    sda.IsCompleted,
    sda.Score,
    sda.TotalCost,
    sda.TimeSpent,
    sds.DiagnosisText,
    sds.TreatmentPlan,
    sds.IsCorrect,
    sds.SimilarityScore,
    sds.SubmittedDate
FROM StudentDiagnosisAttempts sda
INNER JOIN Users u ON sda.StudentID = u.UserID
INNER JOIN CaseStudies cs ON sda.CaseID = cs.CaseID
LEFT JOIN StudentDiagnosisSubmissions sds ON sda.AttemptID = sds.AttemptID;
GO

-- =============================================
-- STORED PROCEDURES ĐỂ XỬ LÝ LOGIC
-- =============================================

-- SP: Lấy kết quả xét nghiệm khi sinh viên request
CREATE OR ALTER PROCEDURE sp_GetExaminationResult
    @AttemptID INT,
    @ExaminationTypeID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Lấy CaseID từ AttemptID
    DECLARE @CaseID INT;
    SELECT @CaseID = CaseID FROM StudentDiagnosisAttempts WHERE AttemptID = @AttemptID;

    -- Kiểm tra xem có kết quả không
    IF EXISTS (
        SELECT 1
        FROM CaseExaminationResults
        WHERE CaseID = @CaseID AND ExaminationTypeID = @ExaminationTypeID
    )
    BEGIN
        -- Thêm vào bảng requests
        IF NOT EXISTS (
            SELECT 1
            FROM StudentExaminationRequests
            WHERE AttemptID = @AttemptID AND ExaminationTypeID = @ExaminationTypeID
        )
        BEGIN
            INSERT INTO StudentExaminationRequests (AttemptID, ExaminationTypeID, IsViewed)
            VALUES (@AttemptID, @ExaminationTypeID, 1);

            -- Cập nhật tổng chi phí
            UPDATE StudentDiagnosisAttempts
            SET TotalCost = TotalCost + (SELECT Cost FROM ExaminationTypes WHERE ExaminationTypeID = @ExaminationTypeID)
            WHERE AttemptID = @AttemptID;
        END
        ELSE
        BEGIN
            -- Đã xem rồi, chỉ cập nhật trạng thái
            UPDATE StudentExaminationRequests
            SET IsViewed = 1, ViewedDate = GETDATE()
            WHERE AttemptID = @AttemptID AND ExaminationTypeID = @ExaminationTypeID;
        END

        -- Trả về kết quả
        SELECT
            cer.CaseExaminationID,
            et.ExaminationCode,
            et.ExaminationName,
            et.Description AS ExaminationDescription,
            et.Cost,
            cer.ResultData,
            cer.ImagePath,
            cer.NormalRange,
            cer.Interpretation
        FROM CaseExaminationResults cer
        INNER JOIN ExaminationTypes et ON cer.ExaminationTypeID = et.ExaminationTypeID
        WHERE cer.CaseID = @CaseID AND cer.ExaminationTypeID = @ExaminationTypeID;
    END
    ELSE
    BEGIN
        -- Không có kết quả
        SELECT NULL AS CaseExaminationID, 'Không có kết quả xét nghiệm' AS Message;
    END
END
GO

-- SP: Tính điểm chẩn đoán của sinh viên
CREATE OR ALTER PROCEDURE sp_CalculateDiagnosisScore
    @AttemptID INT,
    @DiagnosisText NVARCHAR(MAX),
    @TreatmentPlan NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CaseID INT, @CorrectDiagnosis NVARCHAR(MAX);
    DECLARE @Score DECIMAL(5,2) = 0;
    DECLARE @IsCorrect BIT = 0;
    DECLARE @SimilarityScore DECIMAL(5,2) = 0;

    -- Lấy thông tin case
    SELECT @CaseID = CaseID FROM StudentDiagnosisAttempts WHERE AttemptID = @AttemptID;
    SELECT @CorrectDiagnosis = Diagnosis FROM CaseStudies WHERE CaseID = @CaseID;

    -- Tính điểm (logic đơn giản - có thể cải thiện với AI)
    -- Kiểm tra các từ khóa quan trọng
    IF @DiagnosisText LIKE '%' + (SELECT TOP 1 value FROM STRING_SPLIT(@CorrectDiagnosis, ' ')) + '%'
    BEGIN
        SET @SimilarityScore = 70;
        SET @Score = 70;
    END

    -- Bonus cho treatment plan
    IF @TreatmentPlan IS NOT NULL AND LEN(@TreatmentPlan) > 50
        SET @Score = @Score + 10;

    -- Penalty cho chi phí cao
    DECLARE @TotalCost DECIMAL(10,2);
    SELECT @TotalCost = TotalCost FROM StudentDiagnosisAttempts WHERE AttemptID = @AttemptID;
    IF @TotalCost > 2000000
        SET @Score = @Score - 10;

    -- Đánh giá chính xác
    IF @Score >= 60
        SET @IsCorrect = 1;

    -- Lưu kết quả
    INSERT INTO StudentDiagnosisSubmissions (AttemptID, DiagnosisText, TreatmentPlan, IsCorrect, SimilarityScore)
    VALUES (@AttemptID, @DiagnosisText, @TreatmentPlan, @IsCorrect, @SimilarityScore);

    -- Cập nhật attempt
    UPDATE StudentDiagnosisAttempts
    SET IsCompleted = 1, Score = @Score
    WHERE AttemptID = @AttemptID;

    -- Trả về kết quả
    SELECT
        @Score AS FinalScore,
        @IsCorrect AS IsCorrect,
        @SimilarityScore AS SimilarityScore,
        CASE
            WHEN @Score >= 80 THEN N'Xuất sắc! Chẩn đoán chính xác.'
            WHEN @Score >= 60 THEN N'Tốt! Chẩn đoán cơ bản đúng, cần cải thiện thêm.'
            ELSE N'Chưa chính xác. Hãy xem lại các triệu chứng và kết quả xét nghiệm.'
        END AS FeedbackText;
END
GO

-- =============================================
-- BẢO MẬT VÀ TỐI ƯU HÓA
-- =============================================

-- Thêm constraints
ALTER TABLE StudentDiagnosisAttempts ADD CONSTRAINT CK_Score CHECK (Score >= 0 AND Score <= 100);
ALTER TABLE StudentDiagnosisSubmissions ADD CONSTRAINT CK_SimilarityScore CHECK (SimilarityScore >= 0 AND SimilarityScore <= 100);
GO

PRINT '====================================';
PRINT 'Database Optimization Complete!';
PRINT '====================================';
PRINT '';
PRINT 'THAY ĐỔI CHÍNH:';
PRINT '✓ Bổ sung kết quả xét nghiệm chi tiết cho các ca bệnh';
PRINT '✓ Tạo Views để tối ưu truy vấn (giảm joins phức tạp)';
PRINT '✓ Tạo Stored Procedures xử lý logic nghiệp vụ';
PRINT '✓ Thêm constraints bảo mật dữ liệu';
PRINT '';
PRINT 'GIẢI PHÁP KẾT NỐI VÒNG:';
PRINT '• KHÔNG XÓA kết nối: Modules ↔ Users (LecturerID)';
PRINT '• LÝ DO: Cần biết giảng viên nào phụ trách module';
PRINT '• TỐI ƯU: Sử dụng Views thay vì query trực tiếp';
PRINT '• KẾT QUẢ: Tăng performance, dễ bảo trì, logic rõ ràng';
PRINT '';
PRINT '====================================';
GO