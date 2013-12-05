using System;
using System.Collections.Generic;
using WebsiteForUnitOfWork.Models;
namespace WebsiteForUnitOfWork.DataAccessLayer.Repositories
{
public interface IAnimalRepository
{
    void Delete(Animal animal);
    Animal Find(int? id);
    IList<Animal> GetAll();
    void Insert(Animal animal);
    void Update(Animal animal);
}
}
