using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryWorkbench.Data.Models
{
    public class DimGenre : BasicEntity
    {
        [Column("genre_id")] public int GenreId { get; set; }

        [Required] [Column("genre_name")] public string GenreName { get; set; }

        [Column("book_id")] [JsonIgnore] public List<Book> Books { get; set; } = new List<Book>();
    }
}