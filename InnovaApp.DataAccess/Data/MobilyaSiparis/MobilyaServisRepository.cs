using Dapper;
using InnovaApp.Entities.Enums;
using InnovaApp.Entities.Models;
using InnovaApp.Entities.Models.Mobilya;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace InnovaApp.DataAccess.Data.MobilyaSiparis
{
    public class MobilyaServisRepository
    {
        private SqlConnection SqlConnectionNetsis()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var Configuration = builder.Build();

            var connStr = Configuration.GetConnectionString("NETSISConnection");


            return new SqlConnection(connStr);
        }

        private SqlConnection SqlConnectionInnova()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var Configuration = builder.Build();

            var connStr = Configuration.GetConnectionString("INNOVAConnection");


            return new SqlConnection(connStr);
        }

        private IDbConnection CreateConnection(DbSec dbSec)
        {
            if (dbSec == DbSec.Innova)
            {
                var conn = SqlConnectionInnova();
                conn.Open();
                return conn;
            }
            else
            {
                var conn = SqlConnectionNetsis();
                conn.Open();
                return conn;
            }
            
        }

        public List<Entities.Models.Mobilya.MobilyaSiparis> GetSiparisListe(DateTime tarih1, DateTime tarih2, string onayDurum, string cariKodu)
        {
            try
            {
                using (var connection = CreateConnection(DbSec.Netsis))
                {
                    var queryString = $"SELECT SIPARIS_NO as SiparisNo,TARIH as Tarih,TESLIM_TARIHI as TeslimTarihi," +
                        $"URETIM_TARIHI as UretimTarihi,CARI_KOD as CariKod,CARI_ISIM as CariAd FROM [INN_VW_MOBILYA_ISEMRI]" +
                        $" WHERE 1 = 1 ";

                    queryString += cariKodu!=""? $"and CARI_KOD like {cariKodu}":"";

                    queryString += tarih1 == Convert.ToDateTime("01-01-0001 00:00:00") ? $"" : $" and SEVK_TARIHI>'{tarih1}'";
                    queryString += tarih2 == Convert.ToDateTime("01-01-0001 00:00:00") ? $"" : $" and SEVK_TARIHI<='{tarih2}'";

                    queryString += $"group by SIPARIS_NO,TARIH,TESLIM_TARIHI,URETIM_TARIHI,CARI_KOD,CARI_ISIM ";
                    var val = connection.Query<Entities.Models.Mobilya.MobilyaSiparis>(queryString).ToList();

                    return val;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
          
        }

        public bool AddStokRecete(string stokKodu, string guid)
        {

            try
            {
                using (var connection = CreateConnection(DbSec.Netsis))
                {
                    var queryString = $"EXEC URETIM17..[INN_PR_MOBILYA_URETIM_ACIKREC_DEKOR] '100 0003', '1', '{guid.ToString()}' ";

                    var val = connection.Query(queryString);

                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

           
        }

        public bool UpdateStokRecete(int Id, string stokKodu)
        {

            try
            {
                using (var connection = CreateConnection(DbSec.Innova))
                {
                    var queryString = $"UPDATE INNOVA.DBO.[TBLURETIM_MOBILYA_ACIKREC]     SET HAM_KODU = '{stokKodu}' WHERE ID = '{Id}'  ";
                    queryString += $"UPDATE INNOVA.DBO.[TBLURETIM_MOBILYA_ACIKREC_TEMP]   SET HAM_KODU = '{stokKodu}' WHERE ID = '{Id}' ";

                    var val = connection.Query(queryString);

                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }


        }

        public List<StokRecete> GetStokRecete(string guid)
        {

            try
            {
                using (var connection = CreateConnection(DbSec.Netsis))
                {
                    var queryString = $"EXEC URETIM17..[INN_PR_MOBILYA_URETIM_ACIKREC_GETIR_DEKOR] '{guid}', '0' ";

                    var val = connection.Query<dynamic>(queryString).ToList();

                    var list = new List<StokRecete>();

                    foreach (var item in val)
                    {
                        list.Add(new StokRecete
                        {
                            DegerAciklama = item.DEGER_ACIKLAMA,
                            HamKodu = item.HAM_KODU,
                            MamulAdi = item.MAMUL_ADI,
                            Miktar = item.MIKTAR,
                            OzellikAciklama = item.OZELLIK_ACIKLAMA,
                            OzellikId = item.OZELLIK_ID,
                            StokAdi = item.STOK_ADI
                        });
                    }

                    return list;
                }
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        public void SiparisKaydet(List<BelgeKayit> belgeler)
        {
            using (var context = CreateConnection(DbSec.Innova))
            {
                foreach (var belgeKayit in belgeler)
                {
                    
                }
                    /*
                    select *, ID as Id,GUIDID as [Guid], SIRA as Sira,SUBE_KODU as Sube ,BELGE_NO as BelgeNo, TARIH as Tarih, 
                    STOK_KODU as StokKodu, STOK_ADI as StokAdi, BIRIM as Birim, MIKTAR as Miktar, ACIKLAMA as Aciklama
                    from TBLBELGE_KAYIT
                    */

            }

        }
    }
}
