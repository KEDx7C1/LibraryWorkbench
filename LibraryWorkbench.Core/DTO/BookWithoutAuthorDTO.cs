using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibraryWorkbench.Core.DTO
{
    public class BookWithoutAuthorDTO
    {
        public int BookId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public IEnumerable<DimGenreDTO> Genres { get; set; }
        public int Year { get; set; }
    }
}
