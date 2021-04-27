using LibraryWorkbench.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Data.Models
{
    /// <summary>
    /// 2.2.1, 2.2.2.A
    /// </summary>
    public abstract class BookShort
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
    }

    /// <summary>
    /// 2.0.2, 2.2.1
    /// </summary>
    public class Book : BookShort, IBook
    {
        [Required]
        public string Genre { get; set; }
    }
}
