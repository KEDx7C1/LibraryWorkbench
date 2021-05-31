using LibraryWorkbench.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LibraryWorkbench.Core.DTO
{
    public class AuthorWithBooksDto
    {
        [Required]
        public AuthorDto Author { get; set; }
        public IEnumerable<BookWithoutAuthorDto> Books { get; set; }
    }
}
