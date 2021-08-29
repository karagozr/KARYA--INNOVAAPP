using InnovaApp.DataAccess.Context;
using InnovaApp.Entities.Dtos.Netsis;
using InnovaApp.Entities.Models.Netsis;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InnovaApp.DataAccess.Data.Netsis
{
    public class StokRepository : IDisposable
    {
        NetsisContext _netsisContext;
        public StokRepository(string donem=null)
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
            _netsisContext = new NetsisContext();

        }
        
        public List<StokKarti> StokKartlari(Expression<Func<StokKarti,bool>> filtre=null)
        {
            return filtre==null? _netsisContext.StokKarti.ToList(): _netsisContext.StokKarti.Where(filtre).ToList();
        }

        public List<StokKartiBakiyeli> BakiyeliStokKartlari(Expression<Func<StokKarti, bool>> filtre = null)
        {
            filtre = null;
            var stokListe = filtre == null ? _netsisContext.StokKarti.ToList() : _netsisContext.StokKarti.Where(filtre).ToList();
            var stokKodlari = stokListe.Select(x => x.StokKodu).ToList();
            var stokBakiyeListe = _netsisContext.StokBakiye.Where(x => stokKodlari.Contains(x.StokKodu));
            try
            {
                var stokKartiBakiyeli = stokListe
                        .Join(stokBakiyeListe,
                            stok => stok.StokKodu,
                            bakiye => bakiye.StokKodu,
                            (stok, bakiye) => new StokKartiBakiyeli
                            {
                                StokAdi = stok.StokAdi,
                                StokKodu = stok.StokKodu,
                                OlcuBr = stok.OlcuBr,
                                Miktar = 0
                            });
                return stokKartiBakiyeli.ToList();
            }
            catch (Exception ex)
            {
                object eccc = ex;
                return null;
            }
            


            //return stokKartiBakiyeli;
        }

        public List<StokKarti> StokBul(Expression<Func<StokKarti, bool>> filtre = null) 
            => filtre==null? _netsisContext.StokKarti.Take(100).ToList() : _netsisContext.StokKarti.Where(filtre).Take(100).ToList();

        public List<StokGrubu> StokGrublari() => _netsisContext.StokGrubu.ToList();

        public List<StokKod1> StokKodlari1() => _netsisContext.StokKod1.ToList();
       

        public List<StokKod2> StokKodlari2() => _netsisContext.StokKod2.ToList();
        

        public List<StokKod3> StokKodlari3() => _netsisContext.StokKod3.ToList();
        
        public List<StokKod4> StokKodlari4() => _netsisContext.StokKod4.ToList();
        

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
