--restore backups, verander de  path naar het gewenste path op regel 4, 10, 15 en 26
--full----------------------------------------------------------------------------
RESTORE DATABASE Netflix 
FROM DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.STORM\MSSQL\Backup\Netflix_FULL.BAK'
GO

--differential--------------------------------------------------------------------
--eerst een full backup
RESTORE DATABASE Netflix 
FROM DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.STORM\MSSQL\Backup\Netflix_INIT.BAK'
   WITH NORECOVERY;  
GO  
--dan de differential
--Als er meerdere differentail backups zijn, zal de nieuwste backup moeten worde geselecteerd op regel 17:
--  'file = X' met X als het nummer van de nieuwste backup.
RESTORE DATABASE Netflix 
FROM DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.STORM\MSSQL\Backup\Netflix_DIFF.BAK'
   WITH RECOVERY, file = 1;  
GO  

--incremental---------------------------------------------------------------------
-- In SQL server is het niet mogelijk om een incremental backup te maken, en dus kan het ook niet gerestored worden.
-- Zie deze website; https://www.itprotoday.com/sql-server/does-sql-server-have-incremental-data-backups
-- Het dichtsbijzijnde alternatief is om eens in de zoveel tijd een transaction log backup te maken, om vervolgens te restoren.
-- Hoe een transaction log backup gerestored moet worden is hieronder te zien
--transaction log-----------------------------------------------------------------
RESTORE LOG Netflix 
FROM DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.STORM\MSSQL\Backup\Netflix_LOG.BAK'
GO

--Een transaction-----------------------------------------------------------------
--We hebben een stored procedure voor het afsluiten van een nieuw abonnement gecreëerd.
--In deze procedure wordt de transaction gemaakt en netjes met een try catch afgehandeld
CREATE PROCEDURE NieuwLopendAbonnement (
    @gebruikerID int, 
    @abonnementID int, 
    @aankoopDatum datetime
)
AS
BEGIN

BEGIN TRANSACTION [NieuwLopendAbonnement]
  BEGIN TRY
      INSERT INTO LopendAbonnement(gebruikerID, abonnementID, aankoopDatum)
      VALUES (@gebruikerID, @abonnementID, @aankoopDatum)
      COMMIT TRANSACTION [NieuwLopendAbonnement]
  END TRY
  BEGIN CATCH
      ROLLBACK TRANSACTION [NieuwLopendAbonnement]
  END CATCH  

END
GO
