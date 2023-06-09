 
SET IDENTITY_INSERT [dbo].[CRMEventType] ON 

GO
INSERT [dbo].[CRMEventType] ([Id], [Name], [Description]) VALUES (1, N'Sinh nhat khach hang', NULL)
GO
INSERT [dbo].[CRMEventType] ([Id], [Name], [Description]) VALUES (2, N'Hoi Cho', N'Hoi Cho')
GO
INSERT [dbo].[CRMEventType] ([Id], [Name], [Description]) VALUES (3, N'Cac dip khac', N'tang qua, hoi thao,...')
GO
SET IDENTITY_INSERT [dbo].[CRMEventType] OFF
GO
SET IDENTITY_INSERT [dbo].[CRMGroup] ON 

GO
INSERT [dbo].[CRMGroup] ([Id], [Name], [Description], [ParentId]) VALUES (1, N'Internal', N'khach hang cty (da co trong ssm truoc do)', NULL)
GO
INSERT [dbo].[CRMGroup] ([Id], [Name], [Description], [ParentId]) VALUES (3, N'Trading Customer', N'trading customers', NULL)
GO
INSERT [dbo].[CRMGroup] ([Id], [Name], [Description], [ParentId]) VALUES (6, N'Free Hand', N'khach tu sales', NULL)
GO
SET IDENTITY_INSERT [dbo].[CRMGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[CRMJobCategory] ON 

GO
INSERT [dbo].[CRMJobCategory] ([Id], [Name], [Description]) VALUES (1, N'Personal', NULL)
GO
INSERT [dbo].[CRMJobCategory] ([Id], [Name], [Description]) VALUES (2, N'Forwarder/Shipping Lines', NULL)
GO
INSERT [dbo].[CRMJobCategory] ([Id], [Name], [Description]) VALUES (4, N'trading/services', NULL)
GO
INSERT [dbo].[CRMJobCategory] ([Id], [Name], [Description]) VALUES (5, N'factory / production', NULL)
GO
SET IDENTITY_INSERT [dbo].[CRMJobCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[CRMPlanProgram] ON 

GO
INSERT [dbo].[CRMPlanProgram] ([Id], [Name], [Description], [IsSystem]) VALUES (1, N'Kế hoạch KH mơi thành thành công', N'Kế hoạch KH mơi thành thành công', 0)
GO
INSERT [dbo].[CRMPlanProgram] ([Id], [Name], [Description], [IsSystem]) VALUES (2, N'KH gửi báo giá lần đầu', N'KH gửi báo giá lần đầu', 0)
GO
INSERT [dbo].[CRMPlanProgram] ([Id], [Name], [Description], [IsSystem]) VALUES (3, N'Kế hoạch số cuộc thăm viếng', N'Kế hoạch số cuộc thăm viếng', 0)
GO
INSERT [dbo].[CRMPlanProgram] ([Id], [Name], [Description], [IsSystem]) VALUES (4, N'Kế hoạch Số lô hàng trong tháng', N'Kế hoạch Số lô hàng trong tháng', 0)
GO
INSERT [dbo].[CRMPlanProgram] ([Id], [Name], [Description], [IsSystem]) VALUES (5, N'Kế Hoach Sales lead /  Bài Viết', N'Kế Hoach Sales lead /  Bài Viết', 0)
GO
SET IDENTITY_INSERT [dbo].[CRMPlanProgram] OFF
GO
SET IDENTITY_INSERT [dbo].[CRMPriceStatus] ON 

GO
INSERT [dbo].[CRMPriceStatus] ([Id], [Name], [Description], [Code], [IsSystem]) VALUES (1, N'Theo dõi', NULL, 1, 1)
GO
INSERT [dbo].[CRMPriceStatus] ([Id], [Name], [Description], [Code], [IsSystem]) VALUES (2, N'Thành công', NULL, 2, 1)
GO
INSERT [dbo].[CRMPriceStatus] ([Id], [Name], [Description], [Code], [IsSystem]) VALUES (3, N'Huỷ', N'Huỷ', 3, 0)
GO
SET IDENTITY_INSERT [dbo].[CRMPriceStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[CRMSource] ON 

GO
INSERT [dbo].[CRMSource] ([Id], [Name], [Description]) VALUES (1, N'Internal', N'Thông tin từ nội bộ')
GO
INSERT [dbo].[CRMSource] ([Id], [Name], [Description]) VALUES (2, N'Yellow Pages', N'khach hang tim kiem tren Facebook')
GO
INSERT [dbo].[CRMSource] ([Id], [Name], [Description]) VALUES (3, N'Marketing Online', NULL)
GO
INSERT [dbo].[CRMSource] ([Id], [Name], [Description]) VALUES (15, N'Another Sales', NULL)
GO
SET IDENTITY_INSERT [dbo].[CRMSource] OFF
GO
SET IDENTITY_INSERT [dbo].[CRMStatus] ON 

GO
INSERT [dbo].[CRMStatus] ([Id], [Name], [Description], [IsSystem], [Code]) VALUES (1, N'Follow', N'Theo doi', 1, 1)
GO
INSERT [dbo].[CRMStatus] ([Id], [Name], [Description], [IsSystem], [Code]) VALUES (2, N'Regular/Familar', N'khách hàng thường xuyên', 1, 2)
GO
INSERT [dbo].[CRMStatus] ([Id], [Name], [Description], [IsSystem], [Code]) VALUES (3, N'Success', N'Khach hang thanh cong', 1, 3)
GO
INSERT [dbo].[CRMStatus] ([Id], [Name], [Description], [IsSystem], [Code]) VALUES (4, N'Cancel', N'Khach hang da ket thuc, khong theo doi tiep', 1, 4)
GO
SET IDENTITY_INSERT [dbo].[CRMStatus] OFF
GO 