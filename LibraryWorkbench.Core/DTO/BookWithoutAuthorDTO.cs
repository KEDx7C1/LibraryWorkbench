using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Core.DTO
{
    public class BookWithoutAuthorDto
    {
        public int BookId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public IEnumerable<DimGenreDto> Genres { get; set; }
        public int Year { get; set; }
    }
}
