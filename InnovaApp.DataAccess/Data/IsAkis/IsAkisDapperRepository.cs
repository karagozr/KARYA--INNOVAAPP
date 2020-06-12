using Dapper;
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

namespace InnovaApp.DataAccess.Data.IsAkis
{
    public class IsAkisDapperRepository
    {
        private SqlConnection SqlConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var Configuration = builder.Build();

            var connStr = Configuration.GetConnectionString("INNOVAConnection");


            return new SqlConnection(connStr);
        }

        private IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }

        public List<IsAkisDetay> IsAkisDetayGor(int akisId,int akisKayitId)
        {
            var columnList = (typeof(IsAkisDetay).GetProperties()).Select(x => x.GetCustomAttribute<ColumnAttribute>()?.Name + " " + x.Name).ToList();

            using (var connection = CreateConnection())
            {


                var queryString = $"SELECT LG.AKIS_ID, LG.SIRA, LG.KULLANICI, KULLANICI_ADI, LG.KAYIT_TARIHI, DURUM FROM INNOVA..INN_VW_ISAKIS_SURECI_ODEME_EMRI_LOG LG" +
                    $" WHERE BELGE_NO = 904 AND AKIS_KAYIT_ID = 190 " +
                    $" UNION ALL" +
                    $" SELECT AKIS_ID, SIRA, SR.KULLANICI, KL.KULLANICI KULLANICI_ADI, NULL, 'S' AS DURUM FROM INNOVA..TBLISAKISSIRA SR" +
                    $" INNER JOIN INNOVA..TBLKULLANICI KL ON SR.KULLANICI = KL.ID" +
                    $" WHERE AKIS_ID = 1 AND SR.KULLANICI NOT IN(SELECT AK.KULLANICI FROM INNOVA..TBLISAKIS AK WHERE AK.AKIS_ID = {akisId} AND AK.AKIS_KAYIT_ID = {akisKayitId})";

                return connection.Query<IsAkisDetay>(queryString).ToList();
            }
        }
    }
}
