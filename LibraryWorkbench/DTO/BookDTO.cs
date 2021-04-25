using LibraryWorkbench.Interfaces;
using System.ComponentModel.DataAnnotations;

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
    public class BookDTO : Book, IBook
    {
        [Required]
        public string Genre { get; set; }
    }
}
