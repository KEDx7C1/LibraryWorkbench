using System.Linq;
using LibraryWorkbench.Data.Models;

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