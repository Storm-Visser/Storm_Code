--Conncurency probleem--------------------------------------------------------------------------
-- Dit zorgt dat de kans op concurrency problemen zo klein mogelijk is.
-- We hebben gekozen om de gehele database Serializable te maken, omdat dit zorgt dat de kans op conncurency het kleinst is.
-- Dit betekend dat de database langzaamer wordt, maar we hebben dit gekozen omdat de opdracht zegt dat het zo klein mogelijk moet zijn.
USE Netflix;  
GO  
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;  
GO
--Twee transactions-------------------------------------------------------------------------------
--We hebben deze transactions ook weer in een stored procedure gezet.
--In deze procedures wordt de transaction gemaakt en netjes met een try catch afgehandeld
-- gebruiker toevoegen
ALTER PROCEDURE GebruikerToevoegen (
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

BEGIN TRANSACTION [GebruikerToevoegen]
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
    BEGIN TRY
        INSERT INTO Gebruiker (email, wachtwoord, geactiveerd, aantalInlogPogingen, aanmaakDatum, krijgtKorting, isUitgenodigd)
        VALUES (@email, @wachtwoord, @geactiveerd, @aantalInlogPogingen, @aanmaakDatum, @krijgtKorting, @isUitgenodigd);
        COMMIT TRANSACTION [GebruikerToevoegen]
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION [GebruikerToevoegen]
    END CATCH  

END
GO


-- de opbrengst van het afgelopen jaar
CREATE PROCEDURE OpbrengstAfgelopenJaar
AS
BEGIN

BEGIN TRANSACTION [OpbrengstAfgelopenJaar]
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
    BEGIN TRY
        SELECT SUM(A.bedrag) AS 'Opbrengst afgelopen jaar'
        FROM LopendAbonnement as LA
        JOIN Abonnement AS A
        ON LA.abonnementID = A.abonnementID
        WHERE DATEDIFF(MM, LA.aankoopDatum, GETDATE()) <= 12
        COMMIT TRANSACTION [OpbrengstAfgelopenJaar]
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION [OpbrengstAfgelopenJaar]
    END CATCH  

END
GO