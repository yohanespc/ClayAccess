/****** Object:  Table [dbo].[User]    Script Date: 5/8/2018 10:43:17 AM ******/
DROP TABLE [dbo].[User]
GO

/****** Object:  Table [dbo].[User]    Script Date: 5/8/2018 10:43:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ProfileId] [int] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[LastLogin] [datetime] NOT NULL,
	[ValidFrom] [datetime] NOT NULL,
	[ValidUntil] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


