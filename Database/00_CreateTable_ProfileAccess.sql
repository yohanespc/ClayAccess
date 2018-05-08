/****** Object:  Table [dbo].[UserProfile]    Script Date: 5/8/2018 10:48:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProfileAccess](
	[ProfileAccessId] [int] IDENTITY(1,1) NOT NULL,
	[ProfileId] [int] NOT NULL,
	[DoorId] [int] NOT NULL,
	[EntryAccess] [bit] NOT NULL Default 0
 CONSTRAINT [PK_ProfileAccess] PRIMARY KEY CLUSTERED 
(
	[ProfileAccessId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


