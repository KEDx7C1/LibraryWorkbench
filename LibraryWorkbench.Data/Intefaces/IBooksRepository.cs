using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryWorkbench.Data.Intefaces
{
    public interface IBooksRepository
    {
        IQueryable<Book> GetAll();
        Book Get(int id);
        Book Create(Book book);
        Book Update(Book book);
        void Delete(int id);
    }
}
