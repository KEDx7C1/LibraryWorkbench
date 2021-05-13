using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LibraryWorkbench.Data.Models
{
    public class DimGenre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        [JsonIgnore]
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
