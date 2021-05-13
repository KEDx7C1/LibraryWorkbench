using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Data.Models
{
    /// <summary>
    /// 2.2.1, 2.2.2.Б
    /// </summary>
    public abstract class PersonShort
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
    }
    /// <summary>
    /// 2.0.2, 2.2.1
    /// </summary>
    public class Person : PersonShort, IPerson
    {
        public int PersonId { get; set; }
        public DateTime Birthday { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
