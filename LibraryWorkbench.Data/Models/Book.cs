using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryWorkbench.Data.Models
{
    /// <summary>
    /// 2.2.1, 2.2.2.A
    /// </summary>
    public abstract class BookShort : Properties
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Author Author { get; set; }
    }

    /// <summary>
    /// 2.0.2, 2.2.1
    /// </summary>
    public class Book : BookShort, IBook
    {
        public int BookId { get; set; }
        [Required]
        public List<DimGenre> Genres { get; set; } = new List<DimGenre>();
        [JsonIgnore]
        public virtual List<Person> Persons { get; set; } = new List<Person>();
        public int Year { get; set; }
    }
}
