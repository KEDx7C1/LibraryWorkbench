using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryWorkbench.Core.DTO
{
    public class DimGenreDTO
    {
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
    }
}
