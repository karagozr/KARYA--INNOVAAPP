using Dapper;
using InnovaApp.Entities.Dtos.Netsis;
using InnovaApp.Entities.Models.IsAkis;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace InnovaApp.DataAccess.Data.Netsis
{
    public class StokDapperRepository
    {
        private SqlConnection SqlConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var Configuration = builder.Build();

            var connStr = Configuration.GetConnectionString("NETSISConnection");


            return new SqlConnection(connStr);
        }

        private IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }

        public List<StokKartiBakiyeli> StokBakiyeliListe(string stokKodu, string stokAdi, string grup, string kod1, string kod2, string kod3, string kod4)
        {
            

            using (var connection = CreateConnection())
            {


                var queryString = $" select TOP 200 S.STOK_KODU as StokKodu,STOK_ADI as StokAdi, OLCU_BR1 as OlcuBr,(ISNULL(B.TOP_GIRIS_MIK,0)-ISNULL(B.TOP_CIKIS_MIK,0)) as Miktar, " +
                                  $"S.DOV_SATIS_FIAT as SatisFiyat, " +
                                  $"case when s.SAT_DOV_TIP=0 then 'TL' " +
                                  $"when s.SAT_DOV_TIP=1 then 'USD' " +
                                  $"when s.SAT_DOV_TIP=2 then 'EUR' " +
                                  $"when s.SAT_DOV_TIP=3 then 'GBP' " +
                                  $"else 'DİĞER' end as SatisDoviz " +
                                  $"from TBLSTSABIT as S"+
                                  $" left join TBLSTOKPH as B on S.STOK_KODU = B.STOK_KODU" +
                                  $" WHERE 1=1 and S.DEPO_KODU=1 " ;

                var filtreStr = "";
                if (!string.IsNullOrEmpty(stokKodu)) filtreStr  += $" and S.STOK_KODU like '{stokKodu}%'";
                if (!string.IsNullOrEmpty(stokAdi)) filtreStr   += $" and (STOK_ADI like '%{stokAdi}%' or BARKOD1 like '%{stokAdi}%' or BARKOD2 like '%{stokAdi}%')";
                if (!string.IsNullOrEmpty(grup)) filtreStr      += $" and GRUP_KODU ='{grup}'";
                if (!string.IsNullOrEmpty(kod1)) filtreStr      += $" and KOD_1 ='{kod1}'";
                if (!string.IsNullOrEmpty(kod2)) filtreStr      += $" and KOD_2 ='{kod2}'";
                if (!string.IsNullOrEmpty(kod3)) filtreStr      += $" and KOD_3 ='{kod3}'"; 
                if (!string.IsNullOrEmpty(kod4)) filtreStr      += $" and KOD_4 ='{kod4}'";

                queryString += filtreStr;

                return connection.Query<StokKartiBakiyeli>(queryString).ToList();
            }
        }

        
    }
}
