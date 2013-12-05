using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebsiteForUnitOfWork.Models;

namespace WebsiteForUnitOfWork.DataAccessLayer.Database
{
public class AllDomainContext:DbContext
{
    public AllDomainContext():base("EntityConnectionString")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Table per type configuration
        modelBuilder.Entity<Dog>().ToTable("Animals");
        modelBuilder.Entity<Dog>().ToTable("Dogs");
        modelBuilder.Entity<Cat>().ToTable("Cats");

        //Primary keys configuration
        modelBuilder.Entity<Animal>().HasKey(k => k.Id);

        modelBuilder.Entity<Animal>()
            .HasMany(entity => entity.Enemies)
            .WithMany(d => d.EnemyOf)
            .Map(d => d.ToTable("Animals_Enemies_Association").MapLeftKey("AnimalId").MapRightKey("EnemyId"));
            
    }
}

}