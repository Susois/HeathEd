-- =============================================
-- HeathEd Database Setup Script
-- Database for Health Education Management System
-- =============================================

USE master;
GO

-- Drop database if exists (for clean setup)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'HeathEdDB')
BEGIN
    ALTER DATABASE HeathEdDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE HeathEdDB;
END
GO

-- Create database
CREATE DATABASE HeathEdDB;
GO

USE HeathEdDB;
GO

-- =============================================
-- Create Tables
-- =============================================

-- Users Table (Students and Lecturers)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Student', 'Lecturer')),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

-- Modules/Classes Table
CREATE TABLE Modules (
    ModuleID INT PRIMARY KEY IDENTITY(1,1),
    ModuleCode NVARCHAR(20) NOT NULL UNIQUE,
    ModuleName NVARCHAR(200) NOT NULL,
    Description NVARCHAR(500),
    LecturerID INT NOT NULL,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (LecturerID) REFERENCES Users(UserID)
);
GO

-- Student-Module Enrollment Table
CREATE TABLE StudentModules (
    StudentModuleID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    ModuleID INT NOT NULL,
    EnrolledDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (StudentID) REFERENCES Users(UserID),
    FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID),
    UNIQUE (StudentID, ModuleID)
);
GO

-- Case Studies Table
CREATE TABLE CaseStudies (
    CaseID INT PRIMARY KEY IDENTITY(1,1),
    CaseTitle NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    Symptoms NVARCHAR(MAX),
    Diagnosis NVARCHAR(MAX),
    ModuleID INT NOT NULL,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID)
);
GO

-- =============================================
-- Insert Sample Data
-- =============================================

-- Insert Lecturers
INSERT INTO Users (Username, Password, FullName, Email, Role, IsActive)
VALUES
    ('gv001', '123456', N'Nguyễn Văn An', 'nguyenvanan@healthed.edu.vn', 'Lecturer', 1),
    ('gv002', '123456', N'Trần Thị Bình', 'tranthibinh@healthed.edu.vn', 'Lecturer', 1);
GO

-- Insert Students
INSERT INTO Users (Username, Password, FullName, Email, Role, IsActive)
VALUES
    ('sv001', '123456', N'Lê Văn Cường', 'levanc@student.healthed.edu.vn', 'Student', 1),
    ('sv002', '123456', N'Phạm Thị Dung', 'phamthid@student.healthed.edu.vn', 'Student', 1),
    ('sv003', '123456', N'Hoàng Minh Đức', 'hoangmd@student.healthed.edu.vn', 'Student', 1),
    ('sv004', '123456', N'Vũ Thị Em', 'vuthiem@student.healthed.edu.vn', 'Student', 1),
    ('sv005', '123456', N'Đặng Văn Phong', 'dangvp@student.healthed.edu.vn', 'Student', 1);
GO

-- Insert Modules/Classes
INSERT INTO Modules (ModuleCode, ModuleName, Description, LecturerID, IsActive)
VALUES
    ('GPDL101', N'Giải phẫu - Dược lý cơ bản', N'Môn học cơ bản về giải phẫu và dược lý', 1, 1),
    ('HLSK102', N'Hướng dẫn sức khỏe cộng đồng', N'Tư vấn và hướng dẫn sức khỏe cho cộng đồng', 1, 1),
    ('CSDB103', N'Chăm sóc đa bệnh', N'Kỹ năng chăm sóc bệnh nhân đa bệnh lý', 2, 1),
    ('YHCT104', N'Y học cổ truyền', N'Các phương pháp chữa bệnh theo y học cổ truyền', 2, 1);
GO

-- Insert Student Enrollments
INSERT INTO StudentModules (StudentID, ModuleID, EnrolledDate)
VALUES
    -- Students in GPDL101
    (3, 1, GETDATE()), -- Lê Văn Cường
    (4, 1, GETDATE()), -- Phạm Thị Dung
    (5, 1, GETDATE()), -- Hoàng Minh Đức

    -- Students in HLSK102
    (3, 2, GETDATE()), -- Lê Văn Cường
    (6, 2, GETDATE()), -- Vũ Thị Em

    -- Students in CSDB103
    (4, 3, GETDATE()), -- Phạm Thị Dung
    (5, 3, GETDATE()), -- Hoàng Minh Đức
    (7, 3, GETDATE()), -- Đặng Văn Phong

    -- Students in YHCT104
    (6, 4, GETDATE()), -- Vũ Thị Em
    (7, 4, GETDATE()); -- Đặng Văn Phong
GO

-- Insert Case Studies
INSERT INTO CaseStudies (CaseTitle, Description, Symptoms, Diagnosis, ModuleID, IsActive)
VALUES
    -- Cases for GPDL101
    (N'Ca bệnh viêm phổi cấp',
     N'Bệnh nhân nam, 45 tuổi, nhập viện với triệu chứng ho, sốt cao và khó thở',
     N'Ho nhiều, sốt 39-40°C, khó thở, đau ngực khi hít thở sâu',
     N'Viêm phổi cấp do vi khuẩn Streptococcus pneumoniae. Điều trị: Kháng sinh nhóm beta-lactam',
     1, 1),

    (N'Ca bệnh đái tháo đường type 2',
     N'Bệnh nhân nữ, 52 tuổi, tiền sử béo phì, phát hiện đường huyết cao',
     N'Khát nước nhiều, tiểu nhiều, mệt mỏi, sụt cân không rõ nguyên nhân',
     N'Đái tháo đường type 2. Điều trị: Metformin, chế độ ăn kiêng, tập thể dục',
     1, 1),

    -- Cases for HLSK102
    (N'Tư vấn dinh dưỡng cho trẻ suy dinh dưỡng',
     N'Trẻ nam 3 tuổi, cân nặng thấp hơn chuẩn, chậm phát triển',
     N'Cân nặng dưới mức chuẩn 20%, biếng ăn, da khô, chậm lớn',
     N'Suy dinh dưỡng độ 2. Tư vấn: Chế độ ăn giàu protein, vitamin, theo dõi phát triển định kỳ',
     2, 1),

    (N'Phòng ngừa sốt xuất huyết dengue',
     N'Hướng dẫn cộng đồng phòng chống dịch sốt xuất huyết mùa mưa',
     N'Triệu chứng: Sốt cao đột ngột, đau đầu, đau cơ, xuất huyết dưới da',
     N'Phòng ngừa: Diệt bọ gậy, không để nước đọng, ngủ màn, phát hiện sớm và điều trị kịp thời',
     2, 1),

    -- Cases for CSDB103
    (N'Chăm sóc bệnh nhân cao huyết áp và tiểu đường',
     N'Bệnh nhân nữ 65 tuổi, có cả cao huyết áp và đái tháo đường',
     N'Huyết áp 160/100 mmHg, đường huyết 250 mg/dl, đau đầu, chóng mặt',
     N'Cao huyết áp + Đái tháo đường. Chăm sóc: Theo dõi huyết áp, đường huyết hàng ngày, uống thuốc đúng giờ',
     3, 1),

    (N'Chăm sóc bệnh nhân suy tim và thận',
     N'Bệnh nhân nam 70 tuổi, suy tim mạn tính, suy thận độ 3',
     N'Khó thở, phù chân, tiểu ít, mệt mỏi',
     N'Suy tim + Suy thận. Chăm sóc: Hạn chế muối, nước, theo dõi lượng nước vào/ra, cân nặng hàng ngày',
     3, 1),

    -- Cases for YHCT104
    (N'Điều trị đau lưng bằng châm cứu',
     N'Bệnh nhân nam 40 tuổi, đau lưng mạn tính do ngồi làm việc nhiều',
     N'Đau vùng thắt lưng, tê cứng, giảm khi nghỉ ngơi',
     N'Đau lưng cơ năng. Điều trị: Châm huyệt thận du, đại trường du, kết hợp vật lý trị liệu',
     4, 1),

    (N'Chữa mất ngủ bằng đông y',
     N'Bệnh nhân nữ 38 tuổi, mất ngủ kéo dài 3 tháng, stress công việc',
     N'Khó ngủ, ngủ không sâu, mệt mỏi ban ngày, lo âu',
     N'Mất ngủ do hỏa can thịnh. Điều trị: Thuốc an thần, châm huyệt thần môn, nội quan',
     4, 1);
GO

-- =============================================
-- Create Indexes for Performance
-- =============================================

CREATE INDEX IX_Users_Username ON Users(Username);
CREATE INDEX IX_Users_Role ON Users(Role);
CREATE INDEX IX_Modules_LecturerID ON Modules(LecturerID);
CREATE INDEX IX_StudentModules_StudentID ON StudentModules(StudentID);
CREATE INDEX IX_StudentModules_ModuleID ON StudentModules(ModuleID);
CREATE INDEX IX_CaseStudies_ModuleID ON CaseStudies(ModuleID);
GO

-- =============================================
-- Verification Queries
-- =============================================

PRINT '====================================';
PRINT 'Database Setup Complete!';
PRINT '====================================';
PRINT '';

PRINT 'Total Users: ' + CAST((SELECT COUNT(*) FROM Users) AS VARCHAR);
PRINT '  - Lecturers: ' + CAST((SELECT COUNT(*) FROM Users WHERE Role = 'Lecturer') AS VARCHAR);
PRINT '  - Students: ' + CAST((SELECT COUNT(*) FROM Users WHERE Role = 'Student') AS VARCHAR);
PRINT '';

PRINT 'Total Modules: ' + CAST((SELECT COUNT(*) FROM Modules) AS VARCHAR);
PRINT 'Total Enrollments: ' + CAST((SELECT COUNT(*) FROM StudentModules) AS VARCHAR);
PRINT 'Total Case Studies: ' + CAST((SELECT COUNT(*) FROM CaseStudies) AS VARCHAR);
PRINT '';

PRINT '====================================';
PRINT 'TEST ACCOUNTS';
PRINT '====================================';
PRINT '';
PRINT 'LECTURER ACCOUNTS:';
PRINT '  Username: gv001  | Password: 123456 | Name: Nguyễn Văn An';
PRINT '  Username: gv002  | Password: 123456 | Name: Trần Thị Bình';
PRINT '';
PRINT 'STUDENT ACCOUNTS:';
PRINT '  Username: sv001  | Password: 123456 | Name: Lê Văn Cường';
PRINT '  Username: sv002  | Password: 123456 | Name: Phạm Thị Dung';
PRINT '  Username: sv003  | Password: 123456 | Name: Hoàng Minh Đức';
PRINT '  Username: sv004  | Password: 123456 | Name: Vũ Thị Em';
PRINT '  Username: sv005  | Password: 123456 | Name: Đặng Văn Phong';
PRINT '';
PRINT '====================================';
GO

-- =============================================
-- Display Sample Data
-- =============================================

PRINT 'Sample Data Preview:';
PRINT '';
PRINT '--- Users ---';
SELECT UserID, Username, FullName, Role FROM Users;
PRINT '';

PRINT '--- Modules ---';
SELECT ModuleID, ModuleCode, ModuleName, LecturerID FROM Modules;
PRINT '';

PRINT '--- Student Enrollments ---';
SELECT
    sm.StudentModuleID,
    u.FullName AS StudentName,
    m.ModuleCode,
    m.ModuleName,
    sm.EnrolledDate
FROM StudentModules sm
INNER JOIN Users u ON sm.StudentID = u.UserID
INNER JOIN Modules m ON sm.ModuleID = m.ModuleID;
PRINT '';

PRINT '--- Case Studies ---';
SELECT CaseID, CaseTitle, ModuleID FROM CaseStudies;
PRINT '';

PRINT '====================================';
PRINT 'Setup completed successfully!';
PRINT 'You can now run your application.';
PRINT '====================================';
GO
