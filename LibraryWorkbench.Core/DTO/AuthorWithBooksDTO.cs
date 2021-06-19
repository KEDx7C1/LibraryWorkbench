using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Core.DTO
{
    public class AuthorWithBooksDto
    {
        [Required] public AuthorDto Author { get; set; }

        public IEnumerable<BookWithoutAuthorDto> Books { get; set; }
    }
}