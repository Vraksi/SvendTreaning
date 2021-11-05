using Identity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Data
{
    public class WebshopContext : DbContext
    {
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<ProductAccessory> ProductAccessories { get; set; }

        public WebshopContext()
        {

        }

        public WebshopContext(DbContextOptions<WebshopContext> options)
             : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //ville umiddelbart kunne slettes men er der for en sikkerheds skyld hvis den ikke skulle være konfigureret
        //ConfigurationManager.ConnectionStrings["test"].ConnectionString
        //"Server=(localdb)\\mssqllocaldb;Database=Svendeprøve_træning2;Trusted_Connection=True;MultipleActiveResultSets=true"
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FastfoodServer;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
