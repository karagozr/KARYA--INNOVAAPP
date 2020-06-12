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
    public class TahakkukDetayBll : OgrenciServisRepository<TahakkukDetay> ,IDisposable
    {
        InnovaContext _context;
        public TahakkukDetayBll()
        {
            _context = new InnovaContext();
        }
        public IQueryable<TahakkukDetayDto> TahakkukDetayGetir(string tahakkukGuid)
        {
            var value =  _context.TahakkukDetay.Where(x => x.TahakkukGuid == tahakkukGuid).Select(x => new TahakkukDetayDto
            {
                Id = x.Id,
                Guid = x.Guid,
                Aciklama=x.Aciklama,
                Tarih=x.Tarih,
                Borc=x.Borc,
                IndirimAdi=x.Tahakkuk.IndirimAdi
            });

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
}
