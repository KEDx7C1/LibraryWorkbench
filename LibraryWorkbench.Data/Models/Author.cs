using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWorkbench.Data.Models
{
    public class Author : PersonShort
    {
        [Column("author_id")]
        public int AuthorId { get; set; }
    }
}
