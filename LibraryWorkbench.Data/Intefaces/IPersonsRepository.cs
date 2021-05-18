using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWorkbench.Data.Intefaces
{
    public interface IPersonsRepository : IDisposable
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        Person GetWithBooks(int id);
        void Create(Person person);
        void Update(Person person);
        void Delete(int id);
        void Save();
    }
}
