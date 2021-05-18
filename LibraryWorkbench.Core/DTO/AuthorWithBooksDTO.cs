using LibraryWorkbench.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Core.DTO
{
    public class AuthorWithBooksDTO
    {
        [Required]
        public AuthorDTO Author { get; set; }
        public List<BookWithoutAuthorDTO> Books { get; set; }
    }
}
