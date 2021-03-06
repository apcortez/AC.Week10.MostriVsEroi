USE [master]
GO
/****** Object:  Database [EroiVsMostri]    Script Date: 10/1/2021 2:48:22 PM ******/
CREATE DATABASE [EroiVsMostri]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EroiVsMostri', FILENAME = N'C:\Users\angelica.cortez\EroiVsMostri.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EroiVsMostri_log', FILENAME = N'C:\Users\angelica.cortez\EroiVsMostri_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EroiVsMostri] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EroiVsMostri].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EroiVsMostri] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EroiVsMostri] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EroiVsMostri] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EroiVsMostri] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EroiVsMostri] SET ARITHABORT OFF 
GO
ALTER DATABASE [EroiVsMostri] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EroiVsMostri] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EroiVsMostri] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EroiVsMostri] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EroiVsMostri] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EroiVsMostri] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EroiVsMostri] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EroiVsMostri] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EroiVsMostri] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EroiVsMostri] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EroiVsMostri] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EroiVsMostri] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EroiVsMostri] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EroiVsMostri] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EroiVsMostri] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EroiVsMostri] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EroiVsMostri] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EroiVsMostri] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EroiVsMostri] SET  MULTI_USER 
GO
ALTER DATABASE [EroiVsMostri] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EroiVsMostri] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EroiVsMostri] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EroiVsMostri] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EroiVsMostri] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EroiVsMostri] SET QUERY_STORE = OFF
GO
USE [EroiVsMostri]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [EroiVsMostri]
GO
/****** Object:  Table [dbo].[Arma]    Script Date: 10/1/2021 2:48:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[PuntiDanno] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 10/1/2021 2:48:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Discriminator] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personaggio]    Script Date: 10/1/2021 2:48:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personaggio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Livello] [int] NOT NULL,
	[PuntiVita] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdArma] [int] NOT NULL,
	[PuntiAccumulati] [int] NULL,
	[IdGiocatore] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 10/1/2021 2:48:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[IsAdmin] [bit] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arma] ON 

INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (1, N'Alabarda', 15, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (2, N'Ascia', 8, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (3, N'Spadone', 15, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (4, N'Arco e Freccie', 8, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (5, N'Bastone Magico', 10, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (6, N'Onda d''urto', 15, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (7, N'Discorso noioso', 4, 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (8, N'Magia Nera', 3, 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (9, N'Arco', 7, 4)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (10, N'Mazza Chiodata', 10, 4)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (11, N'Alabarda del drago', 30, 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (12, N'Tempesta oscura', 15, 5)
SET IDENTITY_INSERT [dbo].[Arma] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Nome], [Discriminator]) VALUES (1, N'Guerriero', N'Eroe')
INSERT [dbo].[Categoria] ([Id], [Nome], [Discriminator]) VALUES (2, N'Mago', N'Eroe')
INSERT [dbo].[Categoria] ([Id], [Nome], [Discriminator]) VALUES (3, N'Cultista', N'Mostro')
INSERT [dbo].[Categoria] ([Id], [Nome], [Discriminator]) VALUES (4, N'Orco', N'Mostro')
INSERT [dbo].[Categoria] ([Id], [Nome], [Discriminator]) VALUES (5, N'Signore del Male', N'Mostro')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Personaggio] ON 

INSERT [dbo].[Personaggio] ([Id], [Nome], [Livello], [PuntiVita], [IdCategoria], [IdArma], [PuntiAccumulati], [IdGiocatore]) VALUES (1, N'Spiderman', 4, 80, 1, 1, 55, 1)
INSERT [dbo].[Personaggio] ([Id], [Nome], [Livello], [PuntiVita], [IdCategoria], [IdArma], [PuntiAccumulati], [IdGiocatore]) VALUES (2, N'Merlino', 3, 60, 2, 5, 30, 2)
INSERT [dbo].[Personaggio] ([Id], [Nome], [Livello], [PuntiVita], [IdCategoria], [IdArma], [PuntiAccumulati], [IdGiocatore]) VALUES (4, N'Shrek', 3, 60, 4, 10, NULL, NULL)
INSERT [dbo].[Personaggio] ([Id], [Nome], [Livello], [PuntiVita], [IdCategoria], [IdArma], [PuntiAccumulati], [IdGiocatore]) VALUES (5, N'Cult', 1, 20, 3, 7, NULL, NULL)
INSERT [dbo].[Personaggio] ([Id], [Nome], [Livello], [PuntiVita], [IdCategoria], [IdArma], [PuntiAccumulati], [IdGiocatore]) VALUES (6, N'Boss', 5, 100, 5, 11, NULL, NULL)
INSERT [dbo].[Personaggio] ([Id], [Nome], [Livello], [PuntiVita], [IdCategoria], [IdArma], [PuntiAccumulati], [IdGiocatore]) VALUES (7, N'Malefica', 4, 80, 5, 12, NULL, NULL)
INSERT [dbo].[Personaggio] ([Id], [Nome], [Livello], [PuntiVita], [IdCategoria], [IdArma], [PuntiAccumulati], [IdGiocatore]) VALUES (8, N'rosa', 3, 60, 2, 6, 5, 1)
INSERT [dbo].[Personaggio] ([Id], [Nome], [Livello], [PuntiVita], [IdCategoria], [IdArma], [PuntiAccumulati], [IdGiocatore]) VALUES (10, N'mostro1', 3, 60, 3, 7, NULL, NULL)
INSERT [dbo].[Personaggio] ([Id], [Nome], [Livello], [PuntiVita], [IdCategoria], [IdArma], [PuntiAccumulati], [IdGiocatore]) VALUES (16, N'Batman', 5, 100, 1, 1, 80, 4)
INSERT [dbo].[Personaggio] ([Id], [Nome], [Livello], [PuntiVita], [IdCategoria], [IdArma], [PuntiAccumulati], [IdGiocatore]) VALUES (17, N'Amonra', 1, 20, 5, 12, NULL, NULL)
INSERT [dbo].[Personaggio] ([Id], [Nome], [Livello], [PuntiVita], [IdCategoria], [IdArma], [PuntiAccumulati], [IdGiocatore]) VALUES (18, N'Pitbull', 1, 20, 1, 2, 10, 4)
SET IDENTITY_INSERT [dbo].[Personaggio] OFF
GO
SET IDENTITY_INSERT [dbo].[Utente] ON 

INSERT [dbo].[Utente] ([Id], [Username], [Password], [IsAdmin]) VALUES (1, N'pippo', N'pw1', 1)
INSERT [dbo].[Utente] ([Id], [Username], [Password], [IsAdmin]) VALUES (2, N'pluto', N'pw2', 0)
INSERT [dbo].[Utente] ([Id], [Username], [Password], [IsAdmin]) VALUES (3, N'paperino', N'pw3', 1)
INSERT [dbo].[Utente] ([Id], [Username], [Password], [IsAdmin]) VALUES (4, N'jelly', N'ciao', 0)
INSERT [dbo].[Utente] ([Id], [Username], [Password], [IsAdmin]) VALUES (5, N'pippi', N'pippi', 0)
SET IDENTITY_INSERT [dbo].[Utente] OFF
GO
USE [master]
GO
ALTER DATABASE [EroiVsMostri] SET  READ_WRITE 
GO
