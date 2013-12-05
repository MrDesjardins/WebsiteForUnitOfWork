using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteForUnitOfWork.Models
{
public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Animal> Enemies { get; set; }
    public virtual ICollection<Animal> EnemyOf { get; set; }
}

public class Cat : Animal
{
    public int NumberOfMustache { get; set; }
    public int RemainingLife{get;set;}
}

public class Dog : Animal
{
    public string Type { get; set; }
}
}