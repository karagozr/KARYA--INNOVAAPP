using InnovaApp.DataAccess.Context;
using InnovaApp.Entities.Models.Netsis;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InnovaApp.DataAccess.Data.Netsis
{
    public class CariRepository : IDisposable
    {
        NetsisDonemContext _netsisContext;
        public CariRepository(string donem=null)
        {
            // IConfigurationRoot configuration = new ConfigurationBuilder()
            //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //.Build();

            // if (!string.IsNullOrEmpty(donem.ToString()))
            // {
            //     var connStr = configuration.GetConnectionString("NETSISDonemConnection").Replace("DBNAME",donem);
            //     //DBNAME
            //     _netsisContext = new NetsisDonemContext(connStr);
            // }
            // else
            // {
            //     var connStr = configuration.GetConnectionString("NETSISConnection");
            //     //DBNAME
            //     _netsisContext = new NetsisDonemContext(connStr);
            // }
            _netsisContext = new NetsisDonemContext();

        }
        
        public List<CariGrup> GetCariGrup()
        {
            return _netsisContext.CariGrup.ToList();
        }

        public List<CariRaporKod1> GetCariRaporKod1()
        {
            
            return _netsisContext.CariRaporKod1.ToList();
        }

        public CariBakiyeli GetCariBakiyeli(string cariKodu)
        {
            return _netsisContext.CariBakiyeli.Where(x => x.CariKodu == cariKodu).FirstOrDefault();
            
        }

        public IQueryable<CariBakiyeli> GetCariBakiyeliListe(Expression<Func<CariBakiyeli, bool>> filter = null)
        {
            
            return filter == null ? _netsisContext.CariBakiyeli.Select(x=>new CariBakiyeli {
                CariKodu=x.CariKodu,
                CariAdi=x.CariAdi,
                CariGrup=x.CariGrup,
                CariRaporKod1 =x.CariRaporKod1,
                Bakiye=x.Bakiye,
                PlasierKodu =x.PlasierKodu

            }) : _netsisContext.CariBakiyeli.Select(x => new CariBakiyeli
            {
                CariKodu = x.CariKodu,
                CariAdi = x.CariAdi,
                CariGrup = x.CariGrup,
                CariRaporKod1 = x.CariRaporKod1,
                Bakiye = x.Bakiye,
                PlasierKodu = x.PlasierKodu

            }).Where(filter);
            //using (var context = new InnovaContext())
            //{


            //}

        }

        public IQueryable<CariBakiyeli> GetCariBilgi(string cariKodu)
        {
            var result = _netsisContext.CariBakiyeli.Select(x => new CariBakiyeli
            {
                CariKodu = x.CariKodu,
                CariAdi = x.CariAdi,
                Bakiye = x.Bakiye

            }).Where(x => x.CariKodu == cariKodu);

            return result;

        }

        public IQueryable<CariBakiyeli> GetCariBilgiDetayli(string cariKodu)
        {
            var result = _netsisContext.CariBakiyeli.Select(x => new CariBakiyeli
            {
                CariKodu    = x.CariKodu,
                CariAdi     = x.CariAdi,
                Bakiye      = x.Bakiye,
                VergiDairesi = x.VergiDairesi,
                VergiNumarasi = x.VergiNumarasi,
                CariIl      = x.CariIl,
                CariIlce    = x.CariIlce,
                CariAdres   = x.CariAdres,
                Email       = x.Email,
                CariTel     = x.CariTel,
                Risk        = x.Risk

            }).Where(x => x.CariKodu == cariKodu);

            //var val = result.ToString();

            return result;

        }

        public IQueryable<CariHaraket> GetCariHaraketListe(string cariKodu)
        {
            var result = _netsisContext.CariHaraket.Where(x => x.CariKodu == cariKodu).OrderBy(z=>z.Tarih);
            return result;

        }

        public List<FaturaKalem> GetFatura(string belgeNo,string cariKodu)
        {
            var result = _netsisContext.FaturaKalem.Where(x => x.CariKodu == cariKodu && x.BelgeNo==belgeNo);
            return result.ToList();

        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _netsisContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
