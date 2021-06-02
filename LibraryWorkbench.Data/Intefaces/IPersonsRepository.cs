using LibraryWorkbench.Data.Models;
using System.Linq;

namespace LibraryWorkbench.Data.Intefaces
{
    public interface IPersonsRepository
    {
        IQueryable<Person> GetAll();
        Person Get(int id);
        Person GetWithBooks(int id);
        Person Create(Person person);
        Person Update(Person person);
        void Delete(int id);
    }
}
