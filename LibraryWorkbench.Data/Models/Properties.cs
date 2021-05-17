using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWorkbench.Data.Models
{
    /// <summary>
    /// Hometask 2 9.1
    /// </summary>
    public class Properties
    {
        /// <summary>
        /// Hometask 2 9.1.1
        /// </summary>
        [Column("creation_datetime")]
        public DateTimeOffset CreationDateTime { get; set; }
        /// <summary>
        /// Hometask 2 9.1.2
        /// </summary>
        [Column("updation_datetime")]
        public DateTimeOffset UpdationDateTime { get; set; }
        /// <summary>
        /// Hometask 2 9.1.3
        /// </summary>
        [Column("version")]
        public int Version { get; set; }
    }
}
