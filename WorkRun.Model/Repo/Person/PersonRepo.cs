using System.Collections.Generic;

namespace WorkRun.BaseDb
{
    public class PersonRepo : BaseRepo, IPersonRepo
    {
        public PersonRepo(WorkRunContext ctx)
        {
            _ctx = ctx;
        }

        public void InsertPerson(Person person)
        {
            _ctx.Persons.Add(person);
        }
        public void InsertPersonRange(IEnumerable<Person> persons)
        {
            _ctx.Persons.AddRange(persons);
        }
    }
}
