using AutoMapper;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace LibraryWorkbench.Core.DTO
{
    public class BookDto : BookWithoutAuthorDto
    {
        [Required]
        public AuthorDto Author { get; set; }
    }
}
