--create backups, verander de path naar het gewenste path op regel 4, 11, 18 en 30
--full----------------------------------------------------------------------------
BACKUP DATABASE Netflix 
TO DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.STORM\MSSQL\Backup\Netflix_FULL.BAK'
    WITH FORMAT,
    MEDIANAME = 'SQLServerBackups',
    NAME = 'Full Backup of Netflix Database';
--differential--------------------------------------------------------------------
--eerst een full backup
BACKUP DATABASE Netflix 
TO DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.STORM\MSSQL\Backup\Netflix_INIT.BAK'
    WITH INIT,
    MEDIANAME = 'SQLServerBackups',
    NAME = 'Full Backup of Netflix Database, to start the differential backups';
GO 
-- dan een differential
BACKUP DATABASE Netflix 
TO DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.STORM\MSSQL\Backup\Netflix_DIFF.BAK'
    WITH DIFFERENTIAL,
    MEDIANAME = 'SQLServerBackups',
    NAME = 'Differential Backup of Netflix Database';
GO 
--incremental---------------------------------------------------------------------
-- In SQL server is het niet mogelijk om een incremental backup te maken.
-- Zie deze website; https://www.itprotoday.com/sql-server/does-sql-server-have-incremental-data-backups
-- Het dichtsbijzijnde alternatief is om eens in de zoveel tijd een transaction log backup te maken.
-- Hoe een transaction log backup gemaakt moet worden is hieronder te zien
--transaction log-----------------------------------------------------------------
BACKUP LOG Netflix  
TO DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.STORM\MSSQL\Backup\Netflix_LOG.BAK'
    WITH INIT,
    MEDIANAME = 'SQLServerBackups',
    NAME = 'Full Backup from Netflix Database Transaction log';
GO
