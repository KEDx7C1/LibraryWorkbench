using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Core.DTO
{
    public class BookDto : BookWithoutAuthorDto
    {
        [Required]
        public AuthorDto Author { get; set; }
    }
}
