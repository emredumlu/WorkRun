using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkRun.BaseDb
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime ModifierDate { get; set; }
        public DateTime CreateDate { get; set; }
        public uint RowVersion { get; private set; }
        public int UpdateCount { get; set; }
    }
}
