USE [GODB]
GO
/****** Object:  Table [dbo].[MBI_BrachPairing]    Script Date: 15.06.2017 10:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MBI_BrachPairing](
	[BranchPairingId] [int] IDENTITY(1,1) NOT NULL,
	[RobotposBranchNr] [nvarchar](50) NULL,
	[LogoBranchNr] [nvarchar](50) NULL,
	[BranchName] [nvarchar](150) NULL,
 CONSTRAINT [PK_dbo.MBI_BrachPairing] PRIMARY KEY CLUSTERED 
(
	[BranchPairingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MBI_DocumentType]    Script Date: 15.06.2017 10:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MBI_DocumentType](
	[DocumentTypeId] [int] IDENTITY(1,1) NOT NULL,
	[DataTypeId] [int] NOT NULL,
	[DataTypeName] [nvarchar](75) NOT NULL,
	[XmlTag] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.MBI_DocumentType] PRIMARY KEY CLUSTERED 
(
	[DocumentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MBI_Firms]    Script Date: 15.06.2017 10:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MBI_Firms](
	[FirmId] [int] IDENTITY(1,1) NOT NULL,
	[FirmNr] [smallint] NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.MBI_Firms] PRIMARY KEY CLUSTERED 
(
	[FirmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MBI_Users]    Script Date: 15.06.2017 10:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MBI_Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[RobotposSecurityKey] [nvarchar](10) NULL,
	[LogoUserName] [nvarchar](50) NULL,
	[LogoPassword] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.MBI_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[MBI_BrachPairing] ON 

INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (1, N'1', N'3404', N'YAYLADA SUREYYAPASA AVM')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (2, N'2', N'3401', N'TEPE NAUTILUS AVM')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (3, N'4', N'601', N'ANKARA OPTIMUM AVM')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (4, N'22', N'3450', N'VIALAND')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (5, N'25', N'3452', N'212 AVM')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (6, N'26', N'1601', N'BURSA KORUPARK')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (7, N'36', N'3451', N'METROCITY')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (8, N'49', N'3402', N'ACIBADEM')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (9, N'65', N'5401', N'ÇARK CADDESİ ADAPAZARI')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (10, N'74', N'1701', N'BURDA 17 ÇANAKKALE')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (11, N'76', N'2101', N'DİYARBAKIR FORUM AVM')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (12, N'95', N'3501', N'MAVİ BAHÇE AVM İZMİR')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (13, N'98', N'4401', N'MALATYA')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (14, N'107', N'7401', N'ANTALYA CADDE')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (15, N'116', N'3453', N'TORIUM AVM')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (16, N'121', N'3454', N'TRUMP TOWER')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (17, N'123', N'7402', N'TERRACITY ANTALYA')
INSERT [dbo].[MBI_BrachPairing] ([BranchPairingId], [RobotposBranchNr], [LogoBranchNr], [BranchName]) VALUES (18, N'125', N'3404', N'BAĞDAT CADDESİ')
SET IDENTITY_INSERT [dbo].[MBI_BrachPairing] OFF
SET IDENTITY_INSERT [dbo].[MBI_DocumentType] ON 

INSERT [dbo].[MBI_DocumentType] ([DocumentTypeId], [DataTypeId], [DataTypeName], [XmlTag], [IsActive]) VALUES (1, 301, N'Perakende Satış İrsaliye', N'SALES_DISPATCHES', 1)
INSERT [dbo].[MBI_DocumentType] ([DocumentTypeId], [DataTypeId], [DataTypeName], [XmlTag], [IsActive]) VALUES (2, 304, N'Perakende Satış Fatura', N'SALES_INVOICES', 1)
INSERT [dbo].[MBI_DocumentType] ([DocumentTypeId], [DataTypeId], [DataTypeName], [XmlTag], [IsActive]) VALUES (3, 106, N'Nakit Kasa Hareketleri', N'ARP_VOUCHERS', 1)
INSERT [dbo].[MBI_DocumentType] ([DocumentTypeId], [DataTypeId], [DataTypeName], [XmlTag], [IsActive]) VALUES (4, 107, N'Garanti Kasa Hareketleri', N'ARP_VOUCHERS', 1)
INSERT [dbo].[MBI_DocumentType] ([DocumentTypeId], [DataTypeId], [DataTypeName], [XmlTag], [IsActive]) VALUES (5, 109, N'Multinet Kasa Hareketleri', N'ARP_VOUCHERS', 1)
INSERT [dbo].[MBI_DocumentType] ([DocumentTypeId], [DataTypeId], [DataTypeName], [XmlTag], [IsActive]) VALUES (6, 110, N'Sodexo Kasa Hareketleri', N'ARP_VOUCHERS', 1)
INSERT [dbo].[MBI_DocumentType] ([DocumentTypeId], [DataTypeId], [DataTypeName], [XmlTag], [IsActive]) VALUES (7, 111, N'Setcard Kasa Hareketleri', N'ARP_VOUCHERS', 1)
INSERT [dbo].[MBI_DocumentType] ([DocumentTypeId], [DataTypeId], [DataTypeName], [XmlTag], [IsActive]) VALUES (8, 112, N'Ticket Kasa Hareketleri', N'ARP_VOUCHERS', 1)
INSERT [dbo].[MBI_DocumentType] ([DocumentTypeId], [DataTypeId], [DataTypeName], [XmlTag], [IsActive]) VALUES (9, 113, N'Online Kasa Hareketleri', N'ARP_VOUCHERS', 0)
INSERT [dbo].[MBI_DocumentType] ([DocumentTypeId], [DataTypeId], [DataTypeName], [XmlTag], [IsActive]) VALUES (10, 114, N'Yapı Kredi Kasa Hareketleri', N'ARP_VOUCHERS', 1)
INSERT [dbo].[MBI_DocumentType] ([DocumentTypeId], [DataTypeId], [DataTypeName], [XmlTag], [IsActive]) VALUES (11, 115, N'Metropol Kasa Hareketleri', N'ARP_VOUCHERS', 0)
SET IDENTITY_INSERT [dbo].[MBI_DocumentType] OFF
SET IDENTITY_INSERT [dbo].[MBI_Firms] ON 

INSERT [dbo].[MBI_Firms] ([FirmId], [FirmNr], [IsDefault]) VALUES (1, 17, 1)
SET IDENTITY_INSERT [dbo].[MBI_Firms] OFF
SET IDENTITY_INSERT [dbo].[MBI_Users] ON 

INSERT [dbo].[MBI_Users] ([UserId], [RobotposSecurityKey], [LogoUserName], [LogoPassword], [UserName], [Password]) VALUES (1, N'998877', N'LOGO', N'1', N'LOGO', N'1')
SET IDENTITY_INSERT [dbo].[MBI_Users] OFF
