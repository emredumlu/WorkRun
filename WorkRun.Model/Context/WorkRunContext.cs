using Microsoft.EntityFrameworkCore;

namespace WorkRun.BaseDb
{
    public abstract class WorkRunContext : DbContext
    {
        public string CnnStr { get; set; }
        public DbSet<Person> Persons { get; set; }

    }
}
