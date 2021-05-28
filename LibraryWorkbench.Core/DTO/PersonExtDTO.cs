using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWorkbench.Core.DTO
{
    public class PersonExtDTO : PersonDTO
    {
        public List<BookDTO> Books { get; set; }
    }
}
