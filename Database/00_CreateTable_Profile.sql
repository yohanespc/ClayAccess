/****** Object:  Table [dbo].[Profile]    Script Date: 5/8/2018 10:45:02 AM ******/
DROP TABLE [dbo].[Profile]
GO

/****** Object:  Table [dbo].[Profile]    Script Date: 5/8/2018 10:45:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Profile](
	[ProfileId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


