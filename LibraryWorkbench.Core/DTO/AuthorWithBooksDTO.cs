using LibraryWorkbench.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LibraryWorkbench.Core.DTO
{
    public class AuthorWithBooksDTO
    {
        [Required]
        public AuthorDTO Author { get; set; }
        public IEnumerable<BookWithoutAuthorDTO> Books { get; set; }
    }
}
