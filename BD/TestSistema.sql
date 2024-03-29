USE [master]
GO
/****** Object:  Database [TestSistema]    Script Date: 26/6/2023 02:26:26 ******/
CREATE DATABASE [TestSistema]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestSistema', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TestSistema.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestSistema_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TestSistema_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TestSistema] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestSistema].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestSistema] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestSistema] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestSistema] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestSistema] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestSistema] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestSistema] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestSistema] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestSistema] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestSistema] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestSistema] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestSistema] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestSistema] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestSistema] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestSistema] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestSistema] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TestSistema] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestSistema] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestSistema] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestSistema] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestSistema] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestSistema] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TestSistema] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestSistema] SET RECOVERY FULL 
GO
ALTER DATABASE [TestSistema] SET  MULTI_USER 
GO
ALTER DATABASE [TestSistema] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestSistema] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestSistema] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestSistema] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestSistema] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestSistema', N'ON'
GO
ALTER DATABASE [TestSistema] SET QUERY_STORE = OFF
GO
USE [TestSistema]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/6/2023 02:26:28 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 26/6/2023 02:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[IdPermiso] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 26/6/2023 02:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolPermiso]    Script Date: 26/6/2023 02:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolPermiso](
	[Id] [uniqueidentifier] NOT NULL,
	[RolRefId] [uniqueidentifier] NOT NULL,
	[PermisoRefId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_RolPermiso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 26/6/2023 02:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[Id] [uniqueidentifier] NOT NULL,
	[JWT] [nvarchar](max) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/6/2023 02:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UserName] [nvarchar](50) NOT NULL,
	[Clave] [nvarchar](max) NOT NULL,
	[EmailAddress] [nvarchar](max) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[RolRefId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230625163259_initialmigration', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230625200310_migration2', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230625202051_migration3', N'5.0.17')
INSERT [dbo].[Permiso] ([IdPermiso], [Name], [Descripcion]) VALUES (N'cd864bff-fdd8-4b65-a222-1dec52804be1', N'Cliente', N'Permisos de Cliente')
INSERT [dbo].[Permiso] ([IdPermiso], [Name], [Descripcion]) VALUES (N'b4924c0a-609a-4baa-bc84-c2fe241863bf', N'Full', N'Permisos de Administrador')
INSERT [dbo].[Rol] ([IdRol], [Name]) VALUES (N'23ecb38c-2b79-4ea7-b818-4d0eac0f1b76', N'Administrador')
INSERT [dbo].[Rol] ([IdRol], [Name]) VALUES (N'bb388e14-1d76-4ca8-b849-69c39dd947be', N'Cliente')
INSERT [dbo].[RolPermiso] ([Id], [RolRefId], [PermisoRefId]) VALUES (N'ebe22f3a-bf65-4938-8757-4acc2d5952fb', N'23ecb38c-2b79-4ea7-b818-4d0eac0f1b76', N'b4924c0a-609a-4baa-bc84-c2fe241863bf')
INSERT [dbo].[RolPermiso] ([Id], [RolRefId], [PermisoRefId]) VALUES (N'30243cfb-fc14-4957-8009-6e0152933548', N'bb388e14-1d76-4ca8-b849-69c39dd947be', N'cd864bff-fdd8-4b65-a222-1dec52804be1')
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'28bd04f4-cab3-4f8f-bca9-060fa4028737', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImNsaWVudGUxIiwibmJmIjoxNjg3NzY1NTM3LCJleHAiOjE2ODc4NTE5MzcsImlhdCI6MTY4Nzc2NTUzN30.YE9hf92XaedwvnHpX_Vlh9R6Lk7oB1Vac13BIxD6l5o', 1, CAST(N'2023-06-26T01:45:37.3707876' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'ca36397d-d9b2-412d-98b8-1158e25069b0', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzY2MzM4LCJleHAiOjE2ODc4NTI3MzgsImlhdCI6MTY4Nzc2NjMzOH0.g0gIF-DLhLSFrfoi728bzYfoaBVkSJnsPA-twh0Fy6I', 1, CAST(N'2023-06-26T01:58:58.2004200' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'e688e323-1fc5-4c69-aaf1-2cace24cd333', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzYxNjI3LCJleHAiOjE2ODc4NDgwMjcsImlhdCI6MTY4Nzc2MTYyN30.YMn-NRr1z9OaT7D9r3IcsLUZOWiEB2OPNvI2fHKtplQ', 1, CAST(N'2023-06-26T00:40:27.9252976' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'a677908e-edcf-4533-b25e-3f7ccb153bc7', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzQwMDcxLCJleHAiOjE2ODc4MjY0NzEsImlhdCI6MTY4Nzc0MDA3MX0.SNRjviLh14yggLwZxKmPWHWdVXI_1hwCCnrmhp49X4o', 1, CAST(N'2023-06-25T18:41:11.9348922' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'0e3d1687-ca8b-4d2f-bacf-516a885023b5', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzYyOTEyLCJleHAiOjE2ODc4NDkzMTIsImlhdCI6MTY4Nzc2MjkxMn0.8SDPo23TrpSkc0NAMmXbKXQqYXkS6vMMBhib3_nuWXA', 1, CAST(N'2023-06-26T01:01:52.6902930' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'fec52316-5646-49a9-bfa3-69441eb4430a', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzMzNTExLCJleHAiOjE2ODc4MTk5MTEsImlhdCI6MTY4NzczMzUxMX0.3EdENb7NQTlUvwm32DJRR5qw0j3A-pSTX_9Z0V18N7o', 1, CAST(N'2023-06-25T16:51:51.8734860' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'49d70239-34de-424e-a891-700c77a36495', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzM4NzkyLCJleHAiOjE2ODc4MjUxOTIsImlhdCI6MTY4NzczODc5Mn0.cPjfoWjMlWX18PPJFhBMpH-sqgGLJD3bYwbNRAanrgY', 1, CAST(N'2023-06-25T18:19:52.3433229' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'3b77db41-df9b-4022-9771-70c9e80ea79f', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImNsaWVudGUzIiwibmJmIjoxNjg3NzU5NzUwLCJleHAiOjE2ODc4NDYxNTAsImlhdCI6MTY4Nzc1OTc1MH0.RvLuefN32gOOUkc9KRWMMyuke0dApk9XgEDAi1se56c', 1, CAST(N'2023-06-26T00:09:10.6550337' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'b361d79c-3f75-42ff-b7ec-851626d11f35', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzY3MzA2LCJleHAiOjE2ODc4NTM3MDYsImlhdCI6MTY4Nzc2NzMwNn0.IKyeR37z38Es2vnzs5n3ERKGFUsiiSgaHUpy0sRONt4', 1, CAST(N'2023-06-26T02:15:06.1379227' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'e10a9bf2-572c-4013-998f-8a3d3a21c61c', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzI1MzY2LCJleHAiOjE2ODc4MTE3NjYsImlhdCI6MTY4NzcyNTM2Nn0.Y_hb2y6xU4boHoBuSnOZOQ-q8kzmgFQy0S2S8fOgF74', 1, CAST(N'2023-06-25T14:36:07.1328924' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'ab27e292-202e-43e1-bf3d-8cd68f08f961', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzQ1OTA1LCJleHAiOjE2ODc4MzIzMDUsImlhdCI6MTY4Nzc0NTkwNX0.23FfVunrBCY5eyo3mdq0wvpfk5ZUisVNo4R8h6SVgwU', 1, CAST(N'2023-06-25T20:18:25.8495087' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'5df7bc99-78e6-439e-964e-9d72e02f88fd', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzY3MjM5LCJleHAiOjE2ODc4NTM2MzksImlhdCI6MTY4Nzc2NzIzOX0.TRyn3fhIpS91aLvxzzuYa7ejFYhaCSZ5VsU07e3nK9c', 1, CAST(N'2023-06-26T02:13:59.7207567' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'b1343a58-3bb3-413a-81cd-a2d5625ec1fd', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzU5NjY2LCJleHAiOjE2ODc4NDYwNjYsImlhdCI6MTY4Nzc1OTY2Nn0.e3XdSME15ltMQv5LJBwO-1K5v08nmcxu82aiL-O0QVw', 1, CAST(N'2023-06-26T00:07:47.1875482' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'f0c4ce0f-4216-4d39-816b-a5101d3b7c6b', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzY0ODM5LCJleHAiOjE2ODc4NTEyMzksImlhdCI6MTY4Nzc2NDgzOX0.dXPym-fiATTUAYmcC7Yeo6Li6H6TRN2_q0wgwqOLrUk', 1, CAST(N'2023-06-26T01:33:59.6940059' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'e8804972-404c-4544-8920-b5f53502586a', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzYxODIzLCJleHAiOjE2ODc4NDgyMjMsImlhdCI6MTY4Nzc2MTgyM30.U7P7xK_W0URPdo3TVal3ECYA8gTmRwVQlg6fa2EjttU', 1, CAST(N'2023-06-26T00:43:44.0043365' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'fb1e8672-70ac-49a7-97a1-b87c5f815fa4', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImNsaWVudGUxIiwibmJmIjoxNjg3NzYyNDExLCJleHAiOjE2ODc4NDg4MTEsImlhdCI6MTY4Nzc2MjQxMX0.cEqj7NRmnNi2AvyctZjQnjoNavGCQ7iyqGOdAqXS9o8', 1, CAST(N'2023-06-26T00:53:31.2113568' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'c631ac24-b7db-4f5c-a91b-b936dc0eb4c8', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzEwOTUzLCJleHAiOjE2ODc3OTczNTMsImlhdCI6MTY4NzcxMDk1M30.q6Giel-azG6XO1341jc7JqJAdBtv1jVfQzLQ7yusnwc', 1, CAST(N'2023-06-25T10:35:54.0502372' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'366174f4-a1f4-454d-aa52-cd77921ec5aa', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzY3MTg1LCJleHAiOjE2ODc4NTM1ODUsImlhdCI6MTY4Nzc2NzE4NX0.Y0wQkindOCDCvHHQI7japx26RTVbyPkFiDgOpyg3njI', 1, CAST(N'2023-06-26T02:13:05.7391008' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'c47e8390-fa30-4a9e-a1e9-cf293d03e2dd', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImNsaWVudGU0IiwibmJmIjoxNjg3NzYwMDkwLCJleHAiOjE2ODc4NDY0OTAsImlhdCI6MTY4Nzc2MDA5MH0.dTgz2XX0qcQrxZV1pe2F8TrXKDur7M5MLBYCKdxFOJQ', 1, CAST(N'2023-06-26T00:14:50.1170395' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'84b9e163-6dbe-4d41-9689-e41850ff3e53', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzI0NTk3LCJleHAiOjE2ODc4MTA5OTcsImlhdCI6MTY4NzcyNDU5N30.j8RgxepsiqcLbEdeyK37EDZfXiQ2WiZ6Qx80gVZ-1ss', 1, CAST(N'2023-06-25T14:23:17.9351957' AS DateTime2))
INSERT [dbo].[Session] ([Id], [JWT], [Enabled], [FechaCreacion]) VALUES (N'e276e0db-379f-4bcd-99a9-f62be6c54f34', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwibmJmIjoxNjg3NzMxNzA1LCJleHAiOjE2ODc4MTgxMDUsImlhdCI6MTY4NzczMTcwNX0.dAf6PdvOOt3p1Jkq48yb_gG1tglFsB8mlv5DzpSl388', 1, CAST(N'2023-06-25T16:21:45.6269681' AS DateTime2))
INSERT [dbo].[Usuario] ([UserName], [Clave], [EmailAddress], [Enabled], [RolRefId]) VALUES (N'Admin', N'B/SKTsuv5ygdQ+6eT9uhKg47jjn0DKEiuO6cnpGt74Y=', N'admin@intermail.com', 1, N'23ecb38c-2b79-4ea7-b818-4d0eac0f1b76')
INSERT [dbo].[Usuario] ([UserName], [Clave], [EmailAddress], [Enabled], [RolRefId]) VALUES (N'Admin2', N'vNRucOPiyMVPjfR634R1Mflz4pH7/gep/BJyhlI5J90=', N'admin2@gmail.com', 1, N'23ecb38c-2b79-4ea7-b818-4d0eac0f1b76')
INSERT [dbo].[Usuario] ([UserName], [Clave], [EmailAddress], [Enabled], [RolRefId]) VALUES (N'cliente1', N'9fLDxIS6ai3jVqs8eSRHX3tH2bmEfXnRFvHeOA7DhUk=', N'cliente1@gmail.com', 1, N'bb388e14-1d76-4ca8-b849-69c39dd947be')
INSERT [dbo].[Usuario] ([UserName], [Clave], [EmailAddress], [Enabled], [RolRefId]) VALUES (N'cliente2', N'BqnzZ6LUyUFdky+zZ5QrHLtjUQKQAgendKHCIqusQ5s=', N'cliente2@gmail.com', 1, N'bb388e14-1d76-4ca8-b849-69c39dd947be')
INSERT [dbo].[Usuario] ([UserName], [Clave], [EmailAddress], [Enabled], [RolRefId]) VALUES (N'cliente3', N'OoOKVnDvkY2lWTgADHVbygXT9inEAx0DPct2EDBHq0s=', N'cliente3@gmail.com', 1, N'bb388e14-1d76-4ca8-b849-69c39dd947be')
INSERT [dbo].[Usuario] ([UserName], [Clave], [EmailAddress], [Enabled], [RolRefId]) VALUES (N'cliente4', N'EABPImaX1mOIW0xsn0cpeBK/pCxLhtpBsMLSM1zWtFY=', N'cliente4@gmail.com', 1, N'bb388e14-1d76-4ca8-b849-69c39dd947be')
/****** Object:  Index [IX_RolPermiso_PermisoRefId]    Script Date: 26/6/2023 02:26:29 ******/
CREATE NONCLUSTERED INDEX [IX_RolPermiso_PermisoRefId] ON [dbo].[RolPermiso]
(
	[PermisoRefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RolPermiso_RolRefId]    Script Date: 26/6/2023 02:26:29 ******/
CREATE NONCLUSTERED INDEX [IX_RolPermiso_RolRefId] ON [dbo].[RolPermiso]
(
	[RolRefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuario_RolRefId]    Script Date: 26/6/2023 02:26:29 ******/
CREATE NONCLUSTERED INDEX [IX_Usuario_RolRefId] ON [dbo].[Usuario]
(
	[RolRefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RolPermiso]  WITH CHECK ADD  CONSTRAINT [FK_RolPermiso_Permiso_PermisoRefId] FOREIGN KEY([PermisoRefId])
REFERENCES [dbo].[Permiso] ([IdPermiso])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolPermiso] CHECK CONSTRAINT [FK_RolPermiso_Permiso_PermisoRefId]
GO
ALTER TABLE [dbo].[RolPermiso]  WITH CHECK ADD  CONSTRAINT [FK_RolPermiso_Rol_RolRefId] FOREIGN KEY([RolRefId])
REFERENCES [dbo].[Rol] ([IdRol])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolPermiso] CHECK CONSTRAINT [FK_RolPermiso_Rol_RolRefId]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_RolRefId] FOREIGN KEY([RolRefId])
REFERENCES [dbo].[Rol] ([IdRol])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol_RolRefId]
GO
USE [master]
GO
ALTER DATABASE [TestSistema] SET  READ_WRITE 
GO
