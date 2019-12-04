using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Domain.Entities;
using ProjectGym.Domain.MetaData;
using static ProjectGym.Application.ConnectionString.ConnectionString;

namespace ProjectGym.Infraestructure
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionStringSql);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }


            //=============================================================//



            //=============================================================//

            modelBuilder.ApplyConfiguration<Employee>(new EmployeeMetaData());
            modelBuilder.ApplyConfiguration<Product>(new ProductMetaData());
            modelBuilder.ApplyConfiguration<Customer>(new CustomerMetaData());

            modelBuilder.ApplyConfiguration<Plan>(new PlanMetaData());


            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entidad in ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted
                            && x.OriginalValues.Properties
                                .Any(p => p.Name.Contains("IsDelete"))))
            {
                entidad.State = EntityState.Unchanged;
                entidad.CurrentValues["IsDelete"] = true;
            }

            return base.SaveChangesAsync();
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Plan> Planes { get; set; }
    }
}
