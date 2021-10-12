using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkRun.BaseDb
{
    public interface IPersonRepo
    {
        void InsertPerson(Person person);
        void InsertPersonRange(IEnumerable<Person> persons);
    }
}
