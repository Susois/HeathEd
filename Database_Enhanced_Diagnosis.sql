-- =============================================
-- Enhanced Database Schema for Interactive Diagnosis Feature
-- =============================================

USE HeathEdDB;
GO

-- =============================================
-- Add new tables for interactive diagnosis
-- =============================================

-- Examination Types Table (các loại xét nghiệm)
CREATE TABLE ExaminationTypes (
    ExaminationTypeID INT PRIMARY KEY IDENTITY(1,1),
    ExaminationCode NVARCHAR(20) NOT NULL UNIQUE,
    ExaminationName NVARCHAR(200) NOT NULL,
    Description NVARCHAR(500),
    Cost DECIMAL(10,2) DEFAULT 0,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- Case Examination Results (kết quả xét nghiệm cho mỗi ca bệnh)
CREATE TABLE CaseExaminationResults (
    CaseExaminationID INT PRIMARY KEY IDENTITY(1,1),
    CaseID INT NOT NULL,
    ExaminationTypeID INT NOT NULL,
    ResultData NVARCHAR(MAX), -- JSON format for flexibility
    ImagePath NVARCHAR(500), -- Đường dẫn đến hình ảnh kết quả
    NormalRange NVARCHAR(200), -- Giá trị bình thường
    Interpretation NVARCHAR(MAX), -- Giải thích kết quả
    FOREIGN KEY (CaseID) REFERENCES CaseStudies(CaseID),
    FOREIGN KEY (ExaminationTypeID) REFERENCES ExaminationTypes(ExaminationTypeID)
);
GO

-- Student Diagnosis Attempts (lần chẩn đoán của sinh viên)
CREATE TABLE StudentDiagnosisAttempts (
    AttemptID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    CaseID INT NOT NULL,
    AttemptDate DATETIME DEFAULT GETDATE(),
    IsCompleted BIT DEFAULT 0,
    Score DECIMAL(5,2), -- Điểm số
    TotalCost DECIMAL(10,2) DEFAULT 0, -- Tổng chi phí xét nghiệm
    TimeSpent INT, -- Thời gian làm bài (phút)
    FOREIGN KEY (StudentID) REFERENCES Users(UserID),
    FOREIGN KEY (CaseID) REFERENCES CaseStudies(CaseID)
);
GO

-- Student Examination Requests (xét nghiệm mà sinh viên yêu cầu)
CREATE TABLE StudentExaminationRequests (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    AttemptID INT NOT NULL,
    ExaminationTypeID INT NOT NULL,
    RequestedDate DATETIME DEFAULT GETDATE(),
    IsViewed BIT DEFAULT 0, -- Đã xem kết quả chưa
    ViewedDate DATETIME,
    FOREIGN KEY (AttemptID) REFERENCES StudentDiagnosisAttempts(AttemptID),
    FOREIGN KEY (ExaminationTypeID) REFERENCES ExaminationTypes(ExaminationTypeID)
);
GO

-- Student Diagnosis Submissions (chẩn đoán cuối cùng của sinh viên)
CREATE TABLE StudentDiagnosisSubmissions (
    SubmissionID INT PRIMARY KEY IDENTITY(1,1),
    AttemptID INT NOT NULL,
    DiagnosisText NVARCHAR(MAX) NOT NULL,
    TreatmentPlan NVARCHAR(MAX),
    SubmittedDate DATETIME DEFAULT GETDATE(),
    IsCorrect BIT,
    SimilarityScore DECIMAL(5,2), -- Độ tương đồng với chẩn đoán đúng (0-100)
    FeedbackText NVARCHAR(MAX), -- Phản hồi từ hệ thống
    FOREIGN KEY (AttemptID) REFERENCES StudentDiagnosisAttempts(AttemptID)
);
GO

-- Case Images (hình ảnh bệnh nhân)
CREATE TABLE CaseImages (
    ImageID INT PRIMARY KEY IDENTITY(1,1),
    CaseID INT NOT NULL,
    ImagePath NVARCHAR(500) NOT NULL,
    ImageType NVARCHAR(50), -- X-ray, CT scan, Photo, etc.
    Description NVARCHAR(500),
    IsInitiallyVisible BIT DEFAULT 1, -- Hiển thị ngay từ đầu hay cần xét nghiệm
    DisplayOrder INT DEFAULT 0,
    FOREIGN KEY (CaseID) REFERENCES CaseStudies(CaseID)
);
GO

-- =============================================
-- Insert Sample Examination Types
-- =============================================

INSERT INTO ExaminationTypes (ExaminationCode, ExaminationName, Description, Cost, IsActive)
VALUES
    ('GEN001', N'Khám tổng quát', N'Khám lâm sàng toàn diện: mạch, huyết áp, nghe phổi, tim...', 100000, 1),
    ('XN001', N'Xét nghiệm máu tổng quát', N'Công thức máu: hồng cầu, bạch cầu, tiểu cầu, hemoglobin...', 150000, 1),
    ('XN002', N'Xét nghiệm sinh hóa máu', N'Glucose, ure, creatinin, AST, ALT, bilirubin...', 300000, 1),
    ('XN003', N'Xét nghiệm nước tiểu', N'Protein, glucose, hồng cầu, bạch cầu trong nước tiểu', 80000, 1),
    ('XN004', N'Xét nghiệm HbA1c', N'Đánh giá kiểm soát đường huyết 3 tháng', 200000, 1),
    ('XQ001', N'X-quang phổi', N'Chụp X-quang tim phổi thẳng', 250000, 1),
    ('XQ002', N'X-quang xương khớp', N'Chụp X-quang các vùng xương khớp', 200000, 1),
    ('SA001', N'Siêu âm bụng tổng quát', N'Siêu âm gan, mật, tụy, lách, thận', 350000, 1),
    ('SA002', N'Siêu âm tim', N'Đánh giá chức năng tim, van tim', 500000, 1),
    ('DT001', N'Điện tim (ECG)', N'Ghi điện tâm đồ 12 chuyển đạo', 100000, 1),
    ('CT001', N'CT Scanner', N'Chụp cắt lớp vi tính', 2000000, 1),
    ('MRI001', N'MRI', N'Chụp cộng hưởng từ', 3500000, 1);
GO

-- =============================================
-- Update existing CaseStudies table to hide diagnosis
-- =============================================

-- Add column to mark if case is for interactive diagnosis
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'CaseStudies') AND name = 'IsInteractive')
BEGIN
    ALTER TABLE CaseStudies ADD IsInteractive BIT DEFAULT 0;
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'CaseStudies') AND name = 'DifficultyLevel')
BEGIN
    ALTER TABLE CaseStudies ADD DifficultyLevel NVARCHAR(20) DEFAULT 'Medium'; -- Easy, Medium, Hard
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'CaseStudies') AND name = 'PatientAge')
BEGIN
    ALTER TABLE CaseStudies ADD PatientAge INT;
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'CaseStudies') AND name = 'PatientGender')
BEGIN
    ALTER TABLE CaseStudies ADD PatientGender NVARCHAR(10); -- Nam/Nữ
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'CaseStudies') AND name = 'PatientHistory')
BEGIN
    ALTER TABLE CaseStudies ADD PatientHistory NVARCHAR(MAX); -- Tiền sử bệnh
END
GO

-- =============================================
-- Insert Enhanced Case Study with Examination Results
-- =============================================

-- Insert a new interactive case
INSERT INTO CaseStudies (CaseTitle, Description, Symptoms, Diagnosis, ModuleID, IsActive, IsInteractive, DifficultyLevel, PatientAge, PatientGender, PatientHistory)
VALUES
(N'Ca bệnh viêm phổi - Chẩn đoán tương tác',
 N'Bệnh nhân nam, 45 tuổi, nhập viện với triệu chứng ho, sốt cao. Hãy thực hiện các xét nghiệm cần thiết để chẩn đoán.',
 N'Ho nhiều có đờm, sốt 39-40°C từ 3 ngày nay, khó thở, mệt mỏi, đau ngực khi hít thở sâu',
 N'Viêm phổi cấp do vi khuẩn Streptococcus pneumoniae',
 1, 1, 1, 'Medium', 45, N'Nam',
 N'Tiền sử: Hút thuốc lá 20 năm (1 gói/ngày). Không có bệnh mạn tính. Gia đình không có người bị bệnh lao.');
GO

DECLARE @NewCaseID INT = SCOPE_IDENTITY();

-- Insert examination results for this case
-- Khám tổng quát
INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
VALUES
(@NewCaseID, 1,
 N'{"mach": "95 lần/phút", "huyetAp": "120/80 mmHg", "nhietDo": "39.5°C", "tanSoTho": "24 lần/phút", "SpO2": "92%", "nghePoi": "Ran ẩm hạt nhỏ vùng đáy phổi phải"}',
 N'Mạch: 60-100 lần/phút, Huyết áp: <120/80, Nhiệt độ: 36-37°C, SpO2: >95%',
 N'Sốt cao, tăng nhịp thở, giảm oxy máu nhẹ. Ran ẩm hạt nhỏ gợi ý viêm phổi.');

-- Xét nghiệm máu
INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
VALUES
(@NewCaseID, 2,
 N'{"WBC": "15.2 G/L", "RBC": "4.8 T/L", "Hb": "14.5 g/dL", "PLT": "280 G/L", "Neutrophil": "85%", "Lymphocyte": "10%"}',
 N'WBC: 4-11 G/L, Neutrophil: 40-70%',
 N'Tăng bạch cầu với tăng bạch cầu trung tính, điển hình cho nhiễm khuẩn cấp tính.');

-- X-quang phổi
INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, ImagePath, NormalRange, Interpretation)
VALUES
(@NewCaseID, 6,
 N'{"findingLocation": "Thùy dưới phổi phải", "finding": "Tổn thương thâm nhiễm dạng đám mờ"}',
 N'/images/cases/xray_pneumonia_sample.jpg',
 N'Phổi trong, không có tổn thương',
 N'Hình ảnh thâm nhiễm phổi điển hình cho viêm phổi thùy.');

-- Xét nghiệm sinh hóa
INSERT INTO CaseExaminationResults (CaseID, ExaminationTypeID, ResultData, NormalRange, Interpretation)
VALUES
(@NewCaseID, 3,
 N'{"CRP": "120 mg/L", "PCT": "2.5 ng/mL", "glucose": "5.8 mmol/L", "creatinin": "85 µmol/L"}',
 N'CRP: <5 mg/L, PCT: <0.5 ng/mL',
 N'CRP và Procalcitonin tăng cao, xác nhận nhiễm khuẩn nghiêm trọng.');

GO

-- =============================================
-- Create Indexes for Performance
-- =============================================

CREATE INDEX IX_StudentDiagnosisAttempts_StudentID ON StudentDiagnosisAttempts(StudentID);
CREATE INDEX IX_StudentDiagnosisAttempts_CaseID ON StudentDiagnosisAttempts(CaseID);
CREATE INDEX IX_StudentExaminationRequests_AttemptID ON StudentExaminationRequests(AttemptID);
CREATE INDEX IX_CaseExaminationResults_CaseID ON CaseExaminationResults(CaseID);
CREATE INDEX IX_CaseImages_CaseID ON CaseImages(CaseID);
GO

PRINT '====================================';
PRINT 'Enhanced Diagnosis Schema Created!';
PRINT '====================================';
PRINT '';
PRINT 'New Tables:';
PRINT '  - ExaminationTypes: 12 examination types';
PRINT '  - CaseExaminationResults: Results for each case';
PRINT '  - StudentDiagnosisAttempts: Track student attempts';
PRINT '  - StudentExaminationRequests: Track requested exams';
PRINT '  - StudentDiagnosisSubmissions: Student diagnoses';
PRINT '  - CaseImages: Patient images';
PRINT '';
PRINT '====================================';
GO
