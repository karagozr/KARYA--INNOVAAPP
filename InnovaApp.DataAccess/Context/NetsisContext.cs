using InnovaApp.Entities.Models.FideSiparis;
using InnovaApp.Entities.Models.Netsis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaApp.DataAccess.Context
{
    public class NetsisContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("NETSISConnection"));
        }

        public DbQuery<CariBakiyeli> CariBakiyeliListe { get; set; }
        public DbQuery<CariHaraket> CariHaraket { get; set; }
        public DbQuery<CariGrup> CariGrup { get; set; }
        public DbQuery<CariRaporKod1> CariRaporKod1 { get; set; }

        public DbQuery<Cari> Cari { get; set; }

        public DbQuery<CariKart> CariKart { get; set; }

        public DbQuery<StokGrup> StokGrup { get; set; }
        public DbQuery<Stok> Stok { get; set; }
        public DbQuery<DovizKur> DovizKur { get; set; }

        public DbQuery<TeklifBaslik> TeklifBaslik { get; set; }

        public DbQuery<TeklifDetay> TeklifDetay { get; set; }

        public DbQuery<SiparisBaslik> SiparisBaslik { get; set; }

        public DbQuery<SiparisDetay> SiparisDetay { get; set; }

        public DbQuery<SiparisIrsaliyeDurum> SiparisIrsaliyeDurum { get; set; }

        public DbQuery<Irsaliye> Irsaliye { get; set; }

        public DbQuery<FaturaKalem> FaturaKalem { get; set; }

        public DbQuery<StokKarti> StokKarti { get; set; }

        public DbQuery<StokBakiye> StokBakiye { get; set; }

        public DbQuery<StokGrubu> StokGrubu { get; set; }

        public DbQuery<StokKod1> StokKod1 { get; set; }

        public DbQuery<StokKod2> StokKod2 { get; set; }

        public DbQuery<StokKod3> StokKod3 { get; set; }

        public DbQuery<StokKod4> StokKod4 { get; set; }

        public DbQuery<EIrsaliyeSablon> EIrsaliyeSablon { get; set; }





    }
}
