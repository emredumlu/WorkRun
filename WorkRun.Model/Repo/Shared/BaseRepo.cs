using System.Threading.Tasks;

namespace WorkRun.BaseDb
{
    public class BaseRepo
    {
        public WorkRunContext _ctx { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await _ctx.SaveAsync();
        }
    }
}
