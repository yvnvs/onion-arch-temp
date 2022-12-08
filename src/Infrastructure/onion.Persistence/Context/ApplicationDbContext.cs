﻿using Microsoft.EntityFrameworkCore;
using onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Persistence.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "Product1", Value =10 , Quantity =100},
                new Product() { Id = Guid.NewGuid(), Name = "Product2", Value =100 , Quantity =200},
                new Product() { Id = Guid.NewGuid(), Name = "Product2", Value =20 , Quantity =300}
                
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
