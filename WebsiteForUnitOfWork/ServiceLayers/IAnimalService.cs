using System;
using System.Collections.Generic;
using WebsiteForUnitOfWork.Models;
namespace WebsiteForUnitOfWork.ServiceLayers
{
public interface IAnimalService
{
    void Delete(Animal animal);
    void Delete(IList<Animal> animals);
    Animal Find(int? id);
    IList<Animal> GetAll();
    void Save(Animal animal);
    void Save(IList<Animal> animal);

    void SaveAll(Animal animal, Human humain);
}
}
