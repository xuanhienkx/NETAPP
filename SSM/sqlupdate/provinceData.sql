USE [SCFV5]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 12/5/2016 6:25:40 AM ******/
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
SET IDENTITY_INSERT [dbo].[Province] ON 

GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1, N'Badakhshan', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2, N'Badghis Province', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (3, N'Baghlān', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (4, N'Bāmīān', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (5, N'Farah', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (6, N'Faryab Province', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (7, N'Ghaznī', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (8, N'Ghowr', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (9, N'Helmand Province', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (10, N'Herat Province', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (11, N'Kabul', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (12, N'Kāpīsā', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (13, N'Lowgar', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (14, N'Nangarhār', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (15, N'Nīmrūz', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (16, N'Orūzgān', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (17, N'Kandahār', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (18, N'Kunduz Province', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (19, N'Takhār', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (20, N'Vardak', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (21, N'Zabul Province', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (22, N'Paktīkā', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (23, N'Balkh', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (24, N'Jowzjān', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (25, N'Samangān', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (26, N'Sar-e Pol', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (27, N'Konar', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (28, N'Laghmān', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (29, N'Paktia Province', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (30, N'Khowst', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (31, N'Nūrestān', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (32, N'Parvān', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (33, N'Dāykondī', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (34, N'Panjshīr', N'Asia/Kabul', 1)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (35, N'Berat', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (36, N'Dibër', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (37, N'Durrës', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (38, N'Elbasan', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (39, N'Fier', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (40, N'Gjirokastër', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (41, N'Korçë', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (42, N'Kukës', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (43, N'Lezhë', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (44, N'Shkodër', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (45, N'Tiranë', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (46, N'Vlorë', N'Europe/Tirane', 184)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (47, N'Alger', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (48, N'Batna', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (49, N'Constantine', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (50, N'Médéa', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (51, N'Mostaganem', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (52, N'Oran', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (53, N'Saïda', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (54, N'Sétif', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (55, N'Tiaret', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (56, N'Tizi Ouzou', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (57, N'Tlemcen', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (58, N'Bejaïa', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (59, N'Biskra', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (60, N'Blida', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (61, N'Bouira', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (62, N'Djelfa', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (63, N'Guelma', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (64, N'Jijel', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (65, N'Laghouat', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (66, N'Mascara', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (67, N'Mʼsila', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (68, N'Oum el Bouaghi', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (69, N'Sidi Bel Abbès', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (70, N'Skikda', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (71, N'Tébessa', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (72, N'Adrar', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (73, N'Aïn Defla', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (74, N'Aïn Temouchent', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (75, N'Annaba', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (76, N'Béchar', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (77, N'Bordj Bou Arréridj', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (78, N'Boumerdes', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (79, N'Chlef', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (80, N'El Bayadh', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (81, N'El Oued', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (82, N'El Tarf', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (83, N'Ghardaïa', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (84, N'Illizi', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (85, N'Khenchela', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (86, N'Mila', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (87, N'Naama النعامة', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (88, N'Ouargla', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (89, N'Relizane', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (90, N'Souk Ahras', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (91, N'Tamanghasset', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (92, N'Tindouf', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (93, N'Tipaza', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (94, N'Tissemsilt', N'Africa/Algiers', 3)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (95, N'American Samoa', N'Pacific/Pago_Pago', 186)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (96, N'Parròquia de Canillo', N'Europe/Andorra', 187)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (97, N'Parròquia dʼEncamp', N'Europe/Andorra', 187)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (98, N'Parròquia de la Massana', N'Europe/Andorra', 187)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (99, N'Parròquia dʼOrdino', N'Europe/Andorra', 187)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (100, N'Parròquia de Sant Julià de Lòria', N'Europe/Andorra', 187)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (101, N'Parròquia dʼAndorra la Vella', N'Europe/Andorra', 187)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (102, N'Parròquia dʼEscaldes-Engordany', N'Europe/Andorra', 187)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (103, N'Benguela', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (104, N'Bié', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (105, N'Cabinda', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (106, N'Cuando Cubango', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (107, N'Cuanza Norte', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (108, N'Cuanza Sul', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (109, N'Cunene', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (110, N'Huambo', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (111, N'Huíla', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (112, N'Luanda', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (113, N'Malanje', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (114, N'Namibe', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (115, N'Moxico', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (116, N'Uíge', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (117, N'Zaire', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (118, N'Lunda Norte', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (119, N'Lunda Sul', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (120, N'Bengo', N'Africa/Luanda', 188)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (121, N'Redonda', N'America/Antigua', 189)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (122, N'Barbuda', N'America/Antigua', 189)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (123, N'Saint George', N'America/Antigua', 189)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (124, N'Saint John', N'America/Antigua', 189)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (125, N'Saint Mary', N'America/Antigua', 189)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (126, N'Saint Paul', N'America/Antigua', 189)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (127, N'Saint Peter', N'America/Antigua', 189)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (128, N'Saint Philip', N'America/Antigua', 189)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (129, N'Abşeron', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (130, N'Ağcabǝdi', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (131, N'Ağdam', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (132, N'Ağdaş', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (133, N'Ağstafa', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (134, N'Ağsu', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (135, N'Əli Bayramli', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (136, N'Astara', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (137, N'Baki', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (138, N'Balakǝn', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (139, N'Bǝrdǝ', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (140, N'Beylǝqan', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (141, N'Bilǝsuvar', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (142, N'Cǝbrayıl', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (143, N'Cǝlilabad', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (144, N'Daşkǝsǝn', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (145, N'Dǝvǝçi', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (146, N'Füzuli', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (147, N'Gǝdǝbǝy', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (148, N'Gǝncǝ', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (149, N'Goranboy', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (150, N'Göyçay', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (151, N'Hacıqabul', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (152, N'İmişli', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (153, N'İsmayıllı', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (154, N'Kǝlbǝcǝr', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (155, N'Kürdǝmir', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (156, N'Laçın', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (157, N'Lǝnkǝran', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (158, N'Lǝnkǝran Şǝhǝri', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (159, N'Lerik', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (160, N'Masallı', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (161, N'Mingǝcevir', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (162, N'Naftalan', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (163, N'Nakhichevan', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (164, N'Neftçala', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (165, N'Oğuz', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (166, N'Qǝbǝlǝ', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (167, N'Qǝx', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (168, N'Qazax', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (169, N'Qobustan', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (170, N'Quba', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (171, N'Qubadlı', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (172, N'Qusar', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (173, N'Saatlı', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (174, N'Sabirabad', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (175, N'Şǝki', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (176, N'Salyan', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (177, N'Şamaxı', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (178, N'Şǝmkir', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (179, N'Samux', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (180, N'Siyǝzǝn', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (181, N'Sumqayit', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (182, N'Şuşa', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (183, N'Şuşa Şəhəri', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (184, N'Tǝrtǝr', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (185, N'Tovuz', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (186, N'Ucar', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (187, N'Xaçmaz', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (188, N'Xankǝndi', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (189, N'Xanlar', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (190, N'Xızı', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (191, N'Xocalı', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (192, N'Xocavǝnd', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (193, N'Yardımlı', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (194, N'Yevlax', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (195, N'Zǝngilan', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (196, N'Zaqatala', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (197, N'Zǝrdab', N'Asia/Baku', 190)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (198, N'Buenos Aires', N'America/Argentina/Buenos_Aires', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (199, N'Catamarca', N'America/Argentina/Catamarca', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (200, N'Chaco', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (201, N'Chubut', N'America/Argentina/Catamarca', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (202, N'Córdoba', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (203, N'Corrientes', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (204, N'Distrito Federal', N'America/Argentina/Buenos_Aires', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (205, N'Entre Ríos', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (206, N'Formosa', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (207, N'Jujuy', N'America/Argentina/Jujuy', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (208, N'La Pampa', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (209, N'La Rioja', N'America/Argentina/La_Rioja', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (210, N'Mendoza', N'America/Argentina/Mendoza', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (211, N'Misiones', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (212, N'Neuquén', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (213, N'Río Negro', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (214, N'Salta', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (215, N'San Juan', N'America/Argentina/San_Juan', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (216, N'San Luis', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (217, N'Santa Cruz', N'America/Argentina/Rio_Gallegos', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (218, N'Santa Fe', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (219, N'Santiago del Estero', N'America/Argentina/Cordoba', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (220, N'Tierra del Fuego, Antártida e Islas del Atlán', N'America/Argentina/Ushuaia', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (221, N'Tucumán', N'America/Argentina/Tucuman', 4)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (222, N'Australian Capital Territory', N'Australia/Sydney', 6)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (223, N'New South Wales', N'Australia/Sydney', 6)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (224, N'Northern Territory', N'Australia/Darwin', 6)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (225, N'Queensland', N'Australia/Brisbane', 6)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (226, N'South Australia', N'Australia/Adelaide', 6)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (227, N'Tasmania', N'Australia/Hobart', 6)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (228, N'Victoria', N'Australia/Melbourne', 6)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (229, N'Western Australia', N'Australia/Perth', 6)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (230, N'Burgenland', N'Europe/Vienna', 7)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (231, N'Carinthia', N'Europe/Vienna', 7)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (232, N'Lower Austria', N'Europe/Vienna', 7)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (233, N'Upper Austria', N'Europe/Vienna', 7)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (234, N'Salzburg', N'Europe/Vienna', 7)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (235, N'Styria', N'Europe/Vienna', 7)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (236, N'Tyrol', N'Europe/Vienna', 7)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (237, N'Vorarlberg', N'Europe/Vienna', 7)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (238, N'Vienna', N'Europe/Vienna', 7)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (239, N'Bimini', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (240, N'Cat Island', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (241, N'Inagua', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (242, N'Long Island', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (243, N'Mayaguana', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (244, N'Ragged Island', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (245, N'Harbour Island, Eleuthera', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (246, N'North Abaco', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (247, N'Acklins', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (248, N'City of Freeport, Grand Bahama', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (249, N'South Andros', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (250, N'Hope Town, Abaco', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (251, N'Mangrove Cay, Andros', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (252, N'Mooreʼs Island, Abaco', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (253, N'Rum Cay', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (254, N'North Andros', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (255, N'North Eleuthera', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (256, N'South Eleuthera', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (257, N'South Abaco', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (258, N'San Salvador', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (259, N'Berry Islands', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (260, N'Black Point, Exuma', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (261, N'Central Abaco', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (262, N'Central Andros', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (263, N'Central Eleuthera', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (264, N'Crooked Island', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (265, N'East Grand Bahama', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (266, N'Exuma', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (267, N'Grand Cay, Abaco', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (268, N'Spanish Wells, Eleuthera', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (269, N'West Grand Bahama', N'America/Nassau', 13468)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (270, N'Southern Governate', N'Asia/Bahrain', 9)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (271, N'Northern Governate', N'Asia/Bahrain', 9)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (272, N'Capital Governate', N'Asia/Bahrain', 9)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (273, N'Central Governate', N'Asia/Bahrain', 9)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (274, N'Muharraq Governate', N'Asia/Bahrain', 9)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (275, N'BG80', N'Asia/Dhaka', 10)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (276, N'Dhaka', N'Asia/Dhaka', 10)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (277, N'Khulna', N'Asia/Dhaka', 10)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (278, N'Rājshāhi', N'Asia/Dhaka', 10)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (279, N'Chittagong', N'Asia/Dhaka', 10)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (280, N'Barisāl', N'Asia/Dhaka', 10)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (281, N'Sylhet', N'Asia/Dhaka', 10)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (282, N'Aragatsotn', N'Asia/Yerevan', 13469)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (283, N'Ararat', N'Asia/Yerevan', 13469)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (284, N'Armavir', N'Asia/Yerevan', 13469)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (285, N'Gegharkʼunikʼ', N'Asia/Yerevan', 13469)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (286, N'Kotaykʼ', N'Asia/Yerevan', 13469)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (287, N'Lorri', N'Asia/Yerevan', 13469)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (288, N'Shirak', N'Asia/Yerevan', 13469)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (289, N'Syunikʼ', N'Asia/Yerevan', 13469)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (290, N'Tavush', N'Asia/Yerevan', 13469)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (291, N'Vayotsʼ Dzor', N'Asia/Yerevan', 13469)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (292, N'Yerevan', N'Asia/Yerevan', 13469)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (293, N'Christ Church', N'America/Barbados', 13470)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (294, N'Saint Andrew', N'America/Barbados', 13470)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (295, N'Saint George', N'America/Barbados', 13470)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (296, N'Saint James', N'America/Barbados', 13470)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (297, N'Saint John', N'America/Barbados', 13470)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (298, N'Saint Joseph', N'America/Barbados', 13470)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (299, N'Saint Lucy', N'America/Barbados', 13470)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (300, N'Saint Michael', N'America/Barbados', 13470)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (301, N'Saint Peter', N'America/Barbados', 13470)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (302, N'Saint Philip', N'America/Barbados', 13470)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (303, N'Saint Thomas', N'America/Barbados', 13470)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (304, N'Bruxelles-Capitale', N'Europe/Brussels', 12)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (305, N'Flanders', N'Europe/Brussels', 12)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (306, N'Wallonia', N'Europe/Brussels', 12)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (307, N'Devonshire', N'Atlantic/Bermuda', 13471)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (308, N'Hamilton (parish)', N'Atlantic/Bermuda', 13471)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (309, N'Hamilton (city)', N'Atlantic/Bermuda', 13471)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (310, N'Paget', N'Atlantic/Bermuda', 13471)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (311, N'Pembroke', N'Atlantic/Bermuda', 13471)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (312, N'Saint Georgeʼs (parish)', N'Atlantic/Bermuda', 13471)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (313, N'Saint Georgeʼs (city)', N'Atlantic/Bermuda', 13471)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (314, N'Sandys', N'Atlantic/Bermuda', 13471)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (315, N'Smithʼs', N'Atlantic/Bermuda', 13471)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (316, N'Southampton', N'Atlantic/Bermuda', 13471)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (317, N'Warwick', N'Atlantic/Bermuda', 13471)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (318, N'Bumthang', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (319, N'Chhukha', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (320, N'Chirang', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (321, N'Daga', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (322, N'Geylegphug', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (323, N'Ha', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (324, N'Lhuntshi', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (325, N'Mongar', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (326, N'Paro District', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (327, N'Pemagatsel', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (328, N'Samchi', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (329, N'Samdrup Jongkhar District', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (330, N'Shemgang', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (331, N'Tashigang', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (332, N'Thimphu', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (333, N'Tongsa', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (334, N'Wangdi Phodrang', N'Asia/Thimphu', 13472)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (335, N'Chuquisaca', N'America/La_Paz', 13473)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (336, N'Cochabamba', N'America/La_Paz', 13473)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (337, N'El Beni', N'America/La_Paz', 13473)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (338, N'La Paz', N'America/La_Paz', 13473)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (339, N'Oruro', N'America/La_Paz', 13473)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (340, N'Pando', N'America/La_Paz', 13473)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (341, N'Potosí', N'America/La_Paz', 13473)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (342, N'Santa Cruz', N'America/La_Paz', 13473)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (343, N'Tarija', N'America/La_Paz', 13473)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (344, N'Federation of Bosnia and Herzegovina', N'Europe/Sarajevo', 13474)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (345, N'Republika Srpska', N'Europe/Sarajevo', 13474)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (346, N'Brčko', N'Europe/Sarajevo', 13474)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (347, N'Central', N'Africa/Gaborone', 13475)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (348, N'Chobe', N'Africa/Gaborone', 13475)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (349, N'Ghanzi', N'Africa/Gaborone', 13475)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (350, N'Kgalagadi', N'Africa/Gaborone', 13475)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (351, N'Kgatleng', N'Africa/Gaborone', 13475)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (352, N'Kweneng', N'Africa/Gaborone', 13475)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (353, N'Ngamiland', N'Africa/Gaborone', 13475)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (354, N'North East', N'Africa/Gaborone', 13475)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (355, N'South East', N'Africa/Gaborone', 13475)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (356, N'Southern', N'Africa/Gaborone', 13475)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (357, N'North West', N'Africa/Gaborone', 13475)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (358, N'Acre', N'America/Rio_Branco', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (359, N'Alagoas', N'America/Maceio', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (360, N'Amapá', N'America/Belem', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (361, N'Estado do Amazonas', N'America/Manaus', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (362, N'Bahia', N'America/Bahia', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (363, N'Ceará', N'America/Fortaleza', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (364, N'Distrito Federal', N'America/Sao_Paulo', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (365, N'Espírito Santo', N'America/Sao_Paulo', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (366, N'Fernando de Noronha', N'America/Recife', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (367, N'Goias', N'America/Sao_Paulo', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (368, N'Mato Grosso do Sul', N'America/Campo_Grande', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (369, N'Maranhão', N'America/Fortaleza', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (370, N'Mato Grosso', N'America/Cuiaba', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (371, N'Minas Gerais', N'America/Sao_Paulo', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (372, N'Pará', N'America/Belem', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (373, N'Paraíba', N'America/Fortaleza', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (374, N'Paraná', N'America/Sao_Paulo', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (375, N'Pernambuco', N'America/Noronha', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (376, N'Piauí', N'America/Fortaleza', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (377, N'State of Rio de Janeiro', N'America/Sao_Paulo', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (378, N'Rio Grande do Norte', N'America/Fortaleza', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (379, N'Rio Grande do Sul', N'America/Sao_Paulo', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (380, N'Rondônia', N'America/Porto_Velho', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (381, N'Roraima', N'America/Boa_Vista', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (382, N'Santa Catarina', N'America/Sao_Paulo', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (383, N'São Paulo', N'America/Sao_Paulo', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (384, N'Sergipe', N'America/Maceio', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (385, N'Estado de Goiás', N'America/Sao_Paulo', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (386, N'Tocantins', N'America/Araguaina', 17)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (387, N'Belize', N'America/Belize', 13)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (388, N'Cayo', N'America/Belize', 13)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (389, N'Corozal', N'America/Belize', 13)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (390, N'Orange Walk', N'America/Belize', 13)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (391, N'Stann Creek', N'America/Belize', 13)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (392, N'Toledo', N'America/Belize', 13)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (393, N'British Indian Ocean Territory', N'Indian/Chagos', 13477)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (394, N'Malaita', N'Pacific/Guadalcanal', 13478)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (395, N'Western', N'Pacific/Guadalcanal', 13478)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (396, N'Central', N'Pacific/Guadalcanal', 13478)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (397, N'Guadalcanal', N'Pacific/Guadalcanal', 13478)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (398, N'Isabel', N'Pacific/Guadalcanal', 13478)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (399, N'Makira', N'Pacific/Guadalcanal', 13478)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (400, N'Temotu', N'Pacific/Guadalcanal', 13478)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (401, N'Central Province', N'Pacific/Guadalcanal', 13478)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (402, N'Choiseul', N'Pacific/Guadalcanal', 13478)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (403, N'Rennell and Bellona', N'Pacific/Guadalcanal', 13478)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (404, N'British Virgin Islands', N'America/Tortola', 13479)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (405, N'Belait', N'Asia/Brunei', 13480)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (406, N'Brunei and Muara', N'Asia/Brunei', 13480)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (407, N'Temburong', N'Asia/Brunei', 13480)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (408, N'Tutong', N'Asia/Brunei', 13480)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (409, N'Burgas', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (410, N'Grad', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (411, N'Khaskovo', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (412, N'Lovech', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (413, N'Mikhaylovgrad', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (414, N'Plovdiv', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (415, N'Razgrad', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (416, N'Sofiya', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (417, N'Varna', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (418, N'Blagoevgrad', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (419, N'Dobrich', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (420, N'Gabrovo', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (421, N'Oblast Sofiya-Grad', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (422, N'Kŭrdzhali', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (423, N'Kyustendil', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (424, N'Montana', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (425, N'Pazardzhit', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (426, N'Pernik', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (427, N'Pleven', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (428, N'Ruse', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (429, N'Shumen', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (430, N'Silistra', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (431, N'Sliven', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (432, N'Smolyan', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (433, N'Stara Zagora', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (434, N'Tŭrgovishte', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (435, N'Veliko Tŭrnovo', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (436, N'Vidin', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (437, N'Vratsa', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (438, N'Yambol', N'Europe/Sofia', 19)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (439, N'Rakhine State', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (440, N'Chin State', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (441, N'Ayeyarwady', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (442, N'Kachin State', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (443, N'Kayin State', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (444, N'Kayah State', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (445, N'Magwe', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (446, N'Mandalay', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (447, N'Pegu', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (448, N'Sagain', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (449, N'Shan State', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (450, N'Tanintharyi', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (451, N'Mon State', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (452, N'Rangoon', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (453, N'Magway', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (454, N'Bago', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (455, N'Yangon', N'Asia/Rangoon', 183)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (456, N'Bujumbura', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (457, N'Bubanza', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (458, N'Bururi', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (459, N'Cankuzo', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (460, N'Cibitoke', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (461, N'Gitega', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (462, N'Karuzi', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (463, N'Kayanza', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (464, N'Kirundo', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (465, N'Makamba', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (466, N'Muyinga', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (467, N'Ngozi', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (468, N'Rutana', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (469, N'Ruyigi', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (470, N'Muramvya', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (471, N'Mwaro', N'Africa/Bujumbura', 13481)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (472, N'Brestskaya Voblastsʼ', N'Europe/Minsk', 13482)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (473, N'Homyelʼskaya Voblastsʼ', N'Europe/Minsk', 13482)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (474, N'Hrodzyenskaya Voblastsʼ', N'Europe/Minsk', 13482)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (475, N'Mahilyowskaya Voblastsʼ', N'Europe/Minsk', 13482)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (476, N'Horad Minsk', N'Europe/Minsk', 13482)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (477, N'Minskaya Voblastsʼ', N'Europe/Minsk', 13482)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (478, N'Vitsyebskaya Voblastsʼ', N'Europe/Minsk', 13482)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (479, N'Krŏng Preăh Seihânŭ', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (480, N'Kâmpóng Cham', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (481, N'Kâmpóng Chhnăng', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (482, N'Khétt Kâmpóng Spœ', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (483, N'Kâmpóng Thum', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (484, N'Kândal', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (485, N'Kaôh Kŏng', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (486, N'Krâchéh', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (487, N'Môndól Kiri', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (488, N'Phnum Penh', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (489, N'Poŭthĭsăt', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (490, N'Preăh Vihéar', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (491, N'Prey Vêng', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (492, N'Stœ̆ng Trêng', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (493, N'Svay Riĕng', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (494, N'Takêv', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (495, N'Kâmpôt', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (496, N'Phnum Pénh', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (497, N'Rôtânăh Kiri', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (498, N'Siĕm Réab', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (499, N'Bantéay Méan Cheăy', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (500, N'Kêb', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (501, N'Ŏtdâr Méan Cheăy', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (502, N'Preăh Seihânŭ', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (503, N'Bătdâmbâng', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (504, N'Palĭn', N'Asia/Phnom_Penh', 20)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (505, N'Est', N'Africa/Douala', 13483)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (506, N'Littoral', N'Africa/Douala', 13483)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (507, N'North-West Province', N'Africa/Douala', 13483)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (508, N'Ouest', N'Africa/Douala', 13483)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (509, N'South-West Province', N'Africa/Douala', 13483)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (510, N'Adamaoua', N'Africa/Douala', 13483)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (511, N'Centre', N'Africa/Douala', 13483)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (512, N'Extreme-Nord', N'Africa/Douala', 13483)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (513, N'North Province', N'Africa/Douala', 13483)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (514, N'South Province', N'Africa/Douala', 13483)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (515, N'Alberta', N'America/Edmonton', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (516, N'British Columbia', N'America/Vancouver', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (517, N'Manitoba', N'America/Winnipeg', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (518, N'New Brunswick', N'America/Halifax', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (519, N'Newfoundland and Labrador', N'America/Goose_Bay', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (520, N'Nova Scotia', N'America/Halifax', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (521, N'Ontario', N'America/Toronto', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (522, N'Prince Edward Island', N'America/Halifax', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (523, N'Quebec', N'America/Montreal', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (524, N'Saskatchewan', N'America/Winnipeg', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (525, N'Yukon', N'America/Whitehorse', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (526, N'Northwest Territories', N'America/Yellowknife', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (527, N'Nunavut', N'America/Rankin_Inlet', 21)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (528, N'Boa Vista', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (529, N'Brava', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (530, N'Maio', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (531, N'Paul', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (532, N'Praia', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (533, N'Ribeira Grande', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (534, N'Sal', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (535, N'Santa Catarina', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (536, N'São Nicolau', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (537, N'São Vicente', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (538, N'Tarrafal', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (539, N'Mosteiros', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (540, N'Santa Cruz', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (541, N'São Domingos', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (542, N'São Filipe', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (543, N'São Miguel', N'Atlantic/Cape_Verde', 13484)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (544, N'Creek', N'America/Cayman', 13485)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (545, N'Eastern', N'America/Cayman', 13485)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (546, N'Midland', N'America/Cayman', 13485)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (547, N'South Town', N'America/Cayman', 13485)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (548, N'Spot Bay', N'America/Cayman', 13485)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (549, N'Stake Bay', N'America/Cayman', 13485)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (550, N'West End', N'America/Cayman', 13485)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (551, N'Western', N'America/Cayman', 13485)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (552, N'Bamingui-Bangoran', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (553, N'Basse-Kotto', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (554, N'Haute-Kotto', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (555, N'Mambéré-Kadéï', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (556, N'Haut-Mbomou', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (557, N'Kémo', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (558, N'Lobaye', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (559, N'Mbomou', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (560, N'Nana-Mambéré', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (561, N'Ouaka', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (562, N'Ouham', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (563, N'Ouham-Pendé', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (564, N'Vakaga', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (565, N'Nana-Grébizi', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (566, N'Sangha-Mbaéré', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (567, N'Ombella-Mpoko', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (568, N'Bangui', N'Africa/Bangui', 13486)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (569, N'Central', N'Asia/Colombo', 109)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (570, N'North Central', N'Asia/Colombo', 109)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (571, N'North Eastern', N'Asia/Colombo', 109)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (572, N'North Western', N'Asia/Colombo', 109)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (573, N'Sabaragamuwa', N'Asia/Colombo', 109)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (574, N'Southern', N'Asia/Colombo', 109)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (575, N'Uva', N'Asia/Colombo', 109)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (576, N'Western', N'Asia/Colombo', 109)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (577, N'Batha', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (578, N'Biltine', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (579, N'Borkou-Ennedi-Tibesti', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (580, N'Chari-Baguirmi', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (581, N'Guéra', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (582, N'Kanem', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (583, N'Lac', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (584, N'Logone Occidental', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (585, N'Logone Oriental', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (586, N'Mayo-Kébbi', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (587, N'Moyen-Chari', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (588, N'Ouaddaï', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (589, N'Salamat', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (590, N'Tandjilé', N'Africa/Ndjamena', 13487)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (591, N'Valparaíso', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (592, N'Aisén del General Carlos Ibáñez del Campo', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (593, N'Antofagasta', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (594, N'Araucanía', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (595, N'Atacama', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (596, N'Bío-Bío', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (597, N'Coquimbo', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (598, N'Libertador General Bernardo OʼHiggins', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (599, N'Los Lagos', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (600, N'Magallanes y Antártica Chilena', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (601, N'Maule', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (602, N'Región Metropolitana', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (603, N'Tarapaca', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (604, N'Tarapacá', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (605, N'Región de Arica y Parinacota', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (606, N'Región de Los Ríos', N'America/Santiago', 23)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (607, N'Anhui', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (608, N'Zhejiang', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (609, N'Jiangxi', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (610, N'Jiangsu', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (611, N'Jilin', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (612, N'Qinghai', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (613, N'Fujian', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (614, N'Heilongjiang', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (615, N'Henan', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (616, N'disputed', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (617, N'Hebei', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (618, N'Hunan Province', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (619, N'Hubei', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (620, N'Xinjiang', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (621, N'Xizang', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (622, N'Gansu', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (623, N'Guangxi', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (624, N'Guizhou', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (625, N'Liaoning Province', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (626, N'Inner Mongolia', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (627, N'Ningxia', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (628, N'Beijing', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (629, N'Shanghai', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (630, N'Shanxi', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (631, N'Shandong', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (632, N'Shaanxi', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (633, N'Tianjin', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (634, N'Yunnan Province', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (635, N'Guangdong', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (636, N'Hainan Province', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (637, N'Sichuan', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (638, N'Chongqing', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (639, N'PF99', N'Asia/Ho_Chi_Minh', 88)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (640, N'Fukien', N'Asia/Taipei', 113)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (641, N'Kaohsiung', N'Asia/Taipei', 113)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (642, N'Taipei', N'Asia/Taipei', 113)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (643, N'Taiwan', N'Asia/Taipei', 113)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (644, N'Christmas Island', N'Indian/Christmas', 13488)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (645, N'Cocos (Keeling) Islands', N'Indian/Cocos', 13489)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (646, N'Amazonas', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (647, N'Antioquia', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (648, N'Arauca', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (649, N'Atlántico', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (650, N'Bolívar', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (651, N'Boyacá', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (652, N'Caldas', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (653, N'Caquetá', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (654, N'Cauca', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (655, N'Cesar', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (656, N'Chocó', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (657, N'Córdoba', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (658, N'Guaviare', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (659, N'Guainía', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (660, N'Huila', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (661, N'La Guajira', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (662, N'Magdalena', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (663, N'Meta', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (664, N'Nariño', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (665, N'Norte de Santander', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (666, N'Putumayo', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (667, N'Quindío', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (668, N'Risaralda', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (669, N'Archipiélago de San Andrés, Providencia y San', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (670, N'Santander', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (671, N'Sucre', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (672, N'Tolima', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (673, N'Valle del Cauca', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (674, N'Vaupés', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (675, N'Vichada', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (676, N'Casanare', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (677, N'Cundinamarca', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (678, N'Bogota D.C.', N'America/Bogota', 24)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (679, N'Anjouan', N'Indian/Comoro', 13490)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (680, N'Grande Comore', N'Indian/Comoro', 13490)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (681, N'Mohéli', N'Indian/Comoro', 13490)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (682, N'Mayotte', N'Indian/Mayotte', 13491)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (683, N'Bouenza', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (684, N'CF03', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (685, N'Kouilou', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (686, N'Lékoumou', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (687, N'Likouala', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (688, N'Niari', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (689, N'Plateaux', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (690, N'Sangha', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (691, N'Pool', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (692, N'Brazzaville', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (693, N'Cuvette', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (694, N'Cuvette-Ouest', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (695, N'Pointe-Noire', N'Africa/Brazzaville', 13492)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (696, N'Bandundu', N'Africa/Kinshasa', 13493)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (697, N'Équateur', N'Africa/Kinshasa', 13493)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (698, N'Kasaï-Occidental', N'Africa/Lubumbashi', 13493)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (699, N'Kasaï-Oriental', N'Africa/Lubumbashi', 13493)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (700, N'Katanga', N'Africa/Lubumbashi', 13493)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (701, N'Kinshasa', N'Africa/Kinshasa', 13493)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (702, N'Bas-Congo', N'Africa/Kinshasa', 13493)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (703, N'Orientale', N'Africa/Lubumbashi', 13493)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (704, N'Maniema', N'Africa/Lubumbashi', 13493)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (705, N'Nord-Kivu', N'Africa/Lubumbashi', 13493)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (706, N'Sud-Kivu', N'Africa/Lubumbashi', 13493)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (707, N'Cook Islands', N'Pacific/Rarotonga', 13494)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (708, N'Alajuela', N'America/Costa_Rica', 25)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (709, N'Cartago', N'America/Costa_Rica', 25)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (710, N'Guanacaste', N'America/Costa_Rica', 25)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (711, N'Heredia', N'America/Costa_Rica', 25)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (712, N'Limón', N'America/Costa_Rica', 25)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (713, N'Puntarenas', N'America/Costa_Rica', 25)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (714, N'San José', N'America/Costa_Rica', 25)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (715, N'Bjelovarsko-Bilogorska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (716, N'Brodsko-Posavska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (717, N'Dubrovačko-Neretvanska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (718, N'Istarska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (719, N'Karlovačka', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (720, N'Koprivničko-Križevačka', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (721, N'Krapinsko-Zagorska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (722, N'Ličko-Senjska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (723, N'Međimurska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (724, N'Osječko-Baranjska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (725, N'Požeško-Slavonska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (726, N'Primorsko-Goranska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (727, N'Šibensko-Kniniska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (728, N'Sisačko-Moslavačka', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (729, N'Splitsko-Dalmatinska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (730, N'Varaždinska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (731, N'Virovitičk-Podravska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (732, N'Vukovarsko-Srijemska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (733, N'Zadarska', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (734, N'Zagrebačka', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (735, N'Grad Zagreb', N'Europe/Zagreb', 13495)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (736, N'Pinar del Río', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (737, N'Ciudad de La Habana', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (738, N'Matanzas', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (739, N'Isla de la Juventud', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (740, N'Camagüey', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (741, N'Ciego de Ávila', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (742, N'Cienfuegos', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (743, N'Granma', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (744, N'Guantánamo', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (745, N'La Habana', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (746, N'Holguín', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (747, N'Las Tunas', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (748, N'Sancti Spíritus', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (749, N'Santiago de Cuba', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (750, N'Villa Clara', N'America/Havana', 13496)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (751, N'Famagusta', N'Asia/Nicosia', 13497)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (752, N'Kyrenia', N'Asia/Nicosia', 13497)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (753, N'Larnaca', N'Asia/Nicosia', 13497)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (754, N'Nicosia', N'Asia/Nicosia', 13497)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (755, N'Limassol', N'Asia/Nicosia', 13497)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (756, N'Paphos', N'Asia/Nicosia', 13497)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (757, N'Hradec Kralove', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (758, N'Jablonec nad Nisou', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (759, N'Jiein', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (760, N'Jihlava', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (761, N'Kolin', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (762, N'Liberec', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (763, N'Melnik', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (764, N'Mlada Boleslav', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (765, N'Nachod', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (766, N'Nymburk', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (767, N'Pardubice', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (768, N'Hlavní Mesto Praha', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (769, N'Semily', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (770, N'Trutnov', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (771, N'South Moravian Region', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (772, N'Jihočeský Kraj', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (773, N'Vysočina', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (774, N'Karlovarský Kraj', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (775, N'Královéhradecký Kraj', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (776, N'Liberecký Kraj', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (777, N'Olomoucký Kraj', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (778, N'Moravskoslezský Kraj', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (779, N'Pardubický Kraj', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (780, N'Plzeňský Kraj', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (781, N'Středočeský Kraj', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (782, N'Ústecký Kraj', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (783, N'Zlínský Kraj', N'Europe/Prague', 27)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (784, N'Atakora', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (785, N'Atlantique', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (786, N'Alibori', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (787, N'Borgou', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (788, N'Collines', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (789, N'Kouffo', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (790, N'Donga', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (791, N'Littoral', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (792, N'Mono', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (793, N'Ouémé', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (794, N'Plateau', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (795, N'Zou', N'Africa/Porto-Novo', 13498)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (796, N'Århus', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (797, N'Bornholm', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (798, N'Frederiksborg', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (799, N'Fyn', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (800, N'Copenhagen city', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (801, N'København', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (802, N'Nordjylland', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (803, N'Ribe', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (804, N'Ringkøbing', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (805, N'Roskilde', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (806, N'Sønderjylland', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (807, N'Storstrøm', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (808, N'Vejle', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (809, N'Vestsjælland', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (810, N'Viborg', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (811, N'Fredriksberg', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (812, N'Capital Region', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (813, N'Central Jutland', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (814, N'North Jutland', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (815, N'Region Zealand', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (816, N'Region South Denmark', N'Europe/Copenhagen', 28)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (817, N'Saint Andrew', N'America/Dominica', 13499)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (818, N'Saint David', N'America/Dominica', 13499)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (819, N'Saint George', N'America/Dominica', 13499)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (820, N'Saint John', N'America/Dominica', 13499)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (821, N'Saint Joseph', N'America/Dominica', 13499)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (822, N'Saint Luke', N'America/Dominica', 13499)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (823, N'Saint Mark', N'America/Dominica', 13499)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (824, N'Saint Patrick', N'America/Dominica', 13499)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (825, N'Saint Paul', N'America/Dominica', 13499)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (826, N'Saint Peter', N'America/Dominica', 13499)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (827, N'Azua', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (828, N'Baoruco', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (829, N'Barahona', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (830, N'Dajabón', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (831, N'Duarte', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (832, N'Espaillat', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (833, N'Independencia', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (834, N'La Altagracia', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (835, N'Elías Piña', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (836, N'La Romana', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (837, N'María Trinidad Sánchez', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (838, N'Monte Cristi', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (839, N'Pedernales', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (840, N'Puerto Plata', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (841, N'Salcedo', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (842, N'Samaná', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (843, N'Sánchez Ramírez', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (844, N'San Juan', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (845, N'San Pedro de Macorís', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (846, N'Santiago', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (847, N'Santiago Rodríguez', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (848, N'Valverde', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (849, N'El Seíbo', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (850, N'Hato Mayor', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (851, N'La Vega', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (852, N'Monseñor Nouel', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (853, N'Monte Plata', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (854, N'San Cristóbal', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (855, N'Distrito Nacional', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (856, N'Peravia', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (857, N'San José de Ocoa', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (858, N'Santo Domingo', N'America/Santo_Domingo', 29)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (859, N'Galápagos', N'Pacific/Galapagos', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (860, N'Azuay', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (861, N'Bolívar', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (862, N'Cañar', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (863, N'Carchi', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (864, N'Chimborazo', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (865, N'Cotopaxi', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (866, N'El Oro', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (867, N'Esmeraldas', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (868, N'Guayas', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (869, N'Imbabura', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (870, N'Loja', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (871, N'Los Ríos', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (872, N'Manabí', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (873, N'Morona-Santiago', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (874, N'Napo', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (875, N'Pastaza', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (876, N'Pichincha', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (877, N'Tungurahua', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (878, N'Zamora-Chinchipe', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (879, N'Sucumbios', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (880, N'Orellana', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (881, N'Provincia de Santa Elena', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (882, N'Provincia de Santo Domingo de los Tsáchilas', N'America/Guayaquil', 30)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (883, N'Ahuachapán', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (884, N'Cabañas', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (885, N'Chalatenango', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (886, N'Cuscatlán', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (887, N'La Libertad', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (888, N'La Paz', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (889, N'La Unión', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (890, N'Morazán', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (891, N'San Miguel', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (892, N'San Salvador', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (893, N'Santa Ana', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (894, N'San Vicente', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (895, N'Sonsonate', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (896, N'Usulután', N'America/El_Salvador', 32)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (897, N'Annobón', N'Africa/Malabo', 13500)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (898, N'Bioko Norte', N'Africa/Malabo', 13500)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (899, N'Bioko Sur', N'Africa/Malabo', 13500)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (900, N'Centro Sur', N'Africa/Malabo', 13500)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (901, N'Kié-Ntem', N'Africa/Malabo', 13500)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (902, N'Litoral', N'Africa/Malabo', 13500)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (903, N'Wele-Nzas', N'Africa/Malabo', 13500)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (904, N'Arsi', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (905, N'Gonder', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (906, N'Bale', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (907, N'Eritrea', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (908, N'Gamo Gofa', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (909, N'Gojam', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (910, N'Harerge', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (911, N'Ilubabor', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (912, N'Kefa', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (913, N'Addis Abeba', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (914, N'Sidamo', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (915, N'Tigray', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (916, N'Welega Kifle Hager', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (917, N'Welo', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (918, N'Adis Abeba', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (919, N'Asosa', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (920, N'Borena', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (921, N'Debub Gonder', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (922, N'Debub Shewa', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (923, N'Debub Welo', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (924, N'Dire Dawa', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (925, N'Gambela', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (926, N'Metekel', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (927, N'Mirab Gojam', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (928, N'Mirab Harerge', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (929, N'Mirab Shewa', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (930, N'Misrak Gojam', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (931, N'Misrak Harerge', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (932, N'Nazret', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (933, N'Ogaden', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (934, N'Omo', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (935, N'Semen Gonder', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (936, N'Semen Shewa', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (937, N'Semen Welo', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (938, N'Welega', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (939, N'Ādīs Ābeba', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (940, N'Āfar', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (941, N'Āmara', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (942, N'Bīnshangul Gumuz', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (943, N'Dirē Dawa', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (944, N'Gambēla Hizboch', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (945, N'Hārerī Hizb', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (946, N'Oromīya', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (947, N'Sumalē', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (948, N'YeDebub Bihēroch Bihēreseboch na Hizboch', N'Africa/Addis_Ababa', 34)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (949, N'Ānseba', N'Africa/Asmara', 13501)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (950, N'Debub', N'Africa/Asmara', 13501)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (951, N'Debubawī Kʼeyih Bahrī', N'Africa/Asmara', 13501)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (952, N'Gash Barka', N'Africa/Asmara', 13501)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (953, N'Maʼākel', N'Africa/Asmara', 13501)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (954, N'Semēnawī Kʼeyih Bahrī', N'Africa/Asmara', 13501)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (955, N'Harjumaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (956, N'Hiiumaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (957, N'Ida-Virumaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (958, N'Järvamaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (959, N'Jõgevamaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (960, N'Läänemaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (961, N'Lääne-Virumaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (962, N'Pärnumaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (963, N'Põlvamaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (964, N'Raplamaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (965, N'Saaremaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (966, N'Tartumaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (967, N'Valgamaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (968, N'Viljandimaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (969, N'Võrumaa', N'Europe/Tallinn', 13502)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (970, N'Norðoyar region', N'Atlantic/Faroe', 13503)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (971, N'Eysturoy region', N'Atlantic/Faroe', 13503)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (972, N'Sandoy region', N'Atlantic/Faroe', 13503)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (973, N'Streymoy region', N'Atlantic/Faroe', 13503)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (974, N'Suðuroy region', N'Atlantic/Faroe', 13503)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (975, N'Vágar region', N'Atlantic/Faroe', 13503)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (976, N'Falkland Islands (Islas Malvinas)', N'Atlantic/Stanley', 13504)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (977, N'South Georgia and The South Sandwich Islands', N'Atlantic/South_Georgia', 13505)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (978, N'Central', N'Pacific/Fiji', 13506)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (979, N'Eastern', N'Pacific/Fiji', 13506)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (980, N'Northern', N'Pacific/Fiji', 13506)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (981, N'Rotuma', N'Pacific/Fiji', 13506)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (982, N'Western', N'Pacific/Fiji', 13506)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (983, N'Åland', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (984, N'Hame', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (985, N'Keski-Suomi', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (986, N'Kuopio', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (987, N'Kymi', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (988, N'Lapponia', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (989, N'Mikkeli', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (990, N'Oulu', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (991, N'Pohjois-Karjala', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (992, N'Turku ja Pori', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (993, N'Uusimaa', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (994, N'Vaasa', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (995, N'Southern Finland', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (996, N'Eastern Finland', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (997, N'Western Finland', N'Europe/Helsinki', 36)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (998, N'Aquitaine', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (999, N'Auvergne', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1000, N'Basse-Normandie', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1001, N'Bourgogne', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1002, N'Brittany', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1003, N'Centre', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1004, N'Champagne-Ardenne', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1005, N'Corsica', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1006, N'Franche-Comté', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1007, N'Haute-Normandie', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1008, N'Île-de-France', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1009, N'Languedoc-Roussillon', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1010, N'Limousin', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1011, N'Lorraine', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1012, N'Midi-Pyrénées', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1013, N'Nord-Pas-de-Calais', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1014, N'Pays de la Loire', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1015, N'Picardie', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1016, N'Poitou-Charentes', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1017, N'Provence-Alpes-Côte dʼAzur', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1018, N'Rhône-Alpes', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1019, N'Alsace', N'Europe/Paris', 37)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1020, N'Baden-Württemberg', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1021, N'Bavaria', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1022, N'Bremen', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1023, N'Hamburg', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1024, N'Hesse', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1025, N'Lower Saxony', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1026, N'North Rhine-Westphalia', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1027, N'Rhineland-Palatinate', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1028, N'Saarland', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1029, N'Schleswig-Holstein', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1030, N'Brandenburg', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1031, N'Mecklenburg-Vorpommern', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1032, N'Saxony', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1033, N'Saxony-Anhalt', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1034, N'Thuringia', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1035, N'Berlin', N'Europe/Berlin', 39)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1036, N'Mount Athos', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1037, N'East Macedonia and Thrace', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1038, N'Central Macedonia', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1039, N'West Macedonia', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1040, N'Thessaly', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1041, N'Epirus', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1042, N'Ionian Islands', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1043, N'West Greece', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1044, N'Central Greece', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1045, N'Peloponnese', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1046, N'Attica', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1047, N'North Aegean', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1048, N'South Aegean', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1049, N'Crete', N'Europe/Athens', 40)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1050, N'Alta Verapaz', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1051, N'Baja Verapaz', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1052, N'Chimaltenango', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1053, N'Chiquimula', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1054, N'El Progreso', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1055, N'Escuintla', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1056, N'Guatemala', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1057, N'Huehuetenango', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1058, N'Izabal', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1059, N'Jalapa', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1060, N'Jutiapa', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1061, N'Petén', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1062, N'Quetzaltenango', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1063, N'Quiché', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1064, N'Retalhuleu', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1065, N'Sacatepéquez', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1066, N'San Marcos', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1067, N'Santa Rosa', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1068, N'Sololá', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1069, N'Suchitepéquez', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1070, N'Totonicapán', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1071, N'Zacapa', N'America/Guatemala', 42)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1072, N'Atlántida', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1073, N'Choluteca', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1074, N'Colón', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1075, N'Comayagua', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1076, N'Copán', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1077, N'Cortés', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1078, N'El Paraíso', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1079, N'Francisco Morazán', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1080, N'Gracias a Dios', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1081, N'Intibucá', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1082, N'Islas de la Bahía', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1083, N'La Paz', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1084, N'Lempira', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1085, N'Ocotepeque', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1086, N'Olancho', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1087, N'Santa Bárbara', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1088, N'Valle', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1089, N'Yoro', N'America/Tegucigalpa', 43)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1090, N'Hong Kong', N'Asia/Hong_Kong', 44)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1091, N'Bács-Kiskun', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1092, N'Baranya', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1093, N'Békés', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1094, N'Borsod-Abaúj-Zemplén', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1095, N'Budapest', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1096, N'Csongrád', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1097, N'Fejér', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1098, N'Győr-Moson-Sopron', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1099, N'Hajdú-Bihar', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1100, N'Heves', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1101, N'Komárom-Esztergom', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1102, N'Nógrád', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1103, N'Pest', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1104, N'Somogy', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1105, N'Szabolcs-Szatmár-Bereg', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1106, N'Jász-Nagykun-Szolnok', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1107, N'Tolna', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1108, N'Vas', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1109, N'Veszprém', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1110, N'Zala', N'Europe/Budapest', 45)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1111, N'Andaman and Nicobar Islands', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1112, N'Andhra Pradesh', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1113, N'Assam', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1114, N'Bihar', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1115, N'Chandīgarh', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1116, N'Dādra and Nagar Haveli', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1117, N'NCT', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1118, N'Gujarāt', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1119, N'Haryana', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1120, N'Himāchal Pradesh', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1121, N'Kashmir', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1122, N'Kerala', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1123, N'Laccadives', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1124, N'Madhya Pradesh', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1125, N'Mahārāshtra', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1126, N'Manipur', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1127, N'Meghālaya', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1128, N'Karnātaka', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1129, N'Nāgāland', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1130, N'Orissa', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1131, N'Pondicherry', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1132, N'Punjab', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1133, N'State of Rājasthān', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1134, N'Tamil Nādu', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1135, N'Tripura', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1136, N'Uttar Pradesh', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1137, N'Bengal', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1138, N'Sikkim', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1139, N'Arunāchal Pradesh', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1140, N'Mizoram', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1141, N'Daman and Diu', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1142, N'Goa', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1143, N'Bihār', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1144, N'Chhattisgarh', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1145, N'Jharkhand', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1146, N'Uttarakhand', N'Asia/Kolkata', 47)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1147, N'Aceh', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1148, N'Bali', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1149, N'Bengkulu', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1150, N'Jakarta Raya', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1151, N'Jambi', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1152, N'Jawa Barat', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1153, N'Central Java', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1154, N'East Java', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1155, N'Yogyakarta', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1156, N'West Kalimantan', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1157, N'South Kalimantan', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1158, N'Kalimantan Tengah', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1159, N'East Kalimantan', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1160, N'Lampung', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1161, N'Nusa Tenggara Barat', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1162, N'East Nusa Tenggara', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1163, N'Central Sulawesi', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1164, N'Sulawesi Tenggara', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1165, N'Sulawesi Utara', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1166, N'West Sumatra', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1167, N'Sumatera Selatan', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1168, N'North Sumatra', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1169, N'Timor Timur', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1170, N'Maluku', N'Asia/Jayapura', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1171, N'Maluku Utara', N'Asia/Jayapura', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1172, N'West Java', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1173, N'North Sulawesi', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1174, N'South Sumatra', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1175, N'Banten', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1176, N'Gorontalo', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1177, N'Bangka-Belitung', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1178, N'Papua', N'Asia/Jayapura', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1179, N'Riau', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1180, N'South Sulawesi', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1181, N'Irian Jaya Barat', N'Asia/Jayapura', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1182, N'Riau Islands', N'Asia/Jakarta', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1183, N'Sulawesi Barat', N'Asia/Ujung_Pandang', 48)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1184, N'Āz̄ārbāyjān-e Gharbī', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1185, N'Chahār Maḩāll va Bakhtīārī', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1186, N'Sīstān va Balūchestān', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1187, N'Kohgīlūyeh va Būyer Aḩmad', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1188, N'Fārs Province', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1189, N'Gīlān', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1190, N'Hamadān', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1191, N'Īlām', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1192, N'Hormozgān Province', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1193, N'Kerman', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1194, N'Kermānshāh', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1195, N'Khūzestān', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1196, N'Kordestān', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1197, N'Mazandaran', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1198, N'Markazi', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1199, N'Zanjan', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1200, N'Bushehr Province', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1201, N'Lorestān', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1202, N'Semnān Province', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1203, N'Tehrān', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1204, N'Eşfahān', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1205, N'Kermān', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1206, N'Ostan-e Khorasan-e Razavi', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1207, N'Yazd', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1208, N'Ardabīl', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1209, N'Āz̄ārbāyjān-e Sharqī', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1210, N'Markazi Province', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1211, N'Māzandarān Province', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1212, N'Zanjan Province', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1213, N'Golestān', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1214, N'Qazvīn', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1215, N'Qom', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1216, N'Khorāsān-e Jonūbī', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1217, N'Razavi Khorasan Province', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1218, N'Khorāsān-e Shomālī', N'Asia/Tehran', 49)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1219, N'Anbar', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1220, N'Al Başrah', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1221, N'Al Muthanná', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1222, N'Al Qādisīyah', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1223, N'As Sulaymānīyah', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1224, N'Bābil', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1225, N'Baghdād', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1226, N'Dahūk', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1227, N'Dhi Qar', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1228, N'Diyala', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1229, N'Arbīl', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1230, N'Karbalāʼ', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1231, N'At Taʼmīm', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1232, N'Maysan', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1233, N'Nīnawá', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1234, N'Wāsiţ', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1235, N'An Najaf', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1236, N'Şalāḩ ad Dīn', N'Asia/Baghdad', 50)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1237, N'Carlow', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1238, N'Cavan', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1239, N'County Clare', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1240, N'Cork', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1241, N'Donegal', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1242, N'Galway', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1243, N'County Kerry', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1244, N'County Kildare', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1245, N'County Kilkenny', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1246, N'Leitrim', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1247, N'Laois', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1248, N'Limerick', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1249, N'County Longford', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1250, N'County Louth', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1251, N'County Mayo', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1252, N'County Meath', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1253, N'Monaghan', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1254, N'County Offaly', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1255, N'County Roscommon', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1256, N'County Sligo', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1257, N'County Waterford', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1258, N'County Westmeath', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1259, N'County Wexford', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1260, N'County Wicklow', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1261, N'Dún Laoghaire-Rathdown', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1262, N'Fingal County', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1263, N'Tipperary North Riding', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1264, N'South Dublin', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1265, N'Tipperary South Riding', N'Europe/Dublin', 51)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1266, N'HaDarom', N'Asia/Jerusalem', 53)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1267, N'HaMerkaz', N'Asia/Jerusalem', 53)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1268, N'Northern District', N'Asia/Jerusalem', 53)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1269, N'H̱efa', N'Asia/Jerusalem', 53)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1270, N'Tel Aviv', N'Asia/Jerusalem', 53)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1271, N'Yerushalayim', N'Asia/Jerusalem', 53)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1272, N'Abruzzo', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1273, N'Basilicate', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1274, N'Calabria', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1275, N'Campania', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1276, N'Emilia-Romagna', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1277, N'Friuli', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1278, N'Lazio', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1279, N'Liguria', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1280, N'Lombardy', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1281, N'The Marches', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1282, N'Molise', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1283, N'Piedmont', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1284, N'Apulia', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1285, N'Sardinia', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1286, N'Sicily', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1287, N'Tuscany', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1288, N'Trentino-Alto Adige', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1289, N'Umbria', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1290, N'Aosta Valley', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1291, N'Veneto', N'Europe/Rome', 54)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1292, N'Clarendon', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1293, N'Hanover Parish', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1294, N'Manchester', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1295, N'Portland', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1296, N'Saint Andrew', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1297, N'Saint Ann', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1298, N'Saint Catherine', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1299, N'St. Elizabeth', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1300, N'Saint James', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1301, N'Saint Mary', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1302, N'Saint Thomas', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1303, N'Trelawny', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1304, N'Westmoreland', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1305, N'Kingston', N'America/Jamaica', 55)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1306, N'Aichi', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1307, N'Akita', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1308, N'Aomori', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1309, N'Chiba', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1310, N'Ehime', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1311, N'Fukui', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1312, N'Fukuoka', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1313, N'Fukushima', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1314, N'Gifu', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1315, N'Gumma', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1316, N'Hiroshima', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1317, N'Hokkaidō', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1318, N'Hyōgo', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1319, N'Ibaraki', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1320, N'Ishikawa', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1321, N'Iwate', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1322, N'Kagawa', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1323, N'Kagoshima', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1324, N'Kanagawa', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1325, N'Kōchi', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1326, N'Kumamoto', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1327, N'Kyōto', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1328, N'Mie', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1329, N'Miyagi', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1330, N'Miyazaki', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1331, N'Nagano', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1332, N'Nagasaki', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1333, N'Nara', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1334, N'Niigata', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1335, N'Ōita', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1336, N'Okayama', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1337, N'Ōsaka', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1338, N'Saga', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1339, N'Saitama', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1340, N'Shiga', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1341, N'Shimane', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1342, N'Shizuoka', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1343, N'Tochigi', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1344, N'Tokushima', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1345, N'Tōkyō', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1346, N'Tottori', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1347, N'Toyama', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1348, N'Wakayama', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1349, N'Yamagata', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1350, N'Yamaguchi', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1351, N'Yamanashi', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1352, N'Okinawa', N'Asia/Tokyo', 56)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1353, N'Balqa', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1354, N'Ma’an', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1355, N'Karak', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1356, N'Al Mafraq', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1357, N'Tafielah', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1358, N'Az Zarqa', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1359, N'Irbid', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1360, N'Mafraq', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1361, N'Amman', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1362, N'Zarqa', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1363, N'Ajlun', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1364, N'Aqaba', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1365, N'Jerash', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1366, N'Madaba', N'Asia/Amman', 57)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1367, N'Central', N'Africa/Nairobi', 59)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1368, N'Coast', N'Africa/Nairobi', 59)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1369, N'Eastern', N'Africa/Nairobi', 59)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1370, N'Nairobi Area', N'Africa/Nairobi', 59)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1371, N'North-Eastern', N'Africa/Nairobi', 59)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1372, N'Nyanza', N'Africa/Nairobi', 59)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1373, N'Rift Valley', N'Africa/Nairobi', 59)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1374, N'Western', N'Africa/Nairobi', 59)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1375, N'Jeju', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1376, N'North Jeolla', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1377, N'North Chungcheong', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1378, N'Gangwon', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1379, N'Busan', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1380, N'Seoul', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1381, N'Incheon', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1382, N'Gyeonggi', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1383, N'North Gyeongsang', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1384, N'Daegu', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1385, N'South Jeolla', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1386, N'South Chungcheong', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1387, N'Gwangju', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1388, N'Daejeon', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1389, N'South Gyeongsang', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1390, N'Ulsan', N'Asia/Seoul', 60)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1391, N'Muḩāfaz̧atalWafrah', N'Asia/Kuwait', 61)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1392, N'Al ‘Āşimah', N'Asia/Kuwait', 61)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1393, N'Al Aḩmadī', N'Asia/Kuwait', 61)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1394, N'Al Jahrāʼ', N'Asia/Kuwait', 61)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1395, N'Al Farwaniyah', N'Asia/Kuwait', 61)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1396, N'Ḩawallī', N'Asia/Kuwait', 61)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1397, N'Attapu', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1398, N'Champasak', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1399, N'Houaphan', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1400, N'Khammouan', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1401, N'Louang Namtha', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1402, N'Louangphrabang', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1403, N'Oudômxai', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1404, N'Phongsali', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1405, N'Saravan', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1406, N'Savannakhet', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1407, N'Vientiane', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1408, N'Xiagnabouli', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1409, N'Xiangkhoang', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1410, N'Loungnamtha', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1411, N'Louangphabang', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1412, N'Phôngsali', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1413, N'Salavan', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1414, N'Savannahkhét', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1415, N'Bokèo', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1416, N'Bolikhamxai', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1417, N'Viangchan', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1418, N'Xékong', N'Asia/Vientiane', 63)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1419, N'Béqaa', N'Asia/Beirut', 65)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1420, N'Liban-Nord', N'Asia/Beirut', 65)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1421, N'Beyrouth', N'Asia/Beirut', 65)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1422, N'Mont-Liban', N'Asia/Beirut', 65)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1423, N'Liban-Sud', N'Asia/Beirut', 65)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1424, N'Nabatîyé', N'Asia/Beirut', 65)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1425, N'Aakkâr', N'Asia/Beirut', 65)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1426, N'Baalbek-Hermel', N'Asia/Beirut', 65)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1427, N'Dobeles Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1428, N'Aizkraukles Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1429, N'Alūksnes Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1430, N'Balvu Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1431, N'Bauskas Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1432, N'Cēsu Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1433, N'Daugavpils', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1434, N'Daugavpils Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1435, N'Gulbenes Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1436, N'Jēkabpils Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1437, N'Jelgava', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1438, N'Jelgavas Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1439, N'Jūrmala', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1440, N'Krāslavas Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1441, N'Kuldīgas Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1442, N'Liepāja', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1443, N'Liepājas Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1444, N'Limbažu Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1445, N'Ludzas Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1446, N'Madonas Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1447, N'Ogres Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1448, N'Preiļu Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1449, N'Rēzekne', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1450, N'Rēzeknes Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1451, N'Rīga', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1452, N'Rīgas Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1453, N'Saldus Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1454, N'Talsu Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1455, N'Tukuma Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1456, N'Valkas Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1457, N'Valmieras Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1458, N'Ventspils', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1459, N'Ventspils Rajons', N'Europe/Riga', 64)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1460, N'Al Abyār', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1461, N'Al ‘Azīzīyah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1462, N'Al Bayḑā’', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1463, N'Al Jufrah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1464, N'Al Jumayl', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1465, N'Al Kufrah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1466, N'Al Marj', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1467, N'Al Qarābūll', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1468, N'Al Qubbah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1469, N'Al Ajaylāt', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1470, N'Ash Shāţiʼ', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1471, N'Az Zahra’', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1472, N'Banī Walīd', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1473, N'Bin Jawwād', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1474, N'Ghāt', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1475, N'Jādū', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1476, N'Jālū', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1477, N'Janzūr', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1478, N'Masallatah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1479, N'Mizdah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1480, N'Murzuq', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1481, N'Nālūt', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1482, N'Qamīnis', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1483, N'Qaşr Bin Ghashīr', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1484, N'Sabhā', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1485, N'Şabrātah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1486, N'Shaḩḩāt', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1487, N'Şurmān', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1488, N'Tajura’', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1489, N'Tarhūnah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1490, N'Ţubruq', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1491, N'Tūkrah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1492, N'Zlīţan', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1493, N'Zuwārah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1494, N'Ajdābiyā', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1495, N'Al Fātiḩ', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1496, N'Al Jabal al Akhḑar', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1497, N'Al Khums', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1498, N'An Nuqāţ al Khams', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1499, N'Awbārī', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1500, N'Az Zāwiyah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1501, N'Banghāzī', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1502, N'Darnah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1503, N'Ghadāmis', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1504, N'Gharyān', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1505, N'Mişrātah', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1506, N'Sawfajjīn', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1507, N'Surt', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1508, N'Ţarābulus', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1509, N'Yafran', N'Africa/Tripoli', 66)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1510, N'Johor', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1511, N'Kedah', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1512, N'Kelantan', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1513, N'Melaka', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1514, N'Negeri Sembilan', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1515, N'Pahang', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1516, N'Perak', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1517, N'Perlis', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1518, N'Pulau Pinang', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1519, N'Sarawak', N'Asia/Kuching', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1520, N'Selangor', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1521, N'Terengganu', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1522, N'Kuala Lumpur', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1523, N'Federal Territory of Labuan', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1524, N'Sabah', N'Asia/Kuching', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1525, N'Putrajaya', N'Asia/Kuala_Lumpur', 72)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1526, N'Malta', N'Europe/Malta', 74)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1527, N'Aguascalientes', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1528, N'Baja California', N'America/Tijuana', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1529, N'Baja California Sur', N'America/Mazatlan', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1530, N'Campeche', N'America/Merida', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1531, N'Chiapas', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1532, N'Chihuahua', N'America/Chihuahua', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1533, N'Coahuila', N'America/Monterrey', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1534, N'Colima', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1535, N'The Federal District', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1536, N'Durango', N'America/Monterrey', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1537, N'Guanajuato', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1538, N'Guerrero', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1539, N'Hidalgo', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1540, N'Jalisco', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1541, N'México', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1542, N'Michoacán', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1543, N'Morelos', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1544, N'Nayarit', N'America/Mazatlan', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1545, N'Nuevo León', N'America/Monterrey', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1546, N'Oaxaca', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1547, N'Puebla', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1548, N'Querétaro', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1549, N'Quintana Roo', N'America/Cancun', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1550, N'San Luis Potosí', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1551, N'Sinaloa', N'America/Mazatlan', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1552, N'Sonora', N'America/Hermosillo', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1553, N'Tabasco', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1554, N'Tamaulipas', N'America/Monterrey', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1555, N'Tlaxcala', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1556, N'Veracruz-Llave', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1557, N'Yucatán', N'America/Merida', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1558, N'Zacatecas', N'America/Mexico_City', 75)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1559, N'Agadir', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1560, N'Al Hoceïma', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1561, N'Azizal', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1562, N'Ben Slimane', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1563, N'Beni Mellal', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1564, N'Boulemane', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1565, N'Casablanca', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1566, N'Chaouen', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1567, N'El Jadida', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1568, N'El Kelaa des Srarhna', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1569, N'Er Rachidia', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1570, N'Essaouira', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1571, N'Fes', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1572, N'Figuig', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1573, N'Kenitra', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1574, N'Khemisset', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1575, N'Khenifra', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1576, N'Khouribga', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1577, N'Marrakech', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1578, N'Meknes', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1579, N'Nador', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1580, N'Ouarzazate', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1581, N'Oujda', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1582, N'Rabat-Sale', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1583, N'Safi', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1584, N'Settat', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1585, N'Tanger', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1586, N'Tata', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1587, N'Taza', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1588, N'Tiznit', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1589, N'Guelmim', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1590, N'Ifrane', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1591, N'Laayoune', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1592, N'Tan-Tan', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1593, N'Taounate', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1594, N'Sidi Kacem', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1595, N'Taroudannt', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1596, N'Tetouan', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1597, N'Larache', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1598, N'Grand Casablanca', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1599, N'Fès-Boulemane', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1600, N'Marrakech-Tensift-Al Haouz', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1601, N'Meknès-Tafilalet', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1602, N'Rabat-Salé-Zemmour-Zaër', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1603, N'Chaouia-Ouardigha', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1604, N'Doukkala-Abda', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1605, N'Gharb-Chrarda-Beni Hssen', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1606, N'Guelmim-Es Smara', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1607, N'Oriental', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1608, N'Souss-Massa-Drâa', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1609, N'Tadla-Azilal', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1610, N'Tanger-Tétouan', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1611, N'Taza-Al Hoceima-Taounate', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1612, N'Laâyoune-Boujdour-Sakia El Hamra', N'Africa/Casablanca', 78)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1613, N'Ad Dākhilīyah', N'Asia/Muscat', 85)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1614, N'Al Bāţinah', N'Asia/Muscat', 85)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1615, N'Al Wusţá', N'Asia/Muscat', 85)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1616, N'Ash Sharqīyah', N'Asia/Muscat', 85)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1617, N'Masqaţ', N'Asia/Muscat', 85)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1618, N'Musandam', N'Asia/Muscat', 85)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1619, N'Z̧ufār', N'Asia/Muscat', 85)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1620, N'Az̧ Z̧āhirah', N'Asia/Muscat', 85)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1621, N'Muḩāfaz̧at al Buraymī', N'Asia/Muscat', 85)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1622, N'Provincie Drenthe', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1623, N'Provincie Friesland', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1624, N'Gelderland', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1625, N'Groningen', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1626, N'Limburg', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1627, N'North Brabant', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1628, N'North Holland', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1629, N'Utrecht', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1630, N'Zeeland', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1631, N'South Holland', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1632, N'Overijssel', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1633, N'Flevoland', N'Europe/Amsterdam', 80)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1634, N'Tasman', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1635, N'Auckland', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1636, N'Bay of Plenty', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1637, N'Canterbury', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1638, N'Gisborne', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1639, N'Hawkeʼs Bay', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1640, N'Manawatu-Wanganui', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1641, N'Marlborough', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1642, N'Nelson', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1643, N'Northland', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1644, N'Otago', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1645, N'Southland', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1646, N'Taranaki', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1647, N'Waikato', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1648, N'Wellington', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1649, N'West Coast', N'Pacific/Auckland', 81)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1650, N'Boaco', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1651, N'Carazo', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1652, N'Chinandega', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1653, N'Chontales', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1654, N'Estelí', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1655, N'Granada', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1656, N'Jinotega', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1657, N'León', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1658, N'Madriz', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1659, N'Managua', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1660, N'Masaya', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1661, N'Matagalpa', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1662, N'Nueva Segovia', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1663, N'Río San Juan', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1664, N'Rivas', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1665, N'Ogun State', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1666, N'Atlántico Norte', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1667, N'Atlántico Sur', N'America/Managua', 82)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1668, N'Lagos', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1669, N'Abuja Federal Capital Territory', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1670, N'Ogun', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1671, N'Akwa Ibom', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1672, N'Cross River', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1673, N'Kaduna', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1674, N'Katsina', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1675, N'Anambra', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1676, N'Benue', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1677, N'Borno', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1678, N'Imo', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1679, N'Kano', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1680, N'Kwara', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1681, N'Niger', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1682, N'Oyo', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1683, N'Adamawa', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1684, N'Delta', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1685, N'Edo', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1686, N'Jigawa', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1687, N'Kebbi', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1688, N'Kogi', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1689, N'Osun', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1690, N'Taraba', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1691, N'Yobe', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1692, N'Abia', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1693, N'Bauchi', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1694, N'Enugu', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1695, N'Ondo', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1696, N'Plateau', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1697, N'Rivers', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1698, N'Sokoto', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1699, N'Bayelsa', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1700, N'Ebonyi', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1701, N'Ekiti', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1702, N'Gombe', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1703, N'Nassarawa', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1704, N'Zamfara', N'Africa/Lagos', 83)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1705, N'Svalbard', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1706, N'Akershus', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1707, N'Aust-Agder', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1708, N'Buskerud', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1709, N'Finnmark', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1710, N'Hedmark', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1711, N'Hordaland', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1712, N'Møre og Romsdal', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1713, N'Nordland', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1714, N'Nord-Trøndelag', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1715, N'Oppland', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1716, N'Oslo county', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1717, N'Østfold', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1718, N'Rogaland', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1719, N'Sogn og Fjordane', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1720, N'Sør-Trøndelag', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1721, N'Telemark', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1722, N'Troms', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1723, N'Vest-Agder', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1724, N'Vestfold', N'Europe/Oslo', 84)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1725, N'Bocas del Toro', N'America/Panama', 86)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1726, N'Chiriquí', N'America/Panama', 86)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1727, N'Coclé', N'America/Panama', 86)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1728, N'Colón', N'America/Panama', 86)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1729, N'Darién', N'America/Panama', 86)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1730, N'Herrera', N'America/Panama', 86)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1731, N'Los Santos', N'America/Panama', 86)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1732, N'Panamá', N'America/Panama', 86)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1733, N'San Blas', N'America/Panama', 86)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1734, N'Veraguas', N'America/Panama', 86)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1735, N'Alto Paraná', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1736, N'Amambay', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1737, N'Caaguazú', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1738, N'Caazapá', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1739, N'Central', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1740, N'Concepción', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1741, N'Cordillera', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1742, N'Guairá', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1743, N'Itapúa', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1744, N'Misiones', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1745, N'Ñeembucú', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1746, N'Paraguarí', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1747, N'Presidente Hayes', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1748, N'San Pedro', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1749, N'Canindeyú', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1750, N'Asunción', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1751, N'Departamento de Alto Paraguay', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1752, N'Boquerón', N'America/Asuncion', 87)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1753, N'Amazonas', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1754, N'Ancash', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1755, N'Apurímac', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1756, N'Arequipa', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1757, N'Ayacucho', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1758, N'Cajamarca', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1759, N'Callao', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1760, N'Cusco', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1761, N'Huancavelica', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1762, N'Huanuco', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1763, N'Ica', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1764, N'Junín', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1765, N'La Libertad', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1766, N'Lambayeque', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1767, N'Lima', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1768, N'Provincia de Lima', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1769, N'Loreto', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1770, N'Madre de Dios', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1771, N'Moquegua', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1772, N'Pasco', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1773, N'Piura', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1774, N'Puno', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1775, N'San Martín', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1776, N'Tacna', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1777, N'Tumbes', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1778, N'Ucayali', N'America/Lima', 89)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1779, N'Abra', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1780, N'Agusan del Norte', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1781, N'Agusan del Sur', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1782, N'Aklan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1783, N'Albay', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1784, N'Antique', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1785, N'Bataan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1786, N'Batanes', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1787, N'Batangas', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1788, N'Benguet', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1789, N'Bohol', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1790, N'Bukidnon', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1791, N'Bulacan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1792, N'Cagayan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1793, N'Camarines Norte', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1794, N'Camarines Sur', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1795, N'Camiguin', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1796, N'Capiz', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1797, N'Catanduanes', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1798, N'Cebu', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1799, N'Basilan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1800, N'Eastern Samar', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1801, N'Davao del Sur', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1802, N'Davao Oriental', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1803, N'Ifugao', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1804, N'Ilocos Norte', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1805, N'Ilocos Sur', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1806, N'Iloilo', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1807, N'Isabela', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1808, N'Laguna', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1809, N'Lanao del Sur', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1810, N'La Union', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1811, N'Leyte', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1812, N'Marinduque', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1813, N'Masbate', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1814, N'Occidental Mindoro', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1815, N'Oriental Mindoro', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1816, N'Misamis Oriental', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1817, N'Mountain Province', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1818, N'Negros Oriental', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1819, N'Nueva Ecija', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1820, N'Nueva Vizcaya', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1821, N'Palawan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1822, N'Pampanga', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1823, N'Pangasinan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1824, N'Rizal', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1825, N'Romblon', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1826, N'Samar', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1827, N'Maguindanao', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1828, N'Cotabato City', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1829, N'Sorsogon', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1830, N'Southern Leyte', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1831, N'Sulu', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1832, N'Surigao del Norte', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1833, N'Surigao del Sur', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1834, N'Tarlac', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1835, N'Zambales', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1836, N'Zamboanga del Norte', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1837, N'Zamboanga del Sur', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1838, N'Northern Samar', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1839, N'Quirino', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1840, N'Siquijor', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1841, N'South Cotabato', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1842, N'Sultan Kudarat', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1843, N'Kalinga', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1844, N'Apayao', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1845, N'Tawi-Tawi', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1846, N'Angeles', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1847, N'Bacolod City', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1848, N'Compostela Valley', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1849, N'Baguio', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1850, N'Davao del Norte', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1851, N'Butuan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1852, N'Guimaras', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1853, N'Lanao del Norte', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1854, N'Misamis Occidental', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1855, N'Caloocan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1856, N'Cavite', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1857, N'Cebu City', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1858, N'Cotabato', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1859, N'Dagupan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1860, N'Cagayan de Oro', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1861, N'Iligan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1862, N'Davao', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1863, N'Las Piñas', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1864, N'Malabon', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1865, N'General Santos', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1866, N'Muntinlupa', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1867, N'Iloilo City', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1868, N'Navotas', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1869, N'Parañaque', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1870, N'Quezon City', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1871, N'Lapu-Lapu', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1872, N'Taguig', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1873, N'Valenzuela', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1874, N'Lucena', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1875, N'Mandaue', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1876, N'Manila', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1877, N'Zamboanga Sibugay', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1878, N'Naga', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1879, N'Olongapo', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1880, N'Ormoc', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1881, N'Santiago', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1882, N'Pateros', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1883, N'Pasay', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1884, N'Puerto Princesa', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1885, N'Quezon', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1886, N'Tacloban', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1887, N'Zamboanga City', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1888, N'Aurora', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1889, N'Negros Occidental', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1890, N'Biliran', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1891, N'Makati City', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1892, N'Sarangani', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1893, N'Mandaluyong City', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1894, N'Marikina', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1895, N'Pasig', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1896, N'San Juan', N'Asia/Manila', 90)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1897, N'Biala Podlaska', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1898, N'Bialystok', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1899, N'Bielsko', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1900, N'Bydgoszcz', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1901, N'Chelm', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1902, N'Ciechanow', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1903, N'Czestochowa', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1904, N'Elblag', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1905, N'Gdansk', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1906, N'Gorzow', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1907, N'Jelenia Gora', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1908, N'Kalisz', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1909, N'Katowice', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1910, N'Kielce', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1911, N'Konin', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1912, N'Koszalin', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1913, N'Krakow', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1914, N'Krosno', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1915, N'Legnica', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1916, N'Leszno', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1917, N'Lodz', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1918, N'Lomza', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1919, N'Lublin', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1920, N'Nowy Sacz', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1921, N'Olsztyn', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1922, N'Opole', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1923, N'Ostroleka', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1924, N'Pita', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1925, N'Piotrkow', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1926, N'Plock', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1927, N'Poznan', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1928, N'Przemysl', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1929, N'Radom', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1930, N'Rzeszow', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1931, N'Siedlce', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1932, N'Sieradz', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1933, N'Skierniewice', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1934, N'Slupsk', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1935, N'Suwalki', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1936, N'Szczecin', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1937, N'Tarnobrzeg', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1938, N'Tarnow', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1939, N'Torufi', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1940, N'Walbrzych', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1941, N'Warszawa', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1942, N'Wloclawek', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1943, N'Wroclaw', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1944, N'Zamosc', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1945, N'Zielona Gora', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1946, N'Lower Silesian Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1947, N'Kujawsko-Pomorskie Voivodship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1948, N'Łódź Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1949, N'Lublin Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1950, N'Lubusz Voivodship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1951, N'Lesser Poland Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1952, N'Masovian Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1953, N'Opole Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1954, N'Subcarpathian Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1955, N'Podlasie Voivodship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1956, N'Pomeranian Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1957, N'Silesian Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1958, N'Świętokrzyskie Voivodship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1959, N'Warmian-Masurian Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1960, N'Greater Poland Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1961, N'West Pomeranian Voivodeship', N'Europe/Warsaw', 91)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1962, N'Aveiro', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1963, N'Beja', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1964, N'Braga', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1965, N'Bragança', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1966, N'Castelo Branco', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1967, N'Coimbra', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1968, N'Évora', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1969, N'Faro', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1970, N'Madeira', N'Atlantic/Madeira', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1971, N'Guarda', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1972, N'Leiria', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1973, N'Lisbon', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1974, N'Portalegre', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1975, N'Porto', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1976, N'Santarém', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1977, N'Setúbal', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1978, N'Viana do Castelo', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1979, N'Vila Real', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1980, N'Viseu', N'Europe/Lisbon', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1981, N'Azores', N'Atlantic/Azores', 92)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1982, N'Puerto Rico', N'America/Puerto_Rico', 94)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1983, N'Ad Dawḩah', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1984, N'Al Ghuwayrīyah', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1985, N'Al Jumaylīyah', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1986, N'Al Khawr', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1987, N'Al Wakrah Municipality', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1988, N'Ar Rayyān', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1989, N'Jarayan al Batinah', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1990, N'Madīnat ash Shamāl', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1991, N'Umm Şalāl', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1992, N'Al Wakrah', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1993, N'Jarayān al Bāţinah', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1994, N'Umm Sa‘īd', N'Asia/Qatar', 95)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1995, N'Alba', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1996, N'Arad', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1997, N'Argeş', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1998, N'Bacău', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (1999, N'Bihor', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2000, N'Bistriţa-Năsăud', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2001, N'Botoşani', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2002, N'Brăila', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2003, N'Braşov', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2004, N'Bucureşti', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2005, N'Buzău', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2006, N'Caraş-Severin', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2007, N'Cluj', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2008, N'Constanţa', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2009, N'Covasna', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2010, N'Dâmboviţa', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2011, N'Dolj', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2012, N'Galaţi', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2013, N'Gorj', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2014, N'Harghita', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2015, N'Hunedoara', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2016, N'Ialomiţa', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2017, N'Iaşi', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2018, N'Maramureş', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2019, N'Mehedinţi', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2020, N'Mureş', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2021, N'Neamţ', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2022, N'Olt', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2023, N'Prahova', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2024, N'Sălaj', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2025, N'Satu Mare', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2026, N'Sibiu', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2027, N'Suceava', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2028, N'Teleorman', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2029, N'Timiş', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2030, N'Tulcea', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2031, N'Vaslui', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2032, N'Vâlcea', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2033, N'Judeţul Vrancea', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2034, N'Călăraşi', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2035, N'Giurgiu', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2036, N'Ilfov', N'Europe/Bucharest', 97)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2037, N'Eastern Province', N'Africa/Kigali', 99)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2038, N'Kigali City', N'Africa/Kigali', 99)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2039, N'Northern Province', N'Africa/Kigali', 99)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2040, N'Western Province', N'Africa/Kigali', 99)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2041, N'Southern Province', N'Africa/Kigali', 99)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2042, N'Al Bāḩah', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2043, N'Al Madīnah', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2044, N'Ash Sharqīyah', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2045, N'Al Qaşīm', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2046, N'Ar Riyāḑ', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2047, N'‘Asīr', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2048, N'Ḩāʼil', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2049, N'Makkah', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2050, N'Northern Borders Region', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2051, N'Najrān', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2052, N'Jīzān', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2053, N'Tabūk', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2054, N'Al Jawf', N'Asia/Riyadh', 100)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2055, N'Singapore', N'Asia/Singapore', 104)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2056, N'Banskobystrický', N'Europe/Bratislava', 105)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2057, N'Bratislavský', N'Europe/Bratislava', 105)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2058, N'Košický', N'Europe/Bratislava', 105)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2059, N'Nitriansky', N'Europe/Bratislava', 105)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2060, N'Prešovský', N'Europe/Bratislava', 105)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2061, N'Trenčiansky', N'Europe/Bratislava', 105)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2062, N'Trnavský', N'Europe/Bratislava', 105)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2063, N'Žilinský', N'Europe/Bratislava', 105)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2064, N'An Giang', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2065, N'Bac Thai Tinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2066, N'Ben Tre', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2067, N'Cao Bang', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2068, N'Ten Bai', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2069, N'Ðong Thap', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2070, N'Ha Bac Tinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2071, N'Hai Hung Tinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2072, N'Hai Phong', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2073, N'Hoa Binh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2074, N'Ha Tay', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2075, N'Ho Chi Minh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2076, N'Kien Giang', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2077, N'Lam Ðong', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2078, N'Long An', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2079, N'Minh Hai Tinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2080, N'Thua Thien-Hue', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2081, N'Quang Nam', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2082, N'Kon Tum', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2083, N'Quang Nam-Ða Nang Tinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2084, N'Quang Ninh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2085, N'Song Be Tinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2086, N'Son La', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2087, N'Tay Ninh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2088, N'Thanh Hoa', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2089, N'Thai Binh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2090, N'Nin Thuan', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2091, N'Tien Giang', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2092, N'Vinh Phu Tinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2093, N'Lang Son', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2094, N'Binh Thuan', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2095, N'Ðong Nai', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2096, N'Ha Noi', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2097, N'Ba Ria-Vung Tau', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2098, N'Binh Ðinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2099, N'Gia Lai', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2100, N'Ha Giang', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2101, N'Ha Tinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2102, N'Khanh Hoa', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2103, N'Nam Ha Tinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2104, N'Nghe An', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2105, N'Ninh Binh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2106, N'Ninh Thuan', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2107, N'Phu Yen', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2108, N'Quang Binh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2109, N'Quang Ngai', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2110, N'Quang Tri', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2111, N'Soc Trang', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2112, N'Tra Vinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2113, N'Tuyen Quang', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2114, N'Vinh Long', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2115, N'Yen Bai', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2116, N'Bac Giang', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2117, N'Bac Kan', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2118, N'Bac Lieu', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2119, N'Bac Ninh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2120, N'Binh Duong', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2121, N'Binh Phuoc', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2122, N'Ca Mau', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2123, N'Ða Nang', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2124, N'Hai Duong', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2125, N'Ha Nam', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2126, N'Hung Yen', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2127, N'Nam Ðinh', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2128, N'Phu Tho', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2129, N'Thai Nguyen', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2130, N'Vinh Phuc', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2131, N'Can Tho', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2132, N'Ðac Lak', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2133, N'Lai Chau', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2134, N'Lao Cai', N'Asia/Ho_Chi_Minh', 126)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2135, N'Notranjska', N'Europe/Ljubljana', 106)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2136, N'Koroška', N'Europe/Ljubljana', 106)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2137, N'Štajerska', N'Europe/Ljubljana', 106)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2138, N'Prekmurje', N'Europe/Ljubljana', 106)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2139, N'Primorska', N'Europe/Ljubljana', 106)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2140, N'Gorenjska', N'Europe/Ljubljana', 106)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2141, N'Dolenjska', N'Europe/Ljubljana', 106)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2142, N'KwaZulu-Natal', N'Africa/Johannesburg', 107)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2143, N'Free State', N'Africa/Johannesburg', 107)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2144, N'Eastern Cape', N'Africa/Johannesburg', 107)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2145, N'Gauteng', N'Africa/Johannesburg', 107)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2146, N'Mpumalanga', N'Africa/Johannesburg', 107)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2147, N'Northern Cape', N'Africa/Johannesburg', 107)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2148, N'Limpopo', N'Africa/Johannesburg', 107)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2149, N'North-West', N'Africa/Johannesburg', 107)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2150, N'Western Cape', N'Africa/Johannesburg', 107)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2151, N'Ceuta', N'Africa/Ceuta', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2152, N'Balearic Islands', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2153, N'La Rioja', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2154, N'Autonomous Region of Madrid', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2155, N'Murcia', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2156, N'Navarre', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2157, N'Asturias', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2158, N'Cantabria', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2159, N'Andalusia', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2160, N'Aragon', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2161, N'Canary Islands', N'Atlantic/Canary', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2162, N'Castille-La Mancha', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2163, N'Castille and León', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2164, N'Catalonia', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2165, N'Extremadura', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2166, N'Galicia', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2167, N'Basque CountryName', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2168, N'Valencia', N'Europe/Madrid', 108)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2169, N'Blekinge', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2170, N'Gävleborg', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2171, N'Gotland', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2172, N'Halland', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2173, N'Jämtland', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2174, N'Jönköping', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2175, N'Kalmar', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2176, N'Dalarna', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2177, N'Kronoberg', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2178, N'Norrbotten', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2179, N'Örebro', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2180, N'Östergötland', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2181, N'Södermanland', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2182, N'Uppsala', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2183, N'Värmland', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2184, N'Västerbotten', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2185, N'Västernorrland', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2186, N'Västmanland', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2187, N'Stockholm', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2188, N'Skåne', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2189, N'Västra Götaland', N'Europe/Stockholm', 110)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2190, N'Aargau', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2191, N'Appenzell Innerrhoden', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2192, N'Appenzell Ausserrhoden', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2193, N'Bern', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2194, N'Basel-Landschaft', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2195, N'Kanton Basel-Stadt', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2196, N'Fribourg', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2197, N'Genève', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2198, N'Glarus', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2199, N'Graubünden', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2200, N'Jura', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2201, N'Luzern', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2202, N'Neuchâtel', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2203, N'Nidwalden', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2204, N'Obwalden', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2205, N'Kanton St. Gallen', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2206, N'Schaffhausen', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2207, N'Solothurn', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2208, N'Schwyz', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2209, N'Thurgau', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2210, N'Ticino', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2211, N'Uri', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2212, N'Vaud', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2213, N'Valais', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2214, N'Zug', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2215, N'Zürich', N'Europe/Zurich', 111)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2216, N'Al-Hasakah', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2217, N'Latakia', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2218, N'Quneitra', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2219, N'Ar-Raqqah', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2220, N'As-Suwayda', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2221, N'Daraa', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2222, N'Deir ez-Zor', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2223, N'Rif-dimashq', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2224, N'Aleppo', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2225, N'Hama Governorate', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2226, N'Homs', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2227, N'Idlib', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2228, N'Damascus City', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2229, N'Tartus', N'Asia/Damascus', 112)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2230, N'Gorno-Badakhshan', N'Asia/Dushanbe', 114)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2231, N'Khatlon', N'Asia/Dushanbe', 114)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2232, N'Sughd', N'Asia/Dushanbe', 114)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2233, N'Dushanbe', N'Asia/Dushanbe', 114)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2234, N'Region of Republican Subordination', N'Asia/Dushanbe', 114)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2235, N'Mae Hong Son', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2236, N'Chiang Mai', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2237, N'Chiang Rai', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2238, N'Nan', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2239, N'Lamphun', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2240, N'Lampang', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2241, N'Phrae', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2242, N'Tak', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2243, N'Sukhothai', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2244, N'Uttaradit', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2245, N'Kamphaeng Phet', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2246, N'Phitsanulok', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2247, N'Phichit', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2248, N'Phetchabun', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2249, N'Uthai Thani', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2250, N'Nakhon Sawan', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2251, N'Nong Khai', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2252, N'Loei', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2253, N'Sakon Nakhon', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2254, N'Nakhon Phanom', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2255, N'Khon Kaen', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2256, N'Kalasin', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2257, N'Maha Sarakham', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2258, N'Roi Et', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2259, N'Chaiyaphum', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2260, N'Nakhon Ratchasima', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2261, N'Buriram', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2262, N'Surin', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2263, N'Sisaket', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2264, N'Narathiwat', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2265, N'Chai Nat', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2266, N'Sing Buri', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2267, N'Lop Buri', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2268, N'Ang Thong', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2269, N'Phra Nakhon Si Ayutthaya', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2270, N'Sara Buri', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2271, N'Nonthaburi', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2272, N'Pathum Thani', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2273, N'Bangkok', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2274, N'Phayao', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2275, N'Samut Prakan', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2276, N'Nakhon Nayok', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2277, N'Chachoengsao', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2278, N'Chon Buri', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2279, N'Rayong', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2280, N'Chanthaburi', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2281, N'Trat', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2282, N'Kanchanaburi', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2283, N'Suphan Buri', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2284, N'Ratchaburi', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2285, N'Nakhon Pathom', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2286, N'Samut Songkhram', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2287, N'Samut Sakhon', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2288, N'Phetchaburi', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2289, N'Prachuap Khiri Khan', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2290, N'Chumphon', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2291, N'Ranong', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2292, N'Surat Thani', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2293, N'Phangnga', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2294, N'Phuket', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2295, N'Krabi', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2296, N'Nakhon Si Thammarat', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2297, N'Trang', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2298, N'Phatthalung', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2299, N'Satun', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2300, N'Songkhla', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2301, N'Pattani', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2302, N'Yala', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2303, N'Yasothon', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2304, N'Prachin Buri', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2305, N'Ubon Ratchathani', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2306, N'Udon Thani', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2307, N'Amnat Charoen', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2308, N'Mukdahan', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2309, N'Nong Bua Lamphu', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2310, N'Sa Kaeo', N'Asia/Bangkok', 115)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2311, N'Port of Spain', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2312, N'San Fernando', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2313, N'Chaguanas', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2314, N'Arima', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2315, N'Point Fortin Borough', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2316, N'Couva-Tabaquite-Talparo', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2317, N'Diego Martin', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2318, N'Penal-Debe', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2319, N'Princes Town', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2320, N'Rio Claro-Mayaro', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2321, N'San Juan-Laventille', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2322, N'Sangre Grande', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2323, N'Siparia', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2324, N'Tunapuna-Piarco', N'America/Port_of_Spain', 116)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2325, N'Tunis al Janubiyah Wilayat', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2326, N'Al Qaşrayn', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2327, N'Al Qayrawān', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2328, N'Jundūbah', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2329, N'Kef', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2330, N'Al Mahdīyah', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2331, N'Al Munastīr', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2332, N'Bājah', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2333, N'Banzart', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2334, N'Nābul', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2335, N'Silyānah', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2336, N'Sūsah', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2337, N'Bin ‘Arūs', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2338, N'Madanīn', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2339, N'Qābis', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2340, N'Qafşah', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2341, N'Qibilī', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2342, N'Şafāqis', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2343, N'Sīdī Bū Zayd', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2344, N'Taţāwīn', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2345, N'Tawzar', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2346, N'Tūnis', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2347, N'Zaghwān', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2348, N'Ariana', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2349, N'Manouba', N'Africa/Tunis', 117)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2350, N'Adıyaman', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2351, N'Afyonkarahisar', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2352, N'Ağrı Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2353, N'Amasya Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2354, N'Antalya Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2355, N'Artvin Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2356, N'Aydın Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2357, N'Balıkesir Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2358, N'Bilecik Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2359, N'Bingöl Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2360, N'Bitlis Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2361, N'Bolu Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2362, N'Burdur Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2363, N'Bursa', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2364, N'Çanakkale Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2365, N'Çorum Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2366, N'Denizli Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2367, N'Diyarbakır', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2368, N'Edirne Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2369, N'Elazığ', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2370, N'Erzincan Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2371, N'Erzurum Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2372, N'Eskişehir Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2373, N'Giresun Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2374, N'Hatay Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2375, N'Mersin Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2376, N'Isparta Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2377, N'Istanbul', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2378, N'İzmir', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2379, N'Kastamonu Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2380, N'Kayseri Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2381, N'Kırklareli Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2382, N'Kırşehir Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2383, N'Kocaeli Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2384, N'Kütahya Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2385, N'Malatya Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2386, N'Manisa Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2387, N'Kahramanmaraş Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2388, N'Muğla Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2389, N'Muş Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2390, N'Nevşehir', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2391, N'Ordu', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2392, N'Rize', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2393, N'Sakarya Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2394, N'Samsun Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2395, N'Sinop Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2396, N'Sivas Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2397, N'Tekirdağ Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2398, N'Tokat', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2399, N'Trabzon Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2400, N'Tunceli Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2401, N'Şanlıurfa Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2402, N'Uşak Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2403, N'Van Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2404, N'Yozgat Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2405, N'Ankara Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2406, N'Gümüşhane', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2407, N'Hakkâri Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2408, N'Konya Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2409, N'Mardin Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2410, N'Niğde', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2411, N'Siirt Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2412, N'Aksaray Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2413, N'Batman Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2414, N'Bayburt', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2415, N'Karaman Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2416, N'Kırıkkale Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2417, N'Şırnak Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2418, N'Adana Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2419, N'Çankırı Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2420, N'Gaziantep Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2421, N'Kars', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2422, N'Zonguldak', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2423, N'Ardahan Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2424, N'Bartın Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2425, N'Iğdır Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2426, N'Karabük', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2427, N'Kilis Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2428, N'Osmaniye Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2429, N'Yalova Province', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2430, N'Düzce', N'Europe/Istanbul', 118)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2431, N'Ahal', N'Asia/Ashgabat', 119)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2432, N'Balkan', N'Asia/Ashgabat', 119)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2433, N'Daşoguz', N'Asia/Ashgabat', 119)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2434, N'Lebap', N'Asia/Ashgabat', 119)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2435, N'Mary', N'Asia/Ashgabat', 119)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2436, N'Cherkasʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2437, N'Chernihivsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2438, N'Chernivetsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2439, N'Dnipropetrovsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2440, N'Donetsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2441, N'Ivano-Frankivsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2442, N'Kharkivsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2443, N'Kherson Oblast', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2444, N'Khmelʼnytsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2445, N'Kirovohradsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2446, N'Avtonomna Respublika Krym', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2447, N'Misto Kyyiv', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2448, N'Kiev Oblast', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2449, N'Luhansʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2450, N'Lʼvivsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2451, N'Mykolayivsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2452, N'Odessa Oblast', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2453, N'Poltava Oblast', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2454, N'Rivnensʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2455, N'Misto Sevastopol', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2456, N'Sumy Oblast', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2457, N'Ternopilʼsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2458, N'Vinnytsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2459, N'Volynsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2460, N'Zakarpatsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2461, N'Zaporizʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2462, N'Zhytomyrsʼka Oblastʼ', N'Europe/Kiev', 121)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2463, N'Ad Daqahlīyah', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2464, N'Al Baḩr al Aḩmar', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2465, N'Al Buḩayrah', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2466, N'Al Fayyūm', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2467, N'Al Gharbīyah', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2468, N'Alexandria', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2469, N'Al Ismā‘īlīyah', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2470, N'Al Jīzah', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2471, N'Al Minūfīyah', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2472, N'Al Minyā', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2473, N'Al Qāhirah', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2474, N'Al Qalyūbīyah', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2475, N'Al Wādī al Jadīd', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2476, N'Eastern Province', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2477, N'As Suways', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2478, N'Aswān', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2479, N'Asyūţ', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2480, N'Banī Suwayf', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2481, N'Būr Sa‘īd', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2482, N'Dumyāţ', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2483, N'Kafr ash Shaykh', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2484, N'Maţrūḩ', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2485, N'Qinā', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2486, N'Sūhāj', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2487, N'Janūb Sīnāʼ', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2488, N'Shamāl Sīnāʼ', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2489, N'Luxor', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2490, N'Helwan', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2491, N'6th of October', N'Africa/Cairo', 31)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2492, N'England', N'Europe/London', 122)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2493, N'Northern Ireland', N'Europe/London', 122)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2494, N'Scotland', N'Europe/London', 122)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2495, N'Wales', N'Europe/London', 122)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2496, N'Alaska', N'America/Anchorage', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2497, N'Alabama', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2498, N'Arkansas', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2499, N'Arizona', N'America/Phoenix', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2500, N'California', N'America/Los_Angeles', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2501, N'Colorado', N'America/Denver', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2502, N'Connecticut', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2503, N'District of Columbia', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2504, N'Delaware', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2505, N'Florida', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2506, N'Georgia', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2507, N'Hawaii', N'Pacific/Honolulu', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2508, N'Iowa', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2509, N'Idaho', N'America/Denver', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2510, N'Illinois', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2511, N'Indiana', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2512, N'Kansas', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2513, N'Kentucky', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2514, N'Louisiana', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2515, N'Massachusetts', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2516, N'Maryland', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2517, N'Maine', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2518, N'Michigan', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2519, N'Minnesota', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2520, N'Missouri', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2521, N'Mississippi', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2522, N'Montana', N'America/Denver', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2523, N'North Carolina', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2524, N'North Dakota', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2525, N'Nebraska', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2526, N'New Hampshire', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2527, N'New Jersey', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2528, N'New Mexico', N'America/Denver', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2529, N'Nevada', N'America/Los_Angeles', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2530, N'New York', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2531, N'Ohio', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2532, N'Oklahoma', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2533, N'Oregon', N'America/Los_Angeles', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2534, N'Pennsylvania', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2535, N'Rhode Island', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2536, N'South Carolina', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2537, N'South Dakota', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2538, N'Tennessee', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2539, N'Texas', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2540, N'Utah', N'America/Denver', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2541, N'Virginia', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2542, N'Vermont', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2543, N'Washington', N'America/Los_Angeles', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2544, N'Wisconsin', N'America/Chicago', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2545, N'West Virginia', N'America/New_York', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2546, N'Wyoming', N'America/Denver', 123)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2547, N'Artigas Department', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2548, N'Canelones Department', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2549, N'Cerro Largo Department', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2550, N'Colonia Department', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2551, N'Durazno', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2552, N'Flores', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2553, N'Florida Department', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2554, N'Lavalleja Department', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2555, N'Maldonado Department', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2556, N'Montevideo', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2557, N'Paysandú', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2558, N'Río Negro', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2559, N'Rivera', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2560, N'Rocha', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2561, N'Salto', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2562, N'San José', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2563, N'Soriano Department', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2564, N'Tacuarembó', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2565, N'Treinta y Tres', N'America/Montevideo', 124)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2566, N'Andijon', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2567, N'Buxoro', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2568, N'Farg ona', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2569, N'Xorazm', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2570, N'Namangan', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2571, N'Navoiy', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2572, N'Qashqadaryo', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2573, N'Karakalpakstan', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2574, N'Samarqand', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2575, N'Surxondaryo', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2576, N'Toshkent Shahri', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2577, N'Toshkent', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2578, N'Jizzax', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2579, N'Sirdaryo', N'Asia/Samarkand', 125)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2580, N'Amazonas', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2581, N'Anzoátegui', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2582, N'Apure', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2583, N'Aragua', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2584, N'Barinas', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2585, N'Bolívar', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2586, N'Carabobo', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2587, N'Cojedes', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2588, N'Delta Amacuro', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2589, N'Distrito Federal', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2590, N'Falcón', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2591, N'Guárico', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2592, N'Lara', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2593, N'Mérida', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2594, N'Miranda', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2595, N'Monagas', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2596, N'Isla Margarita', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2597, N'Portuguesa', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2598, N'Sucre', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2599, N'Táchira', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2600, N'Trujillo', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2601, N'Yaracuy', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2602, N'Zulia', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2603, N'Dependencias Federales', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2604, N'Distrito Capital', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2605, N'Vargas', N'America/Caracas', 14)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2606, N'Abyan', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2607, N'‘Adan', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2608, N'Al Mahrah', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2609, N'Ḩaḑramawt', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2610, N'Shabwah', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2611, N'San’a’', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2612, N'Ta’izz', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2613, N'Al Ḩudaydah', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2614, N'Dhamar', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2615, N'Al Maḩwīt', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2616, N'Dhamār', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2617, N'Maʼrib', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2618, N'Şa‘dah', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2619, N'Şan‘āʼ', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2620, N'Aḑ Ḑāli‘', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2621, N'Omran', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2622, N'Al Bayḑāʼ', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2623, N'Al Jawf', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2624, N'Ḩajjah', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2625, N'Ibb', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2626, N'Laḩij', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2627, N'Ta‘izz', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2628, N'Amanat Al Asimah', N'Asia/Aden', 127)
GO
INSERT [dbo].[Province] ([Id], [Name], [TimeZone], [CountryId]) VALUES (2629, N'Muḩāfaz̧at Raymah', N'Asia/Aden', 127)
GO
SET IDENTITY_INSERT [dbo].[Province] OFF
GO
ALTER TABLE [dbo].[Province]  WITH CHECK ADD  CONSTRAINT [FK_Province_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
ON Delete CASCADE
GO
ALTER TABLE [dbo].[Province] CHECK CONSTRAINT [FK_Province_Country]
GO
