using System;
using System.ComponentModel.DataAnnotations;

namespace WorkRun.BaseDb
{
    public class EntityBase
    {
        [Key] 
        public Guid Id { get; set; }
        public DateTime ModifierDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
