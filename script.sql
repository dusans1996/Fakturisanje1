USE [Fakturisanje]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/22/2019 8:15:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/22/2019 8:15:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/22/2019 8:15:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/22/2019 8:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/22/2019 8:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/22/2019 8:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/22/2019 8:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[Adresa] [nvarchar](30) NOT NULL,
	[Drzava] [nvarchar](30) NOT NULL,
	[Grad] [nvarchar](30) NOT NULL,
	[Ime] [nvarchar](30) NOT NULL,
	[Prezime] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/22/2019 8:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faktura]    Script Date: 1/22/2019 8:15:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faktura](
	[FakturaId] [int] IDENTITY(1,1) NOT NULL,
	[KupacId] [nvarchar](400) NOT NULL,
	[DatumFakture] [datetime] NULL,
	[BrojFakture] [nvarchar](10) NOT NULL,
	[UkupnoFaktura] [decimal](7, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FakturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kupac]    Script Date: 1/22/2019 8:15:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kupac](
	[KupacId] [nvarchar](400) NOT NULL,
	[Ime] [nvarchar](30) NOT NULL,
	[Prezime] [nvarchar](30) NOT NULL,
	[Drzava] [nvarchar](30) NOT NULL,
	[Grad] [nvarchar](30) NOT NULL,
	[Adresa] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KupacId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stavka]    Script Date: 1/22/2019 8:15:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stavka](
	[StavkaId] [int] IDENTITY(1,1) NOT NULL,
	[FakturaId] [int] NOT NULL,
	[RedniBroj] [int] NOT NULL,
	[Kolicina] [int] NOT NULL,
	[Cena] [decimal](18, 0) NOT NULL,
	[Ukupno] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[StavkaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'2.0.3-rtm-10026')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190121190455_Prva', N'2.0.3-rtm-10026')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [Adresa], [Drzava], [Grad], [Ime], [Prezime]) VALUES (N'7772e12d-a2f0-451e-ba9f-f8829bd766aa', 0, N'3e31875e-e384-4e01-8e59-a18d5c387a48', N'admin@gmail.com', 0, 1, NULL, N'ADMIN@GMAIL.COM', N'ADMIN@GMAIL.COM', N'AQAAAAEAACcQAAAAECbx0oDmiOReJ/R+DFga57hFlelv3jPmHvq63pVl9XIsOjA3ZJCAsc16MlAuvKl8dA==', NULL, 0, N'bd22c828-32e8-41ba-b624-43be8c43dcf1', 0, N'admin@gmail.com', N'Ljubicica 2b/11', N'Srbija', N'Beograd', N'Dusan', N'Stojanovic')
SET IDENTITY_INSERT [dbo].[Faktura] ON 

INSERT [dbo].[Faktura] ([FakturaId], [KupacId], [DatumFakture], [BrojFakture], [UkupnoFaktura]) VALUES (1, N'7772e12d-a2f0-451e-ba9f-f8829bd766aa', CAST(N'2019-01-11T10:46:36.490' AS DateTime), N'2', CAST(344.44 AS Decimal(7, 2)))
INSERT [dbo].[Faktura] ([FakturaId], [KupacId], [DatumFakture], [BrojFakture], [UkupnoFaktura]) VALUES (2, N'7772e12d-a2f0-451e-ba9f-f8829bd766aa', CAST(N'2019-01-22T10:47:14.223' AS DateTime), N'1', CAST(1.00 AS Decimal(7, 2)))
INSERT [dbo].[Faktura] ([FakturaId], [KupacId], [DatumFakture], [BrojFakture], [UkupnoFaktura]) VALUES (3, N'3', CAST(N'2019-12-11T00:00:00.000' AS DateTime), N'1', CAST(1414.00 AS Decimal(7, 2)))
SET IDENTITY_INSERT [dbo].[Faktura] OFF
INSERT [dbo].[Kupac] ([KupacId], [Ime], [Prezime], [Drzava], [Grad], [Adresa]) VALUES (N'3', N'Dragan', N'Petrovic', N'Srbija', N'Zrenjanin', N'Glavna 5')
INSERT [dbo].[Kupac] ([KupacId], [Ime], [Prezime], [Drzava], [Grad], [Adresa]) VALUES (N'7772e12d-a2f0-451e-ba9f-f8829bd766aa', N'Dusan', N'Stojanovic', N'Srbija', N'Beograd', N'Ljubicica 2b/11')
SET IDENTITY_INSERT [dbo].[Stavka] ON 

INSERT [dbo].[Stavka] ([StavkaId], [FakturaId], [RedniBroj], [Kolicina], [Cena], [Ukupno]) VALUES (1, 1, 2, 242, CAST(121331 AS Decimal(18, 0)), CAST(21 AS Decimal(18, 0)))
INSERT [dbo].[Stavka] ([StavkaId], [FakturaId], [RedniBroj], [Kolicina], [Cena], [Ukupno]) VALUES (3, 2, 3, 3, CAST(33 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)))
INSERT [dbo].[Stavka] ([StavkaId], [FakturaId], [RedniBroj], [Kolicina], [Cena], [Ukupno]) VALUES (4, 2, 1, 335, CAST(121331 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Stavka] OFF
/****** Object:  Index [UQ__Stavka__863A8DE7E2DC4327]    Script Date: 1/22/2019 8:15:17 PM ******/
ALTER TABLE [dbo].[Stavka] ADD UNIQUE NONCLUSTERED 
(
	[RedniBroj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Adresa]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Drzava]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Grad]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Ime]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Prezime]
GO
ALTER TABLE [dbo].[Faktura] ADD  DEFAULT (getdate()) FOR [DatumFakture]
GO
ALTER TABLE [dbo].[Kupac] ADD  DEFAULT ('Srbija') FOR [Drzava]
GO
ALTER TABLE [dbo].[Kupac] ADD  DEFAULT ('Beograd') FOR [Grad]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Faktura]  WITH CHECK ADD FOREIGN KEY([KupacId])
REFERENCES [dbo].[Kupac] ([KupacId])
GO
ALTER TABLE [dbo].[Stavka]  WITH CHECK ADD FOREIGN KEY([FakturaId])
REFERENCES [dbo].[Faktura] ([FakturaId])
GO
ALTER TABLE [dbo].[Stavka]  WITH CHECK ADD  CONSTRAINT [CHK_Cena] CHECK  (([Cena]>(0)))
GO
ALTER TABLE [dbo].[Stavka] CHECK CONSTRAINT [CHK_Cena]
GO
ALTER TABLE [dbo].[Stavka]  WITH CHECK ADD  CONSTRAINT [CHK_Kolicina] CHECK  (([Kolicina]>(0)))
GO
ALTER TABLE [dbo].[Stavka] CHECK CONSTRAINT [CHK_Kolicina]
GO
