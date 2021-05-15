using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWorkbench.Data.Models
{
    public class Properties
    {
        [Column("creation_datetime")]
        public DateTimeOffset CreationDateTime { get; set; }
        [Column("updation_datetime")]
        public DateTimeOffset UpdationDateTime { get; set; }
        [Column("version")]
        public int Version { get; set; }
    }
}
