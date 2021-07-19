USE [master]
-- create de logins
CREATE LOGIN [Adam Verogue] WITH PASSWORD=N'Adam123', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
CREATE LOGIN [Matt Smith] WITH PASSWORD=N'Matt123', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
CREATE LOGIN [Mick Worry] WITH PASSWORD=N'Mick123', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
CREATE LOGIN [NetflixApplication] WITH PASSWORD=N'Netflix123', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
CREATE LOGIN [Tim Snapps] WITH PASSWORD=N'Tim123', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO

USE [Netflix]
--create de users
CREATE USER [Adam Verogue] FOR LOGIN [Adam Verogue]
CREATE USER [Matt Smith] FOR LOGIN [Matt Smith]
CREATE USER [Mick Worry] FOR LOGIN [Mick Worry]
CREATE USER [NetflixApplication] FOR LOGIN [NetflixApplication]
CREATE USER [Tim Snapps] FOR LOGIN [Tim Snapps]

--create de role's en geef rechten
CREATE ROLE [Hoofd Data-analist]
ALTER ROLE [Hoofd Data-analist] ADD MEMBER [Matt Smith]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[Kijkwijzer] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[SerieGeschiedenis] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[Genre] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[Serie] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[FilmGeschiedenis] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[Aflevering] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[LopendAbonnement] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[Seizoen] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[Gebruiker] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[KijkwijzerIndicatie] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[Ondertiteling] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[Profiel] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[Film] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[Abonnement] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[KijkLijst] TO [Hoofd Data-analist]
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[Voorkeur] TO [Hoofd Data-analist]

CREATE ROLE [Data-analist]
ALTER ROLE [Data-analist] ADD MEMBER [Adam Verogue]
ALTER ROLE [Data-analist] ADD MEMBER [Mick Worry]
GRANT SELECT ON [dbo].[Kijkwijzer] TO [Data-analist]
GRANT SELECT ON [dbo].[SerieGeschiedenis] TO [Data-analist]
GRANT SELECT ON [dbo].[Genre] TO [Data-analist]
GRANT SELECT ON [dbo].[Serie] TO [Data-analist]
GRANT SELECT ON [dbo].[FilmGeschiedenis] TO [Data-analist]
GRANT SELECT ON [dbo].[Aflevering] TO [Data-analist]
GRANT SELECT ON [dbo].[LopendAbonnement] TO [Data-analist]
GRANT SELECT ON [dbo].[Seizoen] TO [Data-analist]
GRANT SELECT ON [dbo].[Gebruiker] TO [Data-analist]
GRANT SELECT ON [dbo].[KijkwijzerIndicatie] TO [Data-analist]
GRANT SELECT ON [dbo].[Ondertiteling] TO [Data-analist]
GRANT SELECT ON [dbo].[Profiel] TO [Data-analist]
GRANT SELECT ON [dbo].[Film] TO [Data-analist]
GRANT SELECT ON [dbo].[Abonnement] TO [Data-analist]
GRANT SELECT ON [dbo].[KijkLijst] TO [Data-analist]
GRANT SELECT ON [dbo].[Voorkeur] TO [Data-analist]

CREATE ROLE [Junior Data-analist]
ALTER ROLE [Junior Data-analist] ADD MEMBER [Tim Snapps]
GRANT SELECT ON [dbo].[Kijkwijzer] TO [Junior Data-analist]
GRANT SELECT ON [dbo].[Genre] TO [Junior Data-analist]
GRANT SELECT ON [dbo].[Serie] TO [Junior Data-analist]
GRANT SELECT ON [dbo].[Aflevering] TO [Junior Data-analist]
GRANT SELECT ON [dbo].[Seizoen] TO [Junior Data-analist]
GRANT SELECT ON [dbo].[KijkwijzerIndicatie] TO [Junior Data-analist]
GRANT SELECT ON [dbo].[Ondertiteling] TO [Junior Data-analist]
GRANT SELECT ON [dbo].[Film] TO [Junior Data-analist]
GRANT SELECT ON [dbo].[Abonnement] TO [Junior Data-analist]

CREATE ROLE [Application]
ALTER ROLE [Application] ADD MEMBER [NetflixApplication]
GO