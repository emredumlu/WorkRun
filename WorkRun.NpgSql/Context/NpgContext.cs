using Microsoft.EntityFrameworkCore;
using WorkRun.BaseDb;

namespace WorkRun.NpgSql
{
    public class NpgContext : WorkRunContext
    {
        public NpgContext()
        {
            CnnStr = "User ID=postgres; Password=deva; Host=localhost; Port=5442; Database=WorkRunDb; Pooling=false; Timeout=300; CommandTimeout=180;";
        }

        public NpgContext(string cnnStr)
        {
            CnnStr = cnnStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(CnnStr);
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
