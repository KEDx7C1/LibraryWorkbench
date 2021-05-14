using LibraryWorkbench.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Core.Models
{
    public class AuthorWithBooks
    {
        [Required]
        public Author Author { get; set; }
        public List<Book> Books { get; set; }
    }
}
