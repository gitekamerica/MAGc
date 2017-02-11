using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Entities;

namespace WebApplication.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<MoveStorage> MoveStorages { get; set; }

        public DbSet<MoveDetails> MoveDetails { get; set; }

        public DbSet<Persons> Persons { get; set; }

        


    }
}