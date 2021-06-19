using System.Linq;
using LibraryWorkbench.Data.Models;

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