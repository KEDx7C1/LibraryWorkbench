using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryWorkbench.Core.DTO
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
    public class PersonExtDTO : PersonDTO
    {
        public List<BookDTO> Books { get; set; }
    }
}
