using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkRun.BaseDb;
using WorkRun.Dto;

namespace WorkRun.Service.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase, IServiceController
    {
        PersonRepo _repo;
        private readonly IMapper _mapper;
        public PersonController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void SetProps(WorkRunContext context)
        {
            _repo = new(context);
        }

        public async Task<ActionResult<WorkResult>> InsertPerson([FromBody]PersonDto person)
        {
            return Ok();
        }
    }
}
