using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Core.DTO
{
    public class DimGenreDto
    {
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
    }
}
