using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWorkbench.DTO
{
    /// <summary>
    /// 2.2
    /// </summary>
    public abstract class Book
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
    }
    /// <summary>
    /// 2.0
    /// </summary>
    public class BookDTO : Book
    {
        [Required]
        public string Genre { get; set; }
    }
}
