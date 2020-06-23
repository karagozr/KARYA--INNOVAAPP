using InnovaApp.DataAccess.Context;
using InnovaApp.Entities.Models.FideSiparis.Innova;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InnovaApp.DataAccess.Data
{
    public class InnovaRepository : IDisposable
    {

        public void BelgeKaydet(List<BelgeKayit> belgeKayitlar)
        {
            string belgeNo = "";
            string cariKodu = "";
            using (var context = new InnovaContext())
            {
                foreach (var belgeKayit in belgeKayitlar)
                {
                    belgeNo = belgeKayit.BelgeNo;
                    cariKodu = belgeKayit.CariKodu;
                    context.Set<BelgeKayit>().Add(belgeKayit);
                }
                context.SaveChanges();
            }
            


        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
