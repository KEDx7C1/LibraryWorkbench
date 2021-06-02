using System.Collections.Generic;

namespace LibraryWorkbench.Core.DTO
{
    public class PersonExtDto : PersonDto
    {
        public IEnumerable<BookDto> Books { get; set; }
    }
}
