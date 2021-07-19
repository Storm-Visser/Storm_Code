--Create de gehele database, verander op regel 8 en 10 de naam naar de eigen naam
USE [master]
GO
/****** Object:  Database [Netflix]    Script Date: 04/05/2021 19:08:29 ******/
CREATE DATABASE [Netflix]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Netflix', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.STORM\MSSQL\DATA\Netflix.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Netflix_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.STORM\MSSQL\DATA\Netflix_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Netflix] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Netflix].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Netflix] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Netflix] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Netflix] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Netflix] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Netflix] SET ARITHABORT OFF 
GO
ALTER DATABASE [Netflix] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Netflix] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Netflix] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Netflix] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Netflix] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Netflix] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Netflix] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Netflix] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Netflix] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Netflix] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Netflix] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Netflix] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Netflix] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Netflix] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Netflix] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Netflix] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Netflix] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Netflix] SET RECOVERY FULL 
GO
ALTER DATABASE [Netflix] SET  MULTI_USER 
GO
ALTER DATABASE [Netflix] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Netflix] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Netflix] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Netflix] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Netflix] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Netflix] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Netflix', N'ON'
GO
ALTER DATABASE [Netflix] SET QUERY_STORE = OFF
GO
USE [Netflix]
GO
/****** Object:  Table [dbo].[Abonnement]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abonnement](
	[abonnementID] [int] NOT NULL IDENTITY(1,1),
	[naam] [varchar](3) NOT NULL,
	[bedrag] [float] NOT NULL,
 CONSTRAINT [PK_Abonnement] PRIMARY KEY CLUSTERED 
(
	[abonnementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aflevering]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aflevering](
	[afleveringID] [int] NOT NULL IDENTITY(1,1),
	[seizoenID] [int] NOT NULL,
	[nummer] [int] NOT NULL,
	[naam] [varchar](100) NOT NULL,
	[afleveringLocatie] [varchar](max) NOT NULL,
	[omschrijving] [varchar](max) NOT NULL,
	[tijdsDuur] [time](7) NOT NULL,
	[resolutie] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Aflevering] PRIMARY KEY CLUSTERED 
(
	[afleveringID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Films]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Films](
	[filmID] [int] NOT NULL IDENTITY(1,1),
	[genreID] [int] NOT NULL DEFAULT 1,
	[naam] [varchar](100) NOT NULL,
	[filmLocatie] [varchar](max) NOT NULL,
	[omschrijving] [varchar](max) NOT NULL,
	[tijdsDuur] [time](7) NOT NULL,
	[resolutie] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Film] PRIMARY KEY CLUSTERED 
(
	[filmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmGeschiedenis]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmGeschiedenis](
	[filmGeschiedenisID] [int] NOT NULL IDENTITY(1,1),
	[profielID] [int] NOT NULL,
	[filmID] [int] NOT NULL,
	[ondertitelingID] [int] NULL,
	[tijd] [time](7) NOT NULL,
	[kijkDatum] [datetime] NOT NULL,
 CONSTRAINT [PK_filmGeschiedenis] PRIMARY KEY CLUSTERED 
(
	[filmGeschiedenisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gebruiker]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gebruiker](
	[gebruikerID] [int] NOT NULL IDENTITY(1,1),
	[email] [varchar](100) NOT NULL,
	[wachtwoord] [varchar](max) NOT NULL,
	[geactiveerd] [bit] NOT NULL,
	[aantalInlogPogingen] [int] NULL,
	[aanmaakDatum] [datetime] NOT NULL,
	[krijgtKorting] [bit] NOT NULL,
	[isUitgenodigd] [bit] NOT NULL,
 CONSTRAINT [PK_Gebruiker] PRIMARY KEY CLUSTERED 
(
	[gebruikerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[genreID] [int] NOT NULL IDENTITY(1,1),
	[naam] [varchar](100) NOT NULL,
	[omschrijving] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[genreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KijkLijst]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KijkLijst](
	[kijkLijstID] [int] NOT NULL IDENTITY(1,1),
	[profielID] [int] NOT NULL,
	[serieID] [int] NULL,
	[filmID] [int] NULL,
 CONSTRAINT [PK_KijkLijst] PRIMARY KEY CLUSTERED 
(
	[kijkLijstID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kijkwijzer]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kijkwijzer](
	[kijkwijzerID] [int] NOT NULL IDENTITY(1,1),
	[filmID] [int] NULL,
	[serieID] [int] NULL,
	[kijkwijzerIndicatieID] [int] NOT NULL,
 CONSTRAINT [PK_Kijkwijzer] PRIMARY KEY CLUSTERED 
(
	[kijkwijzerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KijkwijzerIndicatie]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KijkwijzerIndicatie](
	[kijkwijzerIndicatieID] [int] NOT NULL IDENTITY(1,1),
	[omschrijving] [varchar](50) NOT NULL,
 CONSTRAINT [PK_KijkwijzerIndicatie] PRIMARY KEY CLUSTERED 
(
	[kijkwijzerIndicatieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopendAbonnement]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopendAbonnement](
	[lopendAbonnementID] [int] NOT NULL IDENTITY(1,1),
	[gebruikerID] [int] NOT NULL,
	[abonnementID] [int] NOT NULL,
	[aankoopDatum] [datetime] NOT NULL,
 CONSTRAINT [PK_LopendAbonnement] PRIMARY KEY CLUSTERED 
(
	[lopendAbonnementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ondertiteling]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ondertiteling](
	[ondertitelingID] [int] NOT NULL IDENTITY(1,1),
	[filmID] [int] NULL,
	[afleveringID] [int] NULL,
	[taal] [varchar](50) NOT NULL,
	[ondertitelingLocatie] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Ondertiteling] PRIMARY KEY CLUSTERED 
(
	[ondertitelingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiel]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiel](
	[profielID] [int] NOT NULL IDENTITY(1,1),
	[gebruikerID] [int] NOT NULL,
	[naam] [varchar](50) NOT NULL,
	[fotoLocatie] [varchar](max) NULL,
	[geboorteDatum] [datetime] NOT NULL,
	[taal] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Profiel] PRIMARY KEY CLUSTERED 
(
	[profielID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seizoen]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seizoen](
	[seizoenID] [int] NOT NULL IDENTITY(1,1),
	[serieID] [int] NOT NULL,
	[nummer] [int] NOT NULL,
	[naam] [varchar](100) NOT NULL,
	[omschrijving] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Seizoen] PRIMARY KEY CLUSTERED 
(
	[seizoenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Serie]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Serie](
	[serieID] [int] NOT NULL IDENTITY(1,1),
	[genreID] [int] NOT NULL DEFAULT 1,
	[naam] [varchar](100) NOT NULL,
	[omschrijving] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Serie] PRIMARY KEY CLUSTERED 
(
	[serieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SerieGeschiedenis]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SerieGeschiedenis](
	[serieGeschiedenisID] [int] NOT NULL IDENTITY(1,1),
	[profielID] [int] NOT NULL,
	[afleveringID] [int] NOT NULL,
	[ondertitelingID] [int] NULL,
	[tijd] [time](7) NOT NULL,
	[kijkDatum] [datetime] NOT NULL,
 CONSTRAINT [PK_SerieGeschiedenis] PRIMARY KEY CLUSTERED 
(
	[serieGeschiedenisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voorkeur]    Script Date: 04/05/2021 19:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voorkeur](
	[voorkeurID] [int] NOT NULL IDENTITY(1,1),
	[profielID] [int] NOT NULL,
	[filmID] [int] NULL,
	[genreID] [int] NULL,
	[kijkwijzerIndicatieID] [int] NULL,
	[serieID] [int] NULL,
 CONSTRAINT [PK_Voorkeur] PRIMARY KEY CLUSTERED 
(
	[voorkeurID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aflevering]  WITH CHECK ADD  CONSTRAINT [FK_Aflevering_Seizoen] FOREIGN KEY([seizoenID])
REFERENCES [dbo].[Seizoen] ([seizoenID]) 
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Aflevering] CHECK CONSTRAINT [FK_Aflevering_Seizoen]
GO
ALTER TABLE [dbo].[Films]  WITH CHECK ADD  CONSTRAINT [FK_Film_Genre] FOREIGN KEY([genreID])
REFERENCES [dbo].[Genres] ([genreID])
ON DELETE SET DEFAULT ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Films] CHECK CONSTRAINT [FK_Film_Genre]
GO
ALTER TABLE [dbo].[FilmGeschiedenis]  WITH CHECK ADD  CONSTRAINT [FK_filmGeschiedenis_Film] FOREIGN KEY([filmID])
REFERENCES [dbo].[Films] ([filmID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[FilmGeschiedenis] CHECK CONSTRAINT [FK_filmGeschiedenis_Film]
GO
ALTER TABLE [dbo].[FilmGeschiedenis]  WITH CHECK ADD  CONSTRAINT [FK_filmGeschiedenis_Profiel] FOREIGN KEY([profielID])
REFERENCES [dbo].[Profiel] ([profielID])
ON DELETE CASCADE  ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[FilmGeschiedenis] CHECK CONSTRAINT [FK_filmGeschiedenis_Profiel]
GO
ALTER TABLE [dbo].[FilmGeschiedenis]  WITH CHECK ADD  CONSTRAINT [FK_filmGeschiedenis_Ondertiteling] FOREIGN KEY([ondertitelingID])
REFERENCES [dbo].[Ondertiteling] ([ondertitelingID])
ON DELETE SET NULL ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[FilmGeschiedenis] CHECK CONSTRAINT [FK_filmGeschiedenis_Ondertiteling]
GO
ALTER TABLE [dbo].[KijkLijst]  WITH CHECK ADD  CONSTRAINT [FK_KijkLijst_Film] FOREIGN KEY([filmID])
REFERENCES [dbo].[Films] ([filmID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[KijkLijst] CHECK CONSTRAINT [FK_KijkLijst_Film]
GO
ALTER TABLE [dbo].[KijkLijst]  WITH CHECK ADD  CONSTRAINT [FK_KijkLijst_Profiel] FOREIGN KEY([profielID])
REFERENCES [dbo].[Profiel] ([profielID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[KijkLijst] CHECK CONSTRAINT [FK_KijkLijst_Profiel]
GO
ALTER TABLE [dbo].[KijkLijst]  WITH CHECK ADD  CONSTRAINT [FK_KijkLijst_Serie] FOREIGN KEY([serieID])
REFERENCES [dbo].[Serie] ([serieID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[KijkLijst] CHECK CONSTRAINT [FK_KijkLijst_Serie]
GO
ALTER TABLE [dbo].[Kijkwijzer]  WITH CHECK ADD  CONSTRAINT [FK_Kijkwijzer_Film] FOREIGN KEY([filmID])
REFERENCES [dbo].[Films] ([filmID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Kijkwijzer] CHECK CONSTRAINT [FK_Kijkwijzer_Film]
GO
ALTER TABLE [dbo].[Kijkwijzer]  WITH CHECK ADD  CONSTRAINT [FK_Kijkwijzer_Serie] FOREIGN KEY([serieID])
REFERENCES [dbo].[Serie] ([serieID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Kijkwijzer] CHECK CONSTRAINT [FK_Kijkwijzer_Serie]
GO
ALTER TABLE [dbo].[Kijkwijzer]  WITH CHECK ADD  CONSTRAINT [FK_Kijkwijzer_KijkwijzerIndicatie] FOREIGN KEY([kijkwijzerIndicatieID])
REFERENCES [dbo].[KijkwijzerIndicatie] ([kijkwijzerIndicatieID])
ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[Kijkwijzer] CHECK CONSTRAINT [FK_Kijkwijzer_KijkwijzerIndicatie]
GO
ALTER TABLE [dbo].[LopendAbonnement]  WITH CHECK ADD  CONSTRAINT [FK_LopendAbonnement_Abonnement] FOREIGN KEY([abonnementID])
REFERENCES [dbo].[Abonnement] ([abonnementID])
ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[LopendAbonnement] CHECK CONSTRAINT [FK_LopendAbonnement_Abonnement]
GO
ALTER TABLE [dbo].[LopendAbonnement]  WITH CHECK ADD  CONSTRAINT [FK_LopendAbonnement_Gebruiker] FOREIGN KEY([gebruikerID])
REFERENCES [dbo].[Gebruiker] ([gebruikerID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[LopendAbonnement] CHECK CONSTRAINT [FK_LopendAbonnement_Gebruiker]
GO
ALTER TABLE [dbo].[Ondertiteling]  WITH CHECK ADD  CONSTRAINT [FK_Ondertiteling_Aflevering] FOREIGN KEY([afleveringID])
REFERENCES [dbo].[Aflevering] ([afleveringID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Ondertiteling] CHECK CONSTRAINT [FK_Ondertiteling_Aflevering]
GO
ALTER TABLE [dbo].[Ondertiteling]  WITH CHECK ADD  CONSTRAINT [FK_Ondertiteling_Film] FOREIGN KEY([filmID])
REFERENCES [dbo].[Films] ([filmID])
GO
ALTER TABLE [dbo].[Ondertiteling] CHECK CONSTRAINT [FK_Ondertiteling_Film]
GO
ALTER TABLE [dbo].[Profiel]  WITH CHECK ADD  CONSTRAINT [FK_Profiel_Gebruiker] FOREIGN KEY([gebruikerID])
REFERENCES [dbo].[Gebruiker] ([gebruikerID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Profiel] CHECK CONSTRAINT [FK_Profiel_Gebruiker]
GO
ALTER TABLE [dbo].[Seizoen]  WITH CHECK ADD  CONSTRAINT [FK_Seizoen_Serie] FOREIGN KEY([serieID])
REFERENCES [dbo].[Serie] ([serieID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Seizoen] CHECK CONSTRAINT [FK_Seizoen_Serie]
GO
ALTER TABLE [dbo].[Serie]  WITH CHECK ADD  CONSTRAINT [FK_Serie_Genre] FOREIGN KEY([genreID])
REFERENCES [dbo].[Genres] ([genreID])
GO
ALTER TABLE [dbo].[Serie] CHECK CONSTRAINT [FK_Serie_Genre]
GO
ALTER TABLE [dbo].[SerieGeschiedenis]  WITH CHECK ADD  CONSTRAINT [FK_SerieGeschiedenis_Aflevering] FOREIGN KEY([afleveringID])
REFERENCES [dbo].[Aflevering] ([afleveringID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SerieGeschiedenis] CHECK CONSTRAINT [FK_SerieGeschiedenis_Aflevering]
GO
ALTER TABLE [dbo].[SerieGeschiedenis]  WITH CHECK ADD  CONSTRAINT [FK_SerieGeschiedenis_Profiel] FOREIGN KEY([profielID])
REFERENCES [dbo].[Profiel] ([profielID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SerieGeschiedenis] CHECK CONSTRAINT [FK_SerieGeschiedenis_Profiel]
GO
ALTER TABLE [dbo].[SerieGeschiedenis]  WITH CHECK ADD  CONSTRAINT [FK_serieGeschiedenis_Ondertiteling] FOREIGN KEY([ondertitelingID])
REFERENCES [dbo].[Ondertiteling] ([ondertitelingID])
GO
ALTER TABLE [dbo].[SerieGeschiedenis] CHECK CONSTRAINT [FK_serieGeschiedenis_Ondertiteling]
GO
ALTER TABLE [dbo].[Voorkeur]  WITH CHECK ADD  CONSTRAINT [FK_Voorkeur_Film] FOREIGN KEY([filmID])
REFERENCES [dbo].[Films] ([filmID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Voorkeur] CHECK CONSTRAINT [FK_Voorkeur_Film]
GO
ALTER TABLE [dbo].[Voorkeur]  WITH CHECK ADD  CONSTRAINT [FK_Voorkeur_Genre] FOREIGN KEY([genreID])
REFERENCES [dbo].[Genres] ([genreID])
GO
ALTER TABLE [dbo].[Voorkeur] CHECK CONSTRAINT [FK_Voorkeur_Genre]
GO
ALTER TABLE [dbo].[Voorkeur]  WITH CHECK ADD  CONSTRAINT [FK_Voorkeur_KijkwijzerIndicatie] FOREIGN KEY([kijkwijzerIndicatieID])
REFERENCES [dbo].[KijkwijzerIndicatie] ([kijkwijzerIndicatieID])
ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[Voorkeur] CHECK CONSTRAINT [FK_Voorkeur_KijkwijzerIndicatie]
GO
ALTER TABLE [dbo].[Voorkeur]  WITH CHECK ADD  CONSTRAINT [FK_Voorkeur_Profiel] FOREIGN KEY([profielID])
REFERENCES [dbo].[Profiel] ([profielID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Voorkeur] CHECK CONSTRAINT [FK_Voorkeur_Profiel]
GO
ALTER TABLE [dbo].[Voorkeur]  WITH CHECK ADD  CONSTRAINT [FK_Voorkeur_Serie] FOREIGN KEY([serieID])
REFERENCES [dbo].[Serie] ([serieID])
ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Voorkeur] CHECK CONSTRAINT [FK_Voorkeur_Serie]
GO
USE [master]
GO
ALTER DATABASE [Netflix] SET  READ_WRITE 
GO
USE [Netflix]
insert into Genres (naam, omschrijving) values ('Geen specifiek genre', 'Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.');
insert into Genres (naam, omschrijving) values ('Action', 'Morbi ut odio.');
insert into Genres (naam, omschrijving) values ('Drama', 'Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius. Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi. Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus.');
insert into Genres (naam, omschrijving) values ('Animation|Drama|Fantasy', 'Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque. Quisque porta volutpat erat.');
insert into Genres (naam, omschrijving) values ('Mystery', 'Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi. Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit.');
insert into Genres (naam, omschrijving) values ('Comedy|Mystery', 'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem. Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci.');
insert into Genres (naam, omschrijving) values ('War film', 'Quisque id justo sit amet sapien dignissim vestibulum.');
insert into Genres (naam, omschrijving) values ('Drama|Romance', 'Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti. Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.');
insert into Genres (naam, omschrijving) values ('Horror movie', 'Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy.');
insert into Genres (naam, omschrijving) values ('Children|Comedy|Fantasy|Musical', 'Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat. Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.');
insert into Genres (naam, omschrijving) values ('Action|Adventure|Thriller', 'Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti. Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum.');
insert into Genres (naam, omschrijving) values ('Horror', 'Nunc nisl.');
insert into Genres (naam, omschrijving) values ('Fantasy', 'Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus. Suspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst. Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat. Curabitur gravida nisi at nibh. In hac habitasse platea dictumst.');
insert into Genres (naam, omschrijving) values ('Musical', 'Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.');
insert into Genres (naam, omschrijving) values ('Adventure', 'Mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh. In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.');
insert into Genres (naam, omschrijving) values ('Documentary', 'Suspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst. Maecenas ut massa quis augue luctus tincidunt.');
insert into Genres (naam, omschrijving) values ('Comedy|Romance', 'Mauris sit amet eros. Suspendisse accumsan tortor quis turpis. Sed ante. Vivamus tortor. Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est.');
insert into Genres (naam, omschrijving) values ('Thriller', 'Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus. Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis.');
insert into Genres (naam, omschrijving) values ('Animation', 'Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum.');
insert into Genres (naam, omschrijving) values ('Crime', 'Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim.');
insert into Genres (naam, omschrijving) values ('Sports film', 'Suspendisse potenti. Cras in purus eu magna vulputate luctus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem. Praesent id massa id nisl venenatis lacinia.');
insert into Genres (naam, omschrijving) values ('Detective', 'In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit. Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque. Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.');
insert into Genres (naam, omschrijving) values ('Biographical film', 'In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat.');
insert into Genres (naam, omschrijving) values ('Psychological thriller', 'Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem. Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo.');
insert into Genres (naam, omschrijving) values ('Crime|Mystery|Thriller', 'Pellentesque at nulla. Suspendisse potenti.');
insert into Genres (naam, omschrijving) values ('Action|Comedy|Romance', 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.');
insert into Genres (naam, omschrijving) values ('Adventure|Comedy|Romance', 'Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst.');
insert into Genres (naam, omschrijving) values ('Sci-Fi', 'Phasellus in felis. Donec semper sapien a libero. Nam dui.');
insert into Genres (naam, omschrijving) values ('Romance', 'Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi. Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.');
insert into Genres (naam, omschrijving) values ('Drama|Sci-Fi', 'Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus.');

