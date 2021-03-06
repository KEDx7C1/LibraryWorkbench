using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Core.DTO
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public DateTime Birthday { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}