using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteForUnitOfWork.DataAccessLayer.Database;

namespace WebsiteForUnitOfWork.DataAccessLayer.UnitOfWork
{
public interface IUnitOfWork
{
    IDbSet<T> Set<T>() where T:class;

    DbEntityEntry<T> Entry<T>(T entity) where T:class;

    void SaveChanges();
}
}
