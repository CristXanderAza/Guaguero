using Guaguero.Domain.Entities.Logistic;
using Guaguero.Domain.Entities.Logistic.Routes;
using Guaguero.Domain.Entities.Sindicatos;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Entities.Travels.Payments;
using Guaguero.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Base
{
    public class GuagueroContext : DbContext
    {
        //Logistic:
        public DbSet<Route> Routes { get; set; }
        public DbSet<WayPoint> WayPoints { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountSolicitud> DiscountSolicituds { get; set; } 

        //Sindicato:
        public DbSet<Sindicato> Sindicatos { get; set; }
        public DbSet<Bus> Buses { get; set; }

        //Travels:
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Quota> Quotas { get; set; }
        public DbSet<PaymentBase> Payments { get; set; }

        //Users:
        public DbSet<UserBase> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CreditPerUser> Credits { get; set; }
        public DbSet<Reload> Reloads { get; set; }


        public GuagueroContext(DbContextOptions<GuagueroContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
