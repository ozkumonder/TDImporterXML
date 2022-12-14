USE [GODB]
GO
/****** Object:  Table [dbo].[MBI_BrachPairing]    Script Date: 15.06.2017 13:45:29 ******/
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
/****** Object:  Table [dbo].[MBI_DocumentType]    Script Date: 15.06.2017 13:45:29 ******/
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
/****** Object:  Table [dbo].[MBI_Firms]    Script Date: 15.06.2017 13:45:29 ******/
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
/****** Object:  Table [dbo].[MBI_TransferredData]    Script Date: 15.06.2017 13:45:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MBI_TransferredData](
	[TransferId] [int] NOT NULL,
	[TransFicheref] [nvarchar](50) NULL,
	[TransData] [nvarchar](max) NULL,
	[TransBranchNumber] [nvarchar](50) NULL,
	[TransactionDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.MBI_TransferredData] PRIMARY KEY CLUSTERED 
(
	[TransferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MBI_UnTransferredData]    Script Date: 15.06.2017 13:45:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MBI_UnTransferredData](
	[UnTransDataId] [int] IDENTITY(1,1) NOT NULL,
	[DataTypeId] [int] NULL,
	[UnTransDate] [nvarchar](50) NULL,
	[UnTransBranchNumber] [nvarchar](50) NULL,
	[UnTransError] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.MBI_UnTransferredData] PRIMARY KEY CLUSTERED 
(
	[UnTransDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MBI_Users]    Script Date: 15.06.2017 13:45:29 ******/
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
