using AutoMapper;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryWorkbench.Core.DTO
{
    public class BookWithoutAuthorDTO
    {
        public int BookId { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Required]
        public List<DimGenreDTO> Genres { get; set; }
        public int Year { get; set; }
    }
    public class BookDTO : BookWithoutAuthorDTO
    {
        [Required]
        public AuthorDTO Author { get; set; }
    }
}
