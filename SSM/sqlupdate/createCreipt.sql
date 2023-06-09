GO
/****** Object:  Table [dbo].[Catelory]    Script Date: 6/10/2016 2:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- CREATE History
CREATE TABLE [dbo].[History](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ActionName] [nvarchar](250) NOT NULL,
	[HistoryMessage] [text] NULL,
	[ObjectId] [bigint] NULL,
	[ObjectType] [nvarchar](150) NULL,
	[IsLasted] [bit] NOT NULL,
	[IsRevisedRequest] [bit] NOT NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
-- CREATE Catelory
CREATE TABLE [dbo].[Catelory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameType] [nvarchar](50) NOT NULL,
	[NameTypeViet] [nvarchar](50) NULL,
	[Type] [tinyint] NULL,
 CONSTRAINT [PK_Catelory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewAccessPermission]    Script Date: 6/10/2016 2:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- CREATE NewAccessPermission
CREATE TABLE [dbo].[NewAccessPermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[NewId] [int] NOT NULL,
 CONSTRAINT [PK_NewAccessPermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ScfNews]    Script Date: 6/10/2016 2:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
--CREATE TABLE [dbo].[ScfNews]
CREATE TABLE [dbo].[ScfNews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hearder] [nvarchar](max) NOT NULL,
	[Content] [ntext] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Sourse] [nvarchar](255) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[DateCreate] [datetime] NOT NULL,
	[DateModify] [datetime] NULL,
	[IsAllowAnotherUpdate] [bit] NOT NULL,
	[UserIds] [varchar](500) NULL,
	[CateloryId] [int] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[Appvovedby] [bigint] NULL,
	[DatePromulgate] [datetime] NULL,
	[RefDoc] [nvarchar](255) NULL,
	[DateApproved] [datetime] NULL,
 CONSTRAINT [PK_ScfNews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Catelory] ON 

GO
INSERT [dbo].[Catelory] ([Id], [NameType], [NameTypeViet], [Type]) VALUES (1, N'QUY TRINH', N'QUY TRÌNH', 0)
GO
INSERT [dbo].[Catelory] ([Id], [NameType], [NameTypeViet], [Type]) VALUES (2, N'QUY DINH', N'QUY ĐỊNH', 0)
GO
--INSERT [dbo].[Catelory] ([Id], [NameType], [NameTypeViet], [Type]) VALUES (3, N'QUY CHE', N'QUY CHẾ', 0)
--GO
--INSERT [dbo].[Catelory] ([Id], [NameType], [NameTypeViet], [Type]) VALUES (4, N'NOI QUY', N'NỘI QUY', 0)
GO
INSERT [dbo].[Catelory] ([Id], [NameType], [NameTypeViet], [Type]) VALUES (5, N'NEW', N'TIN TỨC', 1)
GO
INSERT [dbo].[Catelory] ([Id], [NameType], [NameTypeViet], [Type]) VALUES (6, N'Info', N'THÔNG BÁO', 1)
GO
SET IDENTITY_INSERT [dbo].[Catelory] OFF
GO
ALTER TABLE [dbo].[NewAccessPermission]  WITH CHECK ADD  CONSTRAINT [FK_NewAccessPermission_ScfNews] FOREIGN KEY([NewId])
REFERENCES [dbo].[ScfNews] ([Id])
GO
ALTER TABLE [dbo].[NewAccessPermission] CHECK CONSTRAINT [FK_NewAccessPermission_ScfNews]
GO
ALTER TABLE [dbo].[NewAccessPermission]  WITH CHECK ADD  CONSTRAINT [FK_NewAccessPermission_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[NewAccessPermission] CHECK CONSTRAINT [FK_NewAccessPermission_User]
GO
ALTER TABLE [dbo].[ScfNews]  WITH CHECK ADD  CONSTRAINT [FK_ScfNews_Catelory] FOREIGN KEY([CateloryId])
REFERENCES [dbo].[Catelory] ([Id])
GO
ALTER TABLE [dbo].[ScfNews] CHECK CONSTRAINT [FK_ScfNews_Catelory]
GO


/****** Object:  Table [dbo].[GroupAccessPermission]    Script Date: 7/14/2016 7:41:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GroupAccessPermission](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[AboutId] [int] NOT NULL,
 CONSTRAINT [PK_GroupAccessPermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[GroupAccessPermission]  WITH CHECK ADD  CONSTRAINT [FK_GroupAccessPermission_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO

ALTER TABLE [dbo].[GroupAccessPermission] CHECK CONSTRAINT [FK_GroupAccessPermission_Group]
GO

ALTER TABLE [dbo].[GroupAccessPermission]  WITH CHECK ADD  CONSTRAINT [FK_GroupAccessPermission_ScfNews] FOREIGN KEY([AboutId])
REFERENCES [dbo].[ScfNews] ([Id])
GO

ALTER TABLE [dbo].[GroupAccessPermission] CHECK CONSTRAINT [FK_GroupAccessPermission_ScfNews]
GO

truncate table dbo.NewAccessPermission