using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.DTO
{
    /// <summary>
    /// 2.2
    /// </summary>
    public abstract class Person
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Patronym { get; set; }

        public Person()
        { }
    }
    /// <summary>
    /// 2.0
    /// </summary>
    public class PersonDTO : Person
    {
        [Required]
        public DateTime Birthday { get; set; }
    }
}
