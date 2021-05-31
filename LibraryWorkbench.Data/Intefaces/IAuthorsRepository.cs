using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryWorkbench.Data.Intefaces
{
    public interface IAuthorsRepository
    {
        IQueryable<Author> GetAll();
        Author Get(int id);
        Author Create(Author author);
        Author Update(Author author);
        void Delete(int id);
    }
}
