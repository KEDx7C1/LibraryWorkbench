using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWorkbench.Core.DTO
{
    public class PersonExtDto : PersonDto
    {
        public List<BookDto> Books { get; set; }
    }
}
