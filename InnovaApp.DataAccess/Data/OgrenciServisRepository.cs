using InnovaApp.DataAccess.Context;
using InnovaApp.Entities.Models;
using InnovaApp.Entities.Models.OgrenciServis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InnovaApp.DataAccess.Data
{
    public class OgrenciServisRepository<TEntity>   where TEntity:class
    {
        public void Insert(TEntity entity)
        {
            using (var context = new InnovaContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity, string[] propertyListesi=null)
        {
            using (var context = new InnovaContext())
            {
                foreach (var item in propertyListesi)
                {
                    context.Entry(entity).Property(item).IsModified = true;
                }
                if(propertyListesi==null) context.Entry(entity).State = EntityState.Modified;

                context.SaveChanges();
            }
        }


        public void Delete(TEntity entity)
        {
            using (var context = new InnovaContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        
    }
}
