using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkRun.Dto;

namespace WorkRun.Client.BL
{
    public class PersonRepo
    {
        private readonly WorkRunClient _client;
        public PersonRepo()
        {
            _client = new();
        }

        public async Task<WorkResult> Insert(PersonDto person)
        {
            string url = $"/person/insertPerson";
            return await _client.Post<WorkResult>(person, url);
        }
        public async Task<WorkResult> InsertRange(IEnumerable<PersonDto> persons)
        {
            string url = $"/person/insertPersons";
            return await _client.Post<WorkResult>(persons, url);
        }
    }
}
