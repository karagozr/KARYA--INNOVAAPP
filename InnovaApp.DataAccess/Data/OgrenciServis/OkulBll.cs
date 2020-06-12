using InnovaApp.DataAccess.Context;
using InnovaApp.Entities.Models.OgrenciServis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InnovaApp.DataAccess.Data.OgrenciServis
{
    public class OkulBll : OgrenciServisRepository<Okul> ,IDisposable
    {
        InnovaContext _context;
        public OkulBll()
        {
            _context = new InnovaContext();
        }
        public IQueryable<Okul> OkulListe(Expression<Func<Okul, bool>> filter = null)
        {
            return filter == null ? _context.Okul : _context.Okul.Where(filter);
            
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
