using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkRun.BaseDb
{
    [Table("Persons", Schema = "per")]
    public class Person : EntityBase
    {
        [StringLength(11)]
        public string Idn { get; set; }

        [StringLength(10)]
        public string TaxNumber { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string SurName { get; set; }
    }
}
