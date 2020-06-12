using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaApp.DataAccess.Helper
{
    public static class DbManager
    {
        public static string DbName;

        public static string GetDbConnectionString(string dbName)
        {
            return DbConnectionManager.GetConnectionString(dbName);
        }
    }
}
