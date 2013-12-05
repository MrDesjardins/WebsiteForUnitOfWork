using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteForUnitOfWork.DataAccessLayer.UnitOfWork;

namespace WebsiteForUnitOfWork.DataAccessLayer.Repositories
{
public class HumanRepository : IHumanRepository
{
    public HumanRepository(IUnitOfWork unitOfWork) { }

    public void Insert(Models.Human humain)
    {
       
    }
}
}