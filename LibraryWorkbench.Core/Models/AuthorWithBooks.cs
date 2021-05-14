using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWorkbench.Core.Models
{
    public class AuthorWithBooks
    {
        [Required]
        public Author Author { get; set; }
        public List<Book> Books { get; set; }
    }
}
