using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkRun.Dto
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string Idn { get; set; }
        public string TaxNumber { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
