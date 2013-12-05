using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebsiteForUnitOfWork.DataAccessLayer.Database;
using WebsiteForUnitOfWork.DataAccessLayer.UnitOfWork;
using WebsiteForUnitOfWork.Models;

namespace WebsiteForUnitOfWork.DataAccessLayer.Repositories
{
public class AnimalRepository : WebsiteForUnitOfWork.DataAccessLayer.Repositories.IAnimalRepository
{
    private IUnitOfWork UnitOfWork { get; set; }

    public AnimalRepository(IUnitOfWork unitOfWork)
    {
        this.UnitOfWork = unitOfWork;
    }

    public Models.Animal Find(int? id)
    {
        return UnitOfWork.Set<Animal>().Find(id);
    }

    public void Insert(Models.Animal animal)
    {
        UnitOfWork.Set<Animal>().Add(animal);
    }

    public void Update(Models.Animal animal)
    {
        UnitOfWork.Entry(animal).State = EntityState.Modified;
    }

    public void Delete(Models.Animal animal)
    {
        UnitOfWork.Set<Animal>().Remove(animal);
    }

    public IList<Animal> GetAll()
    {
        return UnitOfWork.Set<Animal>().AsNoTracking().ToList();
    }
}
}