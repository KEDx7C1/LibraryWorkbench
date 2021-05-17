using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryWorkbench.Data.Models
{
    /// <summary>
    /// 2.2.1, 2.2.2.A
    /// </summary>
    public abstract class BookShort : Properties
    {
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("author_id")]
        [JsonIgnore]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

    /// <summary>
    /// 2.0.2, 2.2.1
    /// </summary>
    public class Book : BookShort, IBook
    {
        [Column("book_id")]
        public int BookId { get; set; }
        [Required]
        public List<DimGenre> Genres { get; set; } = new List<DimGenre>();
        [JsonIgnore]
        public virtual List<Person> Persons { get; set; } = new List<Person>();
        /// <summary>
        /// Hometask 2 8.1
        /// </summary>
        [Column("year")]
        public int Year { get; set; }
        [JsonIgnore]
        public List<LibraryCard> LibraryCards { get; set; } = new List<LibraryCard>();
        
    }
}
