using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteForUnitOfWork.Models;
using WebsiteForUnitOfWork.DataAccessLayer.Database;
using WebsiteForUnitOfWork.ServiceLayers;
using WebsiteForUnitOfWork.DataAccessLayer.Repositories;
using WebsiteForUnitOfWork.DataAccessLayer.UnitOfWork;

namespace WebsiteForUnitOfWork.Controllers
{
public class AnimalController : Controller
{
    private readonly IAnimalService _service;

    public AnimalController()
    {
        var uow = new UnitOfWork<AllDomainContext>();
        _service = new AnimalService(uow, new AnimalRepository(uow), new HumanRepository(uow)); 
    }

    public AnimalController(IAnimalService animalService)
    {
        _service = animalService;
    }


    public ActionResult Index()
    {
        return View(_service.GetAll());
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Animal animal = _service.Find(id);
        if (animal == null)
        {
            return HttpNotFound();
        }
        return View(animal);
    }

    public ActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include="Id,Name")] Animal animal)
    {
        if (ModelState.IsValid)
        {
            _service.Save(animal);
            return RedirectToAction("Index");
        }

        return View(animal);
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Animal animal = _service.Find(id);
        if (animal == null)
        {
            return HttpNotFound();
        }
        return View(animal);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include="Id,Name")] Animal animal)
    {
        if (ModelState.IsValid)
        {
            _service.Save(animal);
            return RedirectToAction("Index");
        }
        return View(animal);
    }

    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Animal animal = _service.Find(id);
        if (animal == null)
        {
            return HttpNotFound();
        }
        return View(animal);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Animal animal = _service.Find(id);
        _service.Delete(animal);
        return RedirectToAction("Index");
    }


}
}
