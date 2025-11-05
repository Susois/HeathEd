-- =============================================
-- Fix Single User Mode - HeathEdDB
-- =============================================

USE master;
GO

-- Đóng tất cả các kết nối hiện tại đến HeathEdDB
ALTER DATABASE HeathEdDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

-- Chuyển về chế độ MULTI_USER (cho phép nhiều kết nối)
ALTER DATABASE HeathEdDB SET MULTI_USER;
GO

PRINT '====================================';
PRINT 'Database HeathEdDB đã được chuyển về chế độ MULTI_USER';
PRINT 'Bây giờ bạn có thể chạy ứng dụng!';
PRINT '====================================';
GO

-- Kiểm tra trạng thái
SELECT
    name AS [Database Name],
    user_access_desc AS [Access Mode],
    state_desc AS [State]
FROM sys.databases
WHERE name = 'HeathEdDB';
GO
