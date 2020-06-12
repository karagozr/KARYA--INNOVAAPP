using InnovaApp.DataAccess.Context;
using InnovaApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnovaApp.DataAccess.Data
{
    public class UserRepository : IDisposable
    {
        InnovaContext _innovaContext;
        public UserRepository()
        {
            _innovaContext = new InnovaContext();
        }
        public User UserLogin(string userName, string password)
        {
            return _innovaContext.User.Where(x => x.Kullanici == userName && x.Sifre == password).FirstOrDefault();

        }

        public UserYetki UserYetkiGetir(int userId, int yetkiKodu)
        {
            return _innovaContext.UserYetki.Where(x => x.Kullanici == userId && x.Id == yetkiKodu).FirstOrDefault();

        }

        public List<User> UserList(string depoKodu)
        {
            if(depoKodu=="")
                return  _innovaContext.User.ToList();
            else
                return _innovaContext.User.Where(x => x.Depo == depoKodu).ToList();
             

        }

        public List<User> UserList1()
        {
            return _innovaContext.User.ToList();
            //if(depoKodu=="")

            //else
            //    return _innovaContext.User.Where(x => x.Depo == depoKodu).ToList();


        }


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _innovaContext.Dispose();
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
