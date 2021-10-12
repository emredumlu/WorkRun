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
        private PersonRepo _repo;
        private readonly IMapper _mapper;
        public PersonController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void SetProps(WorkRunContext context)
        {
            _repo = new PersonRepo(context);
        }

        [HttpPost("insertPerson")]
        public async Task<ActionResult<WorkResult>> InsertPerson([FromBody] PersonDto person)
        {
            Person personEntity = _mapper.Map<Person>(person);
            _repo.InsertPerson(personEntity);
            var result = await _repo.SaveAsync();

            return Ok(result);
        }
    }
}
