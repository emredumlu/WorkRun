using Microsoft.EntityFrameworkCore;
using WorkRun.BaseDb;

namespace WorkRun.MariaSql
{
    public class MariaContext : WorkRunContext
    {
        public MariaContext()
        {
            CnnStr = "uid=root;pwd=emre;Host=localhost;Database=WorkRunDb;";//Port:30066,Service:MariaDB
        }

        public MariaContext(string cnnStr)
        {
            CnnStr = cnnStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ServerVersion.AutoDetect(CnnStr));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entities = modelBuilder.Model.GetEntityTypes();
            foreach (var entity in entities)
            {
                if (entity.ClrType == typeof(EntityBase))
                {
                    modelBuilder.Entity(entity.Name)
                    .Property<uint>("RowVersion")
                    .HasColumnName("xmin")
                    .HasColumnType("xid")
                    .ValueGeneratedOnAddOrUpdate()
                    .IsConcurrencyToken();
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
