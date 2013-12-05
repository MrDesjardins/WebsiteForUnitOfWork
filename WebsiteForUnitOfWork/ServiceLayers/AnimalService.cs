using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebsiteForUnitOfWork.DataAccessLayer.Database;
using WebsiteForUnitOfWork.DataAccessLayer.Repositories;
using WebsiteForUnitOfWork.DataAccessLayer.UnitOfWork;
using WebsiteForUnitOfWork.Models;

namespace WebsiteForUnitOfWork.ServiceLayers
{
public class AnimalService: IAnimalService
{
    private IAnimalRepository animalRepository;
    private IHumanRepository humanRepository;
    private IUnitOfWork unitOfWork;
    public AnimalService(IUnitOfWork unitOfWork, IAnimalRepository animalRepository, IHumanRepository humanRepository)
    {
        this.unitOfWork = unitOfWork;
        this.animalRepository = animalRepository;
        this.humanRepository = humanRepository;
    }

    public Animal Find(int? id)
    {
        return this.animalRepository.Find(id);
    }

    public void Delete(IList<Animal> animals)
    {
        foreach (var animal in animals)
        {
            this.animalRepository.Delete(animal);    
        }

        this.unitOfWork.SaveChanges();
    }

    public void Delete(Models.Animal animal)
    {
        this.Delete(new List<Animal> { animal });
    }

    public IList<Animal> GetAll()
    {
        return this.animalRepository.GetAll();
    }

    public void Save(Animal animal)
    {
        Save(new List<Animal> { animal });
    }

    public void Save(IList<Animal> animals)
    {
        foreach (var animal in animals)
        {
            if (animal.Id == default(int))
            {
                this.animalRepository.Insert(animal);
            }
            else
            {
                this.animalRepository.Update(animal);
            }
        }

        this.unitOfWork.SaveChanges();
    }

    public void SaveAll(Animal animal, Human humain)
    {
        this.animalRepository.Insert(animal);
        this.humanRepository.Insert(humain);
        this.unitOfWork.SaveChanges();
    }
}
}