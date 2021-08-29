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


namespace InnovaApp.DataAccess.Data
{
    public class NetsisDapperRepository
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

        public string GetSonIrsaliyeNo(string tip, string seri)
        {

            using (var connection = CreateConnection())
            {
                var queryString = $"SELECT DBO.INN_FN_BELGE_NO_R('{tip}','{seri}')";
                  
                var val = connection.Query<string>(queryString).FirstOrDefault();

                return val;
            }
        }
    }
    
}

