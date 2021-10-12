using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkRun.MariaSql;
using WorkRun.NpgSql;

namespace WorkRun.Service
{
    [ApiController]
    [Route("[controller]")]
    public class DbController : ControllerBase
    {
        [HttpGet("createNpg")]
        public async Task<ActionResult<string>> CreateNpg()
        {
            NpgContext context = new();
            string message;
            try
            {
                await context.Database.MigrateAsync();
                message = "NpgSql db oluştu";
            }
            catch (Exception ex)
            {
                message = $"Bir Sorun oluştu-{ex.Message}";

            }

            return Ok(message);
        }

        [HttpGet("createMaria")]
        public async Task<ActionResult<string>> CreateMaria()
        {
            MariaContext context = new();
            string message;
            try
            {
                await context.Database.MigrateAsync();
                message = "NpgSql db oluştu";
            }
            catch (Exception ex)
            {
                message = $"Bir Sorun oluştu-{ex.Message}";

            }

            return Ok(message);
        }
    }
}
