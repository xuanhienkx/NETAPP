 
/****** Object:  Table [dbo].[CRMContact]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CRMContact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](300) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[Phone2] [varchar](15) NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Email2] [nvarchar](150) NULL,
	[CmrCustomerId] [bigint] NULL,
 CONSTRAINT [PK_CRMContact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CRMCusDocuments]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMCusDocuments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DocName] [nvarchar](500) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CrmCusId] [bigint] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[LinkDoc] [nvarchar](max) NULL,
	[CreatedById] [bigint] NOT NULL,
	[ModifiedById] [bigint] NULL,
 CONSTRAINT [PK_CrmCusDocuments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMCustomer]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMCustomer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](255) NOT NULL,
	[CompanyShortName] [nvarchar](100) NULL,
	[CrmCategoryId] [int] NULL,
	[CrmSourceId] [int] NULL,
	[CrmStatusId] [int] NULL,
	[CrmGroupId] [int] NULL,
	[CrmAddress] [nvarchar](250) NULL,
	[CrmDistrictId] [int] NULL,
	[CrmProvinceId] [bigint] NULL,
	[CrmPhone] [nvarchar](15) NULL,
	[SaleTypeId] [bigint] NULL,
	[CreatedById] [bigint] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifyById] [bigint] NULL,
	[ModifyDate] [datetime] NULL,
	[CrmDataType] [tinyint] NOT NULL CONSTRAINT [DF_CRMCustomer_CrmDataType]  DEFAULT ((0)),
	[Description] [nvarchar](max) NULL,
	[CustomerType] [tinyint] NULL,
	[SsmCusId] [bigint] NULL,
	[UserTogheTheFollow] [nvarchar](450) NULL,
	[IsUserDelete] [bit] NULL CONSTRAINT [DF_CRMCustomer_IsUserDelete]  DEFAULT ((0)),
	[DateCancel] [datetime] NULL,
 CONSTRAINT [PK_CrmCustomer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMEmailHistory]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMEmailHistory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ToAddress] [nvarchar](255) NOT NULL,
	[CcAddress] [nvarchar](255) NULL,
	[Subject] [nvarchar](255) NOT NULL,
	[DateSend] [datetime] NOT NULL,
	[PriceId] [bigint] NOT NULL,
 CONSTRAINT [PK_EmailHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMEventType]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMEventType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [nameCRMEventType_unique] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMFollowCusUser]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMFollowCusUser](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[CrmId] [bigint] NOT NULL,
	[IsLook] [bit] NOT NULL,
	[AddById] [bigint] NULL,
	[LockById] [bigint] NULL,
 CONSTRAINT [PK_CRMFollowUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMFollowEventUser]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMFollowEventUser](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[VisitId] [bigint] NOT NULL,
	[IsLook] [bit] NOT NULL,
	[AddById] [bigint] NOT NULL,
	[LockById] [bigint] NULL,
 CONSTRAINT [PK_EventFollowUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMGroup]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_CrmGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [nameCRMGroup_unique] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMJobCategory]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMJobCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_JobCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [nameCRMJobCategory_unique] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMPlanMonth]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMPlanMonth](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PlanMonth] [int] NOT NULL,
	[PlanYear] [int] NOT NULL,
	[ProgramMonthId] [bigint] NOT NULL,
	[PlanValue] [int] NOT NULL,
 CONSTRAINT [PK_CrmPlanMonth] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMPlanProgMonth]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMPlanProgMonth](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PlanYear] [int] NOT NULL,
	[ProgramId] [int] NOT NULL,
	[PlanSalesId] [bigint] NOT NULL,
 CONSTRAINT [PK_CRMProgramMountPlan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMPlanProgram]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMPlanProgram](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_CRMPlanProgram] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMPLanSales]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMPLanSales](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SalesId] [bigint] NOT NULL,
	[PlanYear] [int] NOT NULL,
	[SubmitedById] [bigint] NULL,
	[SubmitedDate] [datetime] NULL,
	[ApprovedById] [bigint] NULL,
	[ApprovedDate] [datetime] NULL,
 CONSTRAINT [PK_CRMPLanSales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMPriceQuotation]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMPriceQuotation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](400) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CrmCusId] [bigint] NOT NULL,
	[CountSendMail] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[ModifiedById] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedById] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastDateSend] [datetime] NULL,
	[IsDelete] [bit] NOT NULL CONSTRAINT [DF_PriceQuotation_IsActive]  DEFAULT ((0)),
 CONSTRAINT [PK_PriceQuotation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMPriceStatus]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMPriceStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[Code] [tinyint] NOT NULL,
	[IsSystem] [bit] NOT NULL CONSTRAINT [DF_CRMPriceStatus_IsSystem]  DEFAULT ((0)),
 CONSTRAINT [PK_CRMPriceStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMSchedule]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CRMSchedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayOfWeek] [nvarchar](20) NULL,
	[DayBeforeOfDatePlan] [int] NULL,
	[DayBeforeOfDateRevise] [int] NULL,
	[DateOfSchedule] [datetime] NULL,
	[DateBegin] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[TimeOfSchedule] [varchar](10) NOT NULL,
	[DayAlert] [int] NULL,
	[MountAlert] [int] NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CRMSource]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMSource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_SourceNew] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [nameCRMSource_unique] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMStatus]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[IsSystem] [bit] NOT NULL CONSTRAINT [DF_CRMStatus_IsSystem]  DEFAULT ((0)),
	[Code] [tinyint] NOT NULL CONSTRAINT [DF_CRMStatus_Code]  DEFAULT ((0)),
 CONSTRAINT [PK_CRMStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [nameCRMStatus_unique] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRMVisit]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CRMVisit](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DateBegin] [datetime] NOT NULL,
	[DateEnd] [datetime] NULL,
	[Status] [tinyint] NOT NULL,
	[IsSchedule] [bit] NOT NULL,
	[DateEvent] [datetime] NOT NULL,
	[AllowEdit] [bit] NOT NULL,
	[AllowAdd] [bit] NOT NULL,
	[AllowViewList] [bit] NOT NULL,
	[Subject] [nvarchar](450) NOT NULL,
	[CreatedById] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CrmCusId] [bigint] NOT NULL,
	[ModifiedById] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[EventTypeId] [int] NULL,
	[IsEventAction] [bit] NOT NULL CONSTRAINT [DF_CRMVisit_IsEventAction]  DEFAULT ((0)),
	[LastTimeReminder] [datetime] NULL,
	[TimeOfRemider] [varchar](10) NULL,
	[DayWeekOfRemider] [varchar](50) NULL,
 CONSTRAINT [PK_CRMVisit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Province]    Script Date: 1/11/2017 2:48:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[TimeZone] [nvarchar](50) NULL,
	[CountryId] [bigint] NOT NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_CRMPlanProgMount]    Script Date: 1/11/2017 2:48:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_CRMPlanProgMount] ON [dbo].[CRMPlanProgMonth]
(
	[PlanYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CRMPLanSales]    Script Date: 1/11/2017 2:48:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_CRMPLanSales] ON [dbo].[CRMPLanSales]
(
	[PlanYear] ASC,
	[SalesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CRMContact]  WITH CHECK ADD  CONSTRAINT [FK_CRMContact_CRMContact] FOREIGN KEY([CmrCustomerId])
REFERENCES [dbo].[CRMCustomer] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CRMContact] CHECK CONSTRAINT [FK_CRMContact_CRMContact]
GO
ALTER TABLE [dbo].[CRMCusDocuments]  WITH CHECK ADD  CONSTRAINT [FK_CrmCusDocuments_CRMCustomer] FOREIGN KEY([CrmCusId])
REFERENCES [dbo].[CRMCustomer] ([Id])
GO
ALTER TABLE [dbo].[CRMCusDocuments] CHECK CONSTRAINT [FK_CrmCusDocuments_CRMCustomer]
GO
ALTER TABLE [dbo].[CRMCustomer]  WITH CHECK ADD  CONSTRAINT [FK_CrmCustomer_CrmGroup] FOREIGN KEY([CrmGroupId])
REFERENCES [dbo].[CRMGroup] ([Id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CRMCustomer] CHECK CONSTRAINT [FK_CrmCustomer_CrmGroup]
GO
ALTER TABLE [dbo].[CRMCustomer]  WITH CHECK ADD  CONSTRAINT [FK_CrmCustomer_CRMJobCategory] FOREIGN KEY([CrmCategoryId])
REFERENCES [dbo].[CRMJobCategory] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CRMCustomer] CHECK CONSTRAINT [FK_CrmCustomer_CRMJobCategory]
GO
ALTER TABLE [dbo].[CRMCustomer]  WITH CHECK ADD  CONSTRAINT [FK_CrmCustomer_CRMSource] FOREIGN KEY([CrmSourceId])
REFERENCES [dbo].[CRMSource] ([Id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CRMCustomer] CHECK CONSTRAINT [FK_CrmCustomer_CRMSource]
GO
ALTER TABLE [dbo].[CRMCustomer]  WITH CHECK ADD  CONSTRAINT [FK_CrmCustomer_CRMStatus] FOREIGN KEY([CrmStatusId])
REFERENCES [dbo].[CRMStatus] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CRMCustomer] CHECK CONSTRAINT [FK_CrmCustomer_CRMStatus]
GO
ALTER TABLE [dbo].[CRMCustomer]  WITH CHECK ADD  CONSTRAINT [FK_CRMCustomer_Province] FOREIGN KEY([CrmProvinceId])
REFERENCES [dbo].[Province] ([Id])
GO
ALTER TABLE [dbo].[CRMCustomer] CHECK CONSTRAINT [FK_CRMCustomer_Province]
GO
ALTER TABLE [dbo].[CRMEmailHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmailHistory_PriceQuotation] FOREIGN KEY([PriceId])
REFERENCES [dbo].[CRMPriceQuotation] ([Id])
GO
ALTER TABLE [dbo].[CRMEmailHistory] CHECK CONSTRAINT [FK_EmailHistory_PriceQuotation]
GO
ALTER TABLE [dbo].[CRMFollowCusUser]  WITH CHECK ADD  CONSTRAINT [FK_CRMFollowCusUser_CRMCustomer] FOREIGN KEY([CrmId])
REFERENCES [dbo].[CRMCustomer] ([Id])
GO
ALTER TABLE [dbo].[CRMFollowCusUser] CHECK CONSTRAINT [FK_CRMFollowCusUser_CRMCustomer]
GO
ALTER TABLE [dbo].[CRMPlanMonth]  WITH CHECK ADD  CONSTRAINT [FK_CRMPlanMonth_CRMPlanProgMount] FOREIGN KEY([ProgramMonthId])
REFERENCES [dbo].[CRMPlanProgMonth] ([Id])
GO
ALTER TABLE [dbo].[CRMPlanMonth] CHECK CONSTRAINT [FK_CRMPlanMonth_CRMPlanProgMount]
GO
ALTER TABLE [dbo].[CRMPlanProgMonth]  WITH CHECK ADD  CONSTRAINT [FK_CRMPlanProgMount_CRMPlanProgram] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[CRMPlanProgram] ([Id])
GO
ALTER TABLE [dbo].[CRMPlanProgMonth] CHECK CONSTRAINT [FK_CRMPlanProgMount_CRMPlanProgram]
GO
ALTER TABLE [dbo].[CRMPlanProgMonth]  WITH CHECK ADD  CONSTRAINT [FK_CRMPlanProgMount_CRMPLanSales] FOREIGN KEY([PlanSalesId])
REFERENCES [dbo].[CRMPLanSales] ([Id])
GO
ALTER TABLE [dbo].[CRMPlanProgMonth] CHECK CONSTRAINT [FK_CRMPlanProgMount_CRMPLanSales]
GO
ALTER TABLE [dbo].[CRMPriceQuotation]  WITH CHECK ADD  CONSTRAINT [FK_PriceQuotation_CRMCustomer] FOREIGN KEY([CrmCusId])
REFERENCES [dbo].[CRMCustomer] ([Id])
GO
ALTER TABLE [dbo].[CRMPriceQuotation] CHECK CONSTRAINT [FK_PriceQuotation_CRMCustomer]
GO
ALTER TABLE [dbo].[CRMVisit]  WITH CHECK ADD  CONSTRAINT [FK_CRMVisit_CRMCustomer] FOREIGN KEY([CrmCusId])
REFERENCES [dbo].[CRMCustomer] ([Id])
GO
ALTER TABLE [dbo].[CRMVisit] CHECK CONSTRAINT [FK_CRMVisit_CRMCustomer]
GO
ALTER TABLE [dbo].[CRMVisit]  WITH CHECK ADD  CONSTRAINT [FK_CRMVisit_CRMEventType] FOREIGN KEY([EventTypeId])
REFERENCES [dbo].[CRMEventType] ([Id])
GO
ALTER TABLE [dbo].[CRMVisit] CHECK CONSTRAINT [FK_CRMVisit_CRMEventType]
GO
