using InnovaApp.DataAccess.Context;
using InnovaApp.Entities.Models.OgrenciServis;
using InnovaApp.Entities.Models.OgrenciServis.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InnovaApp.DataAccess.Data.OgrenciServis
{
    public class OgrenciBll : OgrenciServisRepository<Ogrenci> ,IDisposable
    {
        InnovaContext _context;
        public OgrenciBll()
        {
            _context = new InnovaContext();
        }
        public IQueryable<OgrenciDto> OgrenciListe(Expression<Func<OgrenciDto, bool>> filter = null)
        {
            var values = filter == null ? _context.Ogrenci.Select(x=>new OgrenciDto {
                Id=x.Id,
                Guid=x.Guid,
                Durum = x.Durum,
                OkulId =x.OkulId,
                OkulAdi=x.Okul.OkulAdi,
                Sinif=x.Sinif,
                OgrenciTcNo=x.OgrenciTcNo,
                OgrenciAdi=x.OgrenciAdi,
                OgrenciSoyadi=x.OgrenciSoyadi,
                BolgeId=x.BolgeId,
                BolgeAdi=x.Bolge.BolgeAdi,
                Adres=x.Adres,
                Aciklama=x.Aciklama,
                KayitTarihi = x.KayitTarihi
            }) : _context.Ogrenci.Select(x => new OgrenciDto
            {
                Id = x.Id,
                Guid = x.Guid,
                Durum = x.Durum,
                OkulId = x.OkulId,
                OkulAdi = x.Okul.OkulAdi,
                Sinif = x.Sinif,
                OgrenciTcNo = x.OgrenciTcNo,
                OgrenciAdi = x.OgrenciAdi,
                OgrenciSoyadi = x.OgrenciSoyadi,
                BolgeId = x.BolgeId,
                BolgeAdi = x.Bolge.BolgeAdi,
                Adres = x.Adres,
                Aciklama = x.Aciklama,
                KayitTarihi=x.KayitTarihi
            }).Where(filter);

            return values;
            
        }

        public OgrenciDto OgrenciGetir(int id)
        {
            var value = _context.Ogrenci.Select(x => new OgrenciDto
            {
                Id = x.Id,
                Guid = x.Guid,
                Durum = x.Durum,
                OkulId = x.OkulId,
                OkulAdi = x.Okul.OkulAdi,
                Sinif = x.Sinif,
                OgrenciTcNo = x.OgrenciTcNo,
                OgrenciAdi = x.OgrenciAdi,
                OgrenciSoyadi = x.OgrenciSoyadi,
                BolgeId = x.BolgeId,
                BolgeAdi = x.Bolge.BolgeAdi,
                Adres = x.Adres,
                Aciklama = x.Aciklama,
                KayitTarihi = x.KayitTarihi
            }).Where(x=>x.Id==id).FirstOrDefault();

            return value;

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~OkulBll()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class OgrenciBolgeBll : OgrenciServisRepository<OgrenciBolge>, IDisposable
    {
        InnovaContext _context;
        public OgrenciBolgeBll()
        {
            _context = new InnovaContext();
        }
        public IQueryable<OgrenciBolge> OgrenciBolgeListe(Expression<Func<OgrenciBolge, bool>> filter = null)
        {
            return filter == null ? _context.OgrenciBolge : _context.OgrenciBolge.Where(filter);

        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
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
