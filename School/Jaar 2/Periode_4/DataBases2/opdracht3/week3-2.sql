--1. hoeveel gebruikers Netflix telt

SELECT COUNT(gebruikerID) AS 'Totaal aantal gebruikers' FROM Gebruiker

GO
--2. hoeveel profielen Netflix heeft

SELECT COUNT(profielID) AS 'Totaal aantal profielen' FROM Profiel

GO
--3. hoeveel abonnementen er zijn

SELECT COUNT(abonnementID) AS 'Totaal aantal lopende abonnementen' FROM LopendAbonnement
SELECT COUNT(abonnementID) AS 'Totaal aantal abonnementen' FROM Abonnement

GO
--4. hoeveel films er zijn

SELECT COUNT(filmID) AS 'Totaal aantal films' FROM Film

GO
--5. wat de gemiddelde leeftijd van de gebruikers is

SELECT AVG(DATEDIFF(yy,CONVERT(DATETIME, geboortedatum),GETDATE())) AS 'Gemiddelde leeftijd' FROM profiel

GO
--6. hoe oud alle gebruikers samen zijn

SELECT SUM(DATEDIFF(yy,CONVERT(DATETIME, geboortedatum),GETDATE())) AS 'Gemiddelde leeftijd' FROM profiel

GO
--7. hoeveel verschillende ondertitels er gebruikt zijn

SELECT COUNT(ondertitelingID) AS 'Aantal ondertitels' FROM Ondertiteling

GO
--8. hoeveel mensen er zijn uitgenodigd

SELECT COUNT(gebruikerID) AS 'Aantal uitgenodigde mensen' FROM Gebruiker WHERE isUitgenodigd = 1

GO
--9. hoeveel items er zijn die gebruikers nog willen bekijken

SELECT COUNT(kijklijstID) AS "Aantal items nog te kijken" FROM Kijklijst

GO
--10. welke voorkeuren ik kan instellen als gebruiker

SELECT naam, 'Film' as TableName
FROM Film
UNION SELECT naam, 'Serie' as TableName 
FROM Serie
UNION SELECT naam, 'Genre' as TableName
FROM Genre
UNION SELECT omschrijving , 'Kijkwijzer Indicatie' as TableName
FROM KijkwijzerIndicatie
ORDER BY TableName

GO
--11. hoeveel mensen een abonnement hebben

SELECT COUNT(DISTINCT gebruikerID) AS 'Mensen met een abonnement' FROM LopendAbonnement 
GO
--12. hoeveel mensen er gratis kijken

SELECT COUNT(gebruikerID) AS 'Mensen die gratis kijken' FROM Gebruiker WHERE DATEDIFF(dd, aanmaakDatum, GETDATE()) < 8

GO
--13. hoeveel minuten er totaal gekeken is

SELECT SUM(DATEDIFF(MINUTE, '0:00:00', FG.tijd)) + SUM(DATEDIFF(MINUTE, '0:00:00', SG.tijd)) AS 'Totaal aantal gekeken minuten'
FROM Profiel as P
JOIN FilmGeschiedenis as FG
ON P.profielID = FG.profielID
JOIN SerieGeschiedenis as SG
ON P.profielID = SG.profielID

GO

--14. hoevaak er nederlandse ondertiteling is gebruikt

SELECT COUNT(FG.ondertitelingID) + 
    (SELECT COUNT(SG.ondertitelingID)
    FROM SerieGeschiedenis as SG
    JOIN Ondertiteling as O
    ON SG.ondertitelingID = O.ondertitelingID
    WHERE O.taal = 'Dutch')
AS 'Aantal keren nederlands ondertiteld'
FROM FilmGeschiedenis as FG
JOIN Ondertiteling as O
ON FG.ondertitelingID = O.ondertitelingID
WHERE O.taal = 'Dutch'

GO
--15. hoevaak er geen ondertiteling is gebruikt

SELECT COUNT(filmGeschiedenisID) + 
    (SELECT COUNT(serieGeschiedenisID)
    FROM SerieGeschiedenis
    WHERE ondertitelingID IS NULL)
AS 'Aantal keren zonder ondertiteling'
FROM FilmGeschiedenis
WHERE ondertitelingID IS NULL

GO
--16. welke gebruikers meer dan 4 profielen hebben

SELECT gebruikerID, amount as 'aantal profielen'
FROM (
	SELECT gebruikerID, COUNT(*) as amount
	FROM Profiel
	GROUP BY gebruikerID
	) as amount
WHERE amount > 4
ORDER BY amount DESC

GO
--17. welke gebruikers de film "Stenden" hebben gezien

SELECT P.naam AS 'Profielen die de film "Stenden" hebben gezien'
FROM Profiel as P
JOIN FilmGeschiedenis as FG
ON P.profielID = FG.profielID
JOIN Film as F
ON FG.filmID = F.filmID
WHERE F.naam = 'Stenden'

GO
--18. hoeveel gebruikers horror als voorkeur hebben

SELECT P.naam AS 'Profielen met Horror als voorkeur'
FROM Voorkeur as V
JOIN Profiel as P
ON V.profielID = P.profielID
JOIN Genre as G 
ON V.genreID = G.genreID
WHERE G.naam = 'Horror'

GO
--19. welke gebruikers nog geen voorkeuren hebben

SELECT naam AS 'Profielen zonder voorkeur'
FROM Profiel
WHERE profielID NOT IN (SELECT profielID FROM Voorkeur)

GO
--20. welke gebruikers nog niet geactiveerd zijn

SELECT gebruikerID AS 'Niet geactiveerde gebruikers' FROM Gebruiker WHERE geactiveerd = 0

GO
--21. hoeveel euro per maand er verdient wordt

SELECT SUM(A.bedrag) AS 'Opbrengst per maand'
FROM LopendAbonnement as LA
JOIN Abonnement AS A
ON LA.abonnementID = A.abonnementID
WHERE DATEDIFF(MM, LA.aankoopDatum, GETDATE()) <= 1

GO
--22. hoeveel euro per maand extra verdient kan worden wanneer alle gebruikers zonder abonnement een UHD abonnement zouden afsluiten

SELECT COUNT(gebruikerID) * 13.99
FROM Gebruiker as G
WHERE G.gebruikerID NOT IN 
    (SELECT gebruikerID 
    FROM LopendAbonnement
    WHERE DATEDIFF(mm, aankoopDatum, GETDATE()) <= 1)

GO
--23. welke gebruikers een film hebben gekeken met Engelse ondertiteling

SELECT P.naam AS 'Profielen die engelse ondertiteling hebben gebruikt' 
FROM Ondertiteling as O
JOIN FilmGeschiedenis as FG
ON O.ondertitelingID = FG.ondertitelingID
JOIN Profiel as P
ON FG.profielID = P.profielID
WHERE O.taal = 'English'

GO
--24. welke gebruikers zonder UHD-abonnement een UHD-film hebben gekeken

SELECT P.naam AS 'Profielen een UHD film hebben gezien en nu geen UHD abonnement hebben'
FROM Profiel as P
JOIN FilmGeschiedenis as FG
ON P.profielID = FG.profielID
JOIN Film as F
ON FG.filmID = F.filmID
WHERE F.resolutie = 'UHD'

GO
--25. wat het percentage is per ondertitel dat gebruikt is om films te kijken

SELECT O.taal AS 'ondertiteling', CONCAT(100 /
(
	SELECT COUNT(filmGeschiedenisID)
	FROM FilmGeschiedenis
	WHERE ondertitelingID IS NOT NULL
)
* COUNT(*), '%') AS 'percentage'
FROM FilmGeschiedenis as F
JOIN Ondertiteling as O
ON F.ondertitelingID = O.ondertitelingID
GROUP BY O.taal

GO
--26. Wat de meest gebruikte ondertiteling is per user met uitzondering van moedertaal

SELECT PP.naam, (
	SELECT TOP 1 O.taal
    FROM (
		SELECT SG.ondertitelingID, SG.profielID
		FROM SerieGeschiedenis as SG
		UNION ALL
		SELECT FG.ondertitelingID, FG.profielID
		FROM FilmGeschiedenis as FG
	)as OG
    JOIN Profiel as P
    ON OG.profielID = P.profielID
    JOIN Ondertiteling as O
    ON OG.ondertitelingID = O.ondertitelingID
    WHERE O.taal != P.taal AND P.naam = PP.naam
	GROUP BY O.taal
    ORDER BY COUNT(*) DESC
	) as 'meest bekeken ondertiteling'
FROM Profiel as PP

GO
--27. Of de meest gekeken genre van één specifieke user ook in zijn voorkeur genre lijst voorkomt

SELECT IIF(
    (SELECT TOP 1 F.genreID 
    FROM FilmGeschiedenis as FG
    JOIN Film as F
    ON FG.filmID = F.filmID
    WHERE FG.profielID = 1
    GROUP BY F.genreID
    ORDER BY COUNT(*) DESC
    ) IN (
    SELECT genreID 
    FROM Voorkeur 
    WHERE profielID = 1
    ), 'Ja, de meest bekeken genre staat in de voorkeuren', 'Nee, de meest bekeken genre staat niet in de voorkeuren')
AS "Staat het meest bekeken genre in de lijst van voorkeuren"
GO

--28. Welke van de volgende genres worden het meest bekeken op valentijnsdag? Geef een lijst van groot naar klein: Romantische Komedies, Actie, Horror, Sci-fi en Anime.

SELECT G.naam, COUNT(GenreGeschiedenis.genreID) as 'hoeveelheid'
FROM (
	SELECT G.GenreID, FG.kijkDatum FROM FilmGeschiedenis as FG
	JOIN Film as F
	ON FG.filmID = F.filmID
	JOIN Genre as G
	ON F.genreID = G.genreID
	UNION ALL
	SELECT G.GenreID, SG.kijkDatum FROM SerieGeschiedenis as SG
	JOIN Aflevering as A
	ON A.afleveringID = SG.afleveringID
	JOIN Seizoen as SZ
	ON A.seizoenID = SZ.seizoenID
	JOIN Serie as S
	ON SZ.serieID = S.serieID
	JOIN Genre as G
	ON S.genreID = G.genreID
) as GenreGeschiedenis

JOIN Genre as G
ON GenreGeschiedenis.genreID = G.genreID
WHERE G.naam = 'Comedy|Romance' OR G.naam = 'Horror' OR G.naam = 'Action' OR G.naam = 'Sci-Fi' OR G.naam = 'Animation' AND GenreGeschiedenis.kijkDatum LIKE '14/02/____'
GROUP BY G.naam
ORDER BY COUNT(G.naam) DESC

GO