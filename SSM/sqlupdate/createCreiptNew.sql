USE [SCF_Trading]
GO
/****** Object:  Table [dbo].[Catelory]    Script Date: 7/9/2016 9:34:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[History]    Script Date: 7/9/2016 9:34:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[NewAccessPermission]    Script Date: 7/9/2016 9:34:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[ScfNews]    Script Date: 7/9/2016 9:34:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScfNews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Header] [nvarchar](max) NOT NULL,
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
	[UsersCanUpdate] [nvarchar](250) NULL,
 CONSTRAINT [PK_ScfNews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
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


CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_UserGroup_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
CREATE TABLE [dbo].[UserGroup](
	[UserId] [bigint] NOT NULL,
	[GroupId] [int] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_UserGroup_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserGroup]  WITH CHECK ADD  CONSTRAINT [FK_UserGroup_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO

ALTER TABLE [dbo].[UserGroup] CHECK CONSTRAINT [FK_UserGroup_Group]
GO

ALTER TABLE [dbo].[UserGroup]  WITH CHECK ADD  CONSTRAINT [FK_UserGroup_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[UserGroup] CHECK CONSTRAINT [FK_UserGroup_User]
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
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




