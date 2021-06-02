using LibraryWorkbench.Data.Models;
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
