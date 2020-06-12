using InnovaApp.Entities.Models.FideSiparis.Innova;
using InnovaApp.Entities.Models;
using InnovaApp.Entities.Models.OgrenciServis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using InnovaApp.Entities.Models.IsAkis;

namespace InnovaApp.DataAccess.Context
{
    public class InnovaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("INNOVAConnection"));

            //optionsBuilder.UseSqlServer("data source =KARAGOZPC; initial catalog = INNOVA; integrated security = True; MultipleActiveResultSets = True"/*"Persist Security Info=True;Data Source=KARGISRV;Initial Catalog=INNOVA;User ID=sa;Password=InnovaSql!."*/);
            //optionsBuilder.UseSqlServer("Persist Security Info = True; Data Source = KARGISRV; Initial Catalog = INNOVA; User ID = sa; Password = InnovaSql!.");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TahakkukDetay>().Property(m => m.TahakkukGuid).(DatabaseGeneratedOption.Identity);
        //}
        double w = 23.5;

        public DbSet<Entities.Models.BelgeKayit> TalepKayit { get; set; }

        public DbSet<Parametreler> Parametreler { get; set; }

        public DbSet<InnovaApp.Entities.Models.FideSiparis.Innova.BelgeKayit> BelgeKayit { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<UserYetki> UserYetki { get; set; }

        public DbSet<IsAkis> IsAkis { get; set; }

        public DbSet<IsAkisEmir> IsAkisEmir { get; set; }

        #region
        //public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Ogrenci> Ogrenci { get; set; }
        public DbSet<OgrenciBolge> OgrenciBolge { get; set; }
        public DbSet<Okul> Okul { get; set; }

        public DbSet<Tahakkuk> Tahakkuk { get; set; }

        public DbSet<TahakkukDetay> TahakkukDetay { get; set; }
        #endregion

    }
}
