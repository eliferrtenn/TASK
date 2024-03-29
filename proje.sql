USE [ProjeMakina]
GO
/****** Object:  Table [dbo].[Marka]    Script Date: 24.10.2023 01:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marka](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MarkaAd] [nvarchar](150) NOT NULL,
	[Yaratilma_Tarihi] [datetime2](7) NOT NULL,
	[Degistirilme_Tarihi] [datetime2](7) NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Marka] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Model]    Script Date: 24.10.2023 01:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ModelAd] [nvarchar](150) NOT NULL,
	[MarkaID] [bigint] NOT NULL,
	[Yaratilma_Tarihi] [datetime2](7) NOT NULL,
	[Degistirilme_Tarihi] [datetime2](7) NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 24.10.2023 01:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](150) NOT NULL,
	[LastName] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[MobilePhone] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[Yaratilma_Tarihi] [datetime2](7) NOT NULL,
	[Degistirilme_Tarihi] [datetime2](7) NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparis]    Script Date: 24.10.2023 01:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparis](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SiparisTarih] [datetime2](7) NOT NULL,
	[ToplamFiyat] [real] NOT NULL,
	[SiparisDurum] [int] NOT NULL,
	[SiparisKalem] [int] NOT NULL,
	[MusteriID] [bigint] NOT NULL,
	[Yaratilma_Tarihi] [datetime2](7) NOT NULL,
	[Degistirilme_Tarihi] [datetime2](7) NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Siparis] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 24.10.2023 01:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[Yaratilma_Tarihi] [datetime2](7) NOT NULL,
	[Degistirilme_Tarihi] [datetime2](7) NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Versiyon]    Script Date: 24.10.2023 01:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Versiyon](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[DepolamaKapasitesi] [real] NOT NULL,
	[Fiyat] [real] NOT NULL,
	[StokDurumu] [nvarchar](max) NOT NULL,
	[ModelID] [bigint] NOT NULL,
	[Yaratilma_Tarihi] [datetime2](7) NOT NULL,
	[Degistirilme_Tarihi] [datetime2](7) NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Versiyon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Marka] ON 

INSERT [dbo].[Marka] ([ID], [MarkaAd], [Yaratilma_Tarihi], [Degistirilme_Tarihi], [isDeleted], [isActive]) VALUES (1, N'MARKA-1', CAST(N'2023-10-21T00:00:00.0000000' AS DateTime2), CAST(N'2023-10-21T00:00:00.0000000' AS DateTime2), 0, 1)
SET IDENTITY_INSERT [dbo].[Marka] OFF
GO
SET IDENTITY_INSERT [dbo].[Model] ON 

INSERT [dbo].[Model] ([ID], [ModelAd], [MarkaID], [Yaratilma_Tarihi], [Degistirilme_Tarihi], [isDeleted], [isActive]) VALUES (1, N'Model1-AD', 1, CAST(N'2023-10-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-10-22T00:00:00.0000000' AS DateTime2), 0, 1)
SET IDENTITY_INSERT [dbo].[Model] OFF
GO
SET IDENTITY_INSERT [dbo].[Musteri] ON 

INSERT [dbo].[Musteri] ([ID], [FirstName], [LastName], [Email], [MobilePhone], [Password], [Yaratilma_Tarihi], [Degistirilme_Tarihi], [isDeleted], [isActive]) VALUES (1, N'Musteri Ad1', N'Musteri Soyad1', N'musteri@gmail.com', N'05070033286', N'ssss', CAST(N'2023-10-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-10-22T00:00:00.0000000' AS DateTime2), 0, 1)
SET IDENTITY_INSERT [dbo].[Musteri] OFF
GO
SET IDENTITY_INSERT [dbo].[Siparis] ON 

INSERT [dbo].[Siparis] ([ID], [SiparisTarih], [ToplamFiyat], [SiparisDurum], [SiparisKalem], [MusteriID], [Yaratilma_Tarihi], [Degistirilme_Tarihi], [isDeleted], [isActive]) VALUES (2, CAST(N'2023-10-22T00:00:00.0000000' AS DateTime2), 378, 2, 3, 1, CAST(N'2023-10-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-10-22T00:00:00.0000000' AS DateTime2), 0, 1)
SET IDENTITY_INSERT [dbo].[Siparis] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Email], [Password], [Yaratilma_Tarihi], [Degistirilme_Tarihi], [isDeleted], [isActive]) VALUES (1, N'vardabit', N'0000', CAST(N'2023-10-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-10-22T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[User] ([ID], [Email], [Password], [Yaratilma_Tarihi], [Degistirilme_Tarihi], [isDeleted], [isActive]) VALUES (2, N'errtenelif@gmail.com', N'00000', CAST(N'2023-10-22T14:02:49.8998831' AS DateTime2), CAST(N'2023-10-22T14:02:49.8998831' AS DateTime2), 0, 1)
INSERT [dbo].[User] ([ID], [Email], [Password], [Yaratilma_Tarihi], [Degistirilme_Tarihi], [isDeleted], [isActive]) VALUES (3, N'ertenneliff@gmail.com', N'Pj3Jn3X7dVUVOYrCyjuczFhhMQTrhbGlhSKcHAypTXS/s0pi6RNN2mNOuEdnZNUxu9Yuohy/f9sQCI/PBEfEAw==', CAST(N'2023-10-23T09:13:25.9708832' AS DateTime2), CAST(N'2023-10-23T09:13:25.9708832' AS DateTime2), 0, 1)
INSERT [dbo].[User] ([ID], [Email], [Password], [Yaratilma_Tarihi], [Degistirilme_Tarihi], [isDeleted], [isActive]) VALUES (4, N'vardabit@gmail.com', N'00000', CAST(N'2023-10-24T00:14:47.9191370' AS DateTime2), CAST(N'2023-10-24T00:14:47.9191440' AS DateTime2), 0, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Versiyon] ON 

INSERT [dbo].[Versiyon] ([ID], [DepolamaKapasitesi], [Fiyat], [StokDurumu], [ModelID], [Yaratilma_Tarihi], [Degistirilme_Tarihi], [isDeleted], [isActive]) VALUES (1, 10, 123, N'var', 1, CAST(N'2023-10-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-10-22T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[Versiyon] ([ID], [DepolamaKapasitesi], [Fiyat], [StokDurumu], [ModelID], [Yaratilma_Tarihi], [Degistirilme_Tarihi], [isDeleted], [isActive]) VALUES (2, 93, 9090, N'stokta', 1, CAST(N'2023-10-23T17:26:10.1784970' AS DateTime2), CAST(N'2023-10-23T17:26:10.1785030' AS DateTime2), 0, 1)
SET IDENTITY_INSERT [dbo].[Versiyon] OFF
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_Marka_MarkaID] FOREIGN KEY([MarkaID])
REFERENCES [dbo].[Marka] ([ID])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_Marka_MarkaID]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Musteri_MusteriID] FOREIGN KEY([MusteriID])
REFERENCES [dbo].[Musteri] ([ID])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Musteri_MusteriID]
GO
ALTER TABLE [dbo].[Versiyon]  WITH CHECK ADD  CONSTRAINT [FK_Versiyon_Model_ModelID] FOREIGN KEY([ModelID])
REFERENCES [dbo].[Model] ([ID])
GO
ALTER TABLE [dbo].[Versiyon] CHECK CONSTRAINT [FK_Versiyon_Model_ModelID]
GO
