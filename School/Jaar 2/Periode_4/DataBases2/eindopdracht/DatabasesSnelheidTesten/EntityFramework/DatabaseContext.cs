using System;
using System.Collections.Generic;
using System.Data.Entity;
using DatabasesSnelheidTesten.EntityFramework.Model;

namespace DatabasesSnelheidTesten.EntityFramework
{
    class DatabaseContext : DbContext
    {
        public virtual DbSet<Abonnement> Abonnementen { get; set; }
        public virtual DbSet<Aflevering> Afleveringen { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmGeschiedenis> FilmGeschiedenisen { get; set; }
        public virtual DbSet<Gebruiker> Gebruikers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Kijkwijzer> Kijkwijzers { get; set; }
        public virtual DbSet<KijkwijzerIndicatie> KijkwijzerIndicaties { get; set; }
        public virtual DbSet<LopendAbonnement> LopendeAbbonementen { get; set; }
        public virtual DbSet<Ondertiteling> Ondertitelingen { get; set; }
        public virtual DbSet<Profiel> Profielen { get; set; }
        public virtual DbSet<Seizoen> Seizoenen { get; set; }
        public virtual DbSet<SerieGeschiedenis> SerieGeschiedenisen { get; set; }
        public virtual DbSet<Voorkeur> Voorkeuren { get; set; }

        public DatabaseContext() : base("connectionName")
        {
            Database.SetInitializer(
                new DropCreateDatabaseAlways<DatabaseContext>()
            );
        }
    }
}
