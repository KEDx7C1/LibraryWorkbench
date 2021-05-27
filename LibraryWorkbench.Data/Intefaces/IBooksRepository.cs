using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryWorkbench.Data.Intefaces
{
    public interface IBooksRepository : IDisposable
    {
        IQueryable<Book> GetAll();
        Book Get(int id);
        void Create(Book book);
        void Update(Book book);
        void Delete(int id);
        void Save();
    }
}
