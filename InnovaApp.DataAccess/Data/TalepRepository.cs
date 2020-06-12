using InnovaApp.DataAccess.Context;
using InnovaApp.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InnovaApp.DataAccess.Data
{
    public class TalepRepository : IDisposable
    {
        
        public IQueryable<BelgeKayit> TalepListesiBaslik(Expression<Func<BelgeKayit, bool>> filter=null)
        {
            var context = new InnovaContext();
            return filter == null ? context.TalepKayit.GroupBy(x => new {
                x.BelgeNo,
                x.Aciklama,
                x.Tarih,
                x.Sube,
                x.BelgeDurum
            }).Select(x => new BelgeKayit
            {
                BelgeNo = x.Key.BelgeNo,
                Sube = x.Key.Sube,
                Tarih = x.Key.Tarih,
                Aciklama = x.Key.Aciklama,
                BelgeDurum = x.Key.BelgeDurum
            }) : context.TalepKayit.GroupBy(x => new {
                x.BelgeNo,
                x.Aciklama,
                x.Tarih,
                x.Sube,
                x.BelgeDurum
            }).Select(x => new BelgeKayit
            {
                BelgeNo = x.Key.BelgeNo,
                Sube = x.Key.Sube,
                Tarih = x.Key.Tarih,
                Aciklama = x.Key.Aciklama,
                BelgeDurum = x.Key.BelgeDurum
            }).Where(filter);
            //using (var context = new InnovaContext())
            //{
                

            //}
            
        }

        public IQueryable<BelgeKayit> GetTalepByBelgeNo(string belgeNo)
        {
            var context = new InnovaContext();
            var value =  context.TalepKayit.Where(x => x.BelgeNo == belgeNo);

            return value;

        }

        public int SonBelgeId()
        {
            var context = new InnovaContext();
            var value = context.TalepKayit.LastOrDefault();
            
            return value!=null?value.Id:0;

        }

        public void TalepKayit(BelgeKayit talepBelgesi)
        {
            using (var context = new InnovaContext())
            {
                context.Set<BelgeKayit>().Add(talepBelgesi);
                context.SaveChanges();
            }
        }
        public void TalepGuncelle(BelgeKayit talepBelgesi)
        {
            using (var context = new InnovaContext())
            {
                context.Entry(talepBelgesi).Property("Miktar").IsModified=true;
                context.Entry(talepBelgesi).Property("StokAdi").IsModified = true;
                context.Entry(talepBelgesi).Property("StokKodu").IsModified = true;
                context.Entry(talepBelgesi).Property("Birim").IsModified = true;

                
                context.SaveChanges();

                var tbl = GetTalepByBelgeNo(talepBelgesi.BelgeNo).ToList();
                foreach (var item in tbl)
                {
                    item.Aciklama = talepBelgesi.Aciklama;
                    context.Entry(item).Property("Aciklama").IsModified = true;
                }

                context.SaveChanges();

            }
        }
        public void TalepStokSil(int belgeId)
        {
            using (var context = new InnovaContext())
            {
                var belge = context.TalepKayit.Where(x => x.Id == belgeId).FirstOrDefault();
                context.Entry(belge).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        
    }
}
