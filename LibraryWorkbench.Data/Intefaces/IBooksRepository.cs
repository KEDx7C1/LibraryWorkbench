using System.Linq;
using LibraryWorkbench.Data.Models;

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