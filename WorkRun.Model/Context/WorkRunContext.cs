using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace WorkRun.BaseDb
{
    public abstract class WorkRunContext : DbContext
    {
        public string CnnStr { get; set; }
        public DbSet<Person> Persons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entities = modelBuilder.Model.GetEntityTypes();
            foreach (var entity in entities)
            {
                if (entity.ClrType == typeof(EntityBase))
                {

                    modelBuilder.Entity(entity.Name)
                        .Property("Counter")
                        .ValueGeneratedOnAdd();
                }
            }

            base.OnModelCreating(modelBuilder);
        }
        public async Task<bool> SaveAsync()
        {
            var entities = ChangeTracker.Entries<EntityBase>();

            foreach (var entity in entities)
            {
                if (entity.Entity.UpdateCount == 0)
                {
                    entity.Entity.CreateDate = DateTime.Now;
                }

                entity.Entity.ModifierDate = DateTime.Now;

                entity.Entity.UpdateCount++;
            }

            return await SaveChangesAsync() > 0;
        }

        public bool Save()
        {
            var entities = ChangeTracker.Entries<EntityBase>();

            foreach (var entity in entities)
            {
                if (entity.Entity.UpdateCount == 0)
                {
                    entity.Entity.CreateDate = DateTime.Now;
                }

                entity.Entity.ModifierDate = DateTime.Now;

                entity.Entity.UpdateCount++;
            }

            return SaveChanges() > 0;
        }

    }
}
