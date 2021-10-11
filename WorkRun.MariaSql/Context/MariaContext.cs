using Microsoft.EntityFrameworkCore;
using WorkRun.BaseDb;

namespace WorkRun.MariaSql
{
    public class MariaContext : WorkRunContext
    {
        public MariaContext()
        {
            CnnStr = "uid=root;pwd=deva;Host=localhost;Database=WorkRunDb;";
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
    }
}
