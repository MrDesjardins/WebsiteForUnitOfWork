using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WebsiteForUnitOfWork.DataAccessLayer.Database;

namespace WebsiteForUnitOfWork.DataAccessLayer.UnitOfWork
{
public class UnitOfWork<T>:IUnitOfWork where T : DbContext, new()
{
    public T DatabaseContext { get; private set; }


    public UnitOfWork()
    {
        DatabaseContext = new T();
    }

    public void SaveChanges()
    {
        DatabaseContext.SaveChanges();
    }

    public System.Data.Entity.IDbSet<T> Set<T>() where T : class
    {
        return DatabaseContext.Set<T>();
    }

    public DbEntityEntry<T> Entry<T>(T entity) where T : class
    {
        return DatabaseContext.Entry<T>(entity);
    }
}
}