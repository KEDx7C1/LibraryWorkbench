using System;

namespace LibraryWorkbench.Data.Models
{
    public class Properties
    {
        public DateTimeOffset CreationDateTime { get; set; }
        public DateTimeOffset UpdationDateTime { get; set; }
        public int Version { get; set; }
    }
}
