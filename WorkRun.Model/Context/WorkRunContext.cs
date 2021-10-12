using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> Save()
        {
            var entities = ChangeTracker.Entries<EntityBase>();
            foreach (var entity in entities)
            {

            }

            return await SaveChangesAsync() > 0;
        }

    }
}
