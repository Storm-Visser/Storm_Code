--Create index
CREATE INDEX genre_name
ON Genre (naam);

CREATE INDEX Abonnement_type
ON Abonnement (naam, bedrag);

CREATE INDEX Kijkwijzer_Mogelijkheden
ON KijkwijzerIndicatie (omschrijving);

--Constraints
ALTER TABLE Genre
ADD CONSTRAINT uniekeGenreNaam UNIQUE (naam);

ALTER TABLE KijkwijzerIndicatie
ADD CONSTRAINT uniekeKijkwijzerIndicatieOmschrijving UNIQUE (omschrijving);

ALTER TABLE Gebruiker
ADD CONSTRAINT uniekeGebruikerEmail UNIQUE (email);

ALTER TABLE Abonnement
ADD CONSTRAINT uniekeAbonnementNaam UNIQUE (naam);

ALTER TABLE Gebruiker
ADD CONSTRAINT CheckGebruikerEmail CHECK (email LIKE '%_@__%.__%');
GO
--Views, Stored Procedures en Triggers
--Views---------------------------------------------------------------------------------------------------------

CREATE VIEW TienMeestBekekenFilmsEnSeries AS
SELECT TOP 10 naam
FROM(
        SELECT F.naam, COUNT(FG.filmID) as hoeveelheid
		FROM FilmGeschiedenis as FG
        JOIN Film as F
        ON FG.filmID = F.filmID
		GROUP BY F.naam
		UNION ALL
		SELECT S.naam, COUNT(S.naam) as hoeveelheid
        FROM SerieGeschiedenis as SG
        JOIN Aflevering as A
        ON A.afleveringID = SG.afleveringID
        JOIN Seizoen as SZ
        ON A.seizoenID = SZ.seizoenID
        JOIN Serie as S
        ON SZ.serieID = S.serieID
        GROUP BY S.naam
    ) as MeestBekeken
ORDER BY hoeveelheid DESC;
GO

CREATE VIEW TienMeestBekekenGenres AS
SELECT TOP 10 naam
FROM(
        SELECT G.naam, COUNT(FG.filmID) as hoeveelheid 
        FROM FilmGeschiedenis as FG
        JOIN Film as F
        ON FG.filmID = F.filmID
        JOIN Genre as G
        ON F.genreID = G.genreID
        GROUP BY G.naam
        UNION ALL
        SELECT G.naam, COUNT(SG.afleveringID) as hoeveelheid 
        FROM SerieGeschiedenis as SG
        JOIN Aflevering as A
        ON A.afleveringID = SG.afleveringID
        JOIN Seizoen as SZ
        ON A.seizoenID = SZ.seizoenID
        JOIN Serie as S
        ON SZ.serieID = S.serieID
        JOIN Genre as G
        ON S.genreID = G.genreID
        GROUP BY G.naam
    )   as GenreGeschiedenis 
ORDER BY hoeveelheid DESC;
GO
--stored procedures-------------------------------------------------------------------------------------------
-- voeg een film toe
CREATE PROCEDURE FilmToevoegen (
    @genreID int,
    @naam varchar(100), 
    @filmLocatie varchar(255), 
    @omschrijving varchar(255), 
    @tijdsDuur time(7), 
    @resolutie varchar(20)
)
AS
BEGIN

INSERT INTO Film (genreID, naam, filmLocatie, omschrijving, tijdsDuur, resolutie)
VALUES (@genreID, @naam, @filmLocatie, @omschrijving, @tijdsDuur, @resolutie);

END
GO

--voeg een aflevering toe
CREATE PROCEDURE AfleveringToevoegen (
    @seizoenID int,
    @nummer int, 
    @naam varchar(100), 
    @afleveringLocatie varchar(255), 
    @omschrijving varchar(255), 
    @tijdsDuur time(7), 
    @resolutie varchar(20)
)
AS
BEGIN

INSERT INTO Aflevering (seizoenID, nummer, naam, afleveringLocatie, omschrijving, tijdsDuur, resolutie)
VALUES (@seizoenID, @nummer, @naam, @afleveringLocatie, @omschrijving, @tijdsDuur, @resolutie);

END
GO

--voeg een gebruiker toe
CREATE PROCEDURE GebruikerToevoegen (
    @email varchar(100),
    @wachtwoord varchar(255), 
    @geactiveerd bit, 
    @aantalInlogPogingen int, 
    @aanmaakDatum datetime, 
    @krijgtKorting bit, 
    @isUitgenodigd bit
)
AS
BEGIN

INSERT INTO Gebruiker (email, wachtwoord, geactiveerd, aantalInlogPogingen, aanmaakDatum, krijgtKorting, isUitgenodigd)
VALUES (@email, @wachtwoord, @geactiveerd, @aantalInlogPogingen, @aanmaakDatum, @krijgtKorting, @isUitgenodigd);

END
GO

--voeg een profiel toe
CREATE PROCEDURE ProfielToevoegen (
    @gebruikerID int,
    @naam varchar(50), 
    @fotoLocatie varchar(255), 
    @geboorteDatum datetime, 
    @taal varchar(20)
)
AS
BEGIN

INSERT INTO Profiel (gebruikerID, naam, fotoLocatie, geboorteDatum, taal)
VALUES (@gebruikerID, @naam, @fotoLocatie, @geboorteDatum, @taal);

END
GO

--Triggers--------------------------------------------------------------------------------------------------------------
--blokkeer een gebruiker na 3 inlogpogingen
CREATE TRIGGER blokkeer_gebruiker
ON Gebruiker
FOR UPDATE
AS
UPDATE Gebruiker SET geactiveerd = 0
WHERE aantalInlogPogingen >= 3
GO
--een gebruiker mag niet meer dan 4 profielen
CREATE TRIGGER teveel_profielen
ON Profiel
FOR INSERT
AS
DELETE FROM Profiel
WHERE profielID IN (
    SELECT TOP 1 P.profielID
    FROM (
        SELECT gebruikerID, COUNT(*) as amount
        FROM Profiel
        GROUP BY gebruikerID
        ) as amount
	JOIN Profiel as P
	ON amount.gebruikerID = P.gebruikerID
    WHERE amount.amount > 4
    ORDER BY P.profielID DESC
	)
GO


--Referentiële integriteit
-- De referentiele integriteit hebben zij verwerkt en we hebben de volgende aanpassingen gedaan:
--      ON DELETE cascade op gebruiker, profiel, serie, seizoen, aflevering en film
--      ON DELETE set null op ondertiteling
--      ON DELETE set default null genre
--      ON DELETE no action op kijkwijzerindicatie en abonnement
--      ON UPDATE cascade op genre, ondertiteling, gebruiker, profiel, serie, seizoen, aflevering en film
--      ON UPDATE no action op kijkwijzerindicatie en abonnement
-- deze aanpassingen zijn te zien in het bestand van week 2 genaamd "week2-1.sql" van regel 358 tot regel 513