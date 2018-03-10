IF (OBJECT_ID(N'[dbo].[ErrorLog]', N'U') IS NOT NULL)
BEGIN
	DROP TABLE [dbo].[ErrorLog];
END
GO

CREATE TABLE [dbo].[ErrorLog]
(
	 nId BIGINT IDENTITY(1, 1) NOT NULL
	,dtDate DATETIME NOT NULL
	,sThread NVARCHAR(100) NOT NULL
	,sLevel NVARCHAR(200) NOT NULL
	,sLogger NVARCHAR(500) NOT NULL
	,sMessage NVARCHAR(3000) NOT NULL
	,sException NVARCHAR(4000) NULL
)
GO
