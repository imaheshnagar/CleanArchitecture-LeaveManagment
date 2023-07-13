using LeaveManagement.Domain;
using LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistance.DatabaseContext
{
    public class LmDatabaseContext:DbContext
    {
        public LmDatabaseContext(DbContextOptions<LmDatabaseContext> options):base(options)
        {
            
        }

        public DbSet<LeaveType>  LeaveTypes{ get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            foreach (var entity in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q=>q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entity.Entity.DateModified = DateTime.Now;

                if (entity.State == EntityState.Added)
                {
                    entity.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LmDatabaseContext).Assembly);


            base.OnModelCreating(modelBuilder);
        }

    }
}
