using InnovaApp.DataAccess.Context;
using InnovaApp.Entities.Models.FideSiparis.Innova;
using InnovaApp.Entities.Models.IsAkis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InnovaApp.DataAccess.Data.IsAkis
{
    public class IsAkisRepository : IDisposable
    {

        public List<IsAkisEmir> IsAkisListe(int kullaniciId)
        {
            using (var context = new InnovaContext())
            {
                var akisSeviyeleri = context.IsAkis.Where(x => x.Kullanici == kullaniciId).Select(s=>(s.AkisId*10000+s.Sira)).ToList();

                var result = context.IsAkisEmir.ToList();//.Where(x => akisSeviyeleri.Contains(x.AkisTekil)).ToList();
                return result;
            }
            


        }

        public ResultProcc IsAkisOnayIptal(int isAkisId,string islemKodu, int kullaniciId)
        {
            try
            {
                using (var context = new InnovaContext())
                {
                    SqlParameter _isAkisId = new SqlParameter("@IsakisId", isAkisId);
                    SqlParameter _islemKodu = new SqlParameter("@IslemKodu", islemKodu);
                    SqlParameter _kullaniciId = new SqlParameter("@KullanniciId", kullaniciId);

                    context.Database.ExecuteSqlCommand("INN_PR_ISAKIS_SURECI_ODEME_EMRI_ISLEM @IsakisId, @IslemKodu, @KullanniciId", _isAkisId, _islemKodu, _kullaniciId);

                    return new ResultProcc { 
                        Success=true,
                        Message="başarılı"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultProcc
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class ResultProcc
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
