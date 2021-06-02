using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Core.DTO
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
