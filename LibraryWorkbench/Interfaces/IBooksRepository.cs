using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWorkbench.DTO;

namespace LibraryWorkbench.Interfaces
{
    /// <summary>
    /// 2.0
    /// </summary>
    interface IBooksRepository
    {
        public List<BookDTO> Get();
        public List<BookDTO> GetByAuthor(string author);
        public void Add(BookDTO book);
        public BookDTO GetByAuthorAndTitle(string author, string title);
        public void Remove(BookDTO book);
    }
}
