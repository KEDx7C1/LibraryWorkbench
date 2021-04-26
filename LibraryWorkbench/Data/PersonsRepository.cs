using LibraryWorkbench.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.0
    /// </summary>
    public class PersonsRepository : IPersonsRepository
    {
        public List<IPerson> GetAllPersons()
        {
            return Data.Persons;
        }

        public async Task<List<IPerson>> GetAllPersonsAsync()
        {
            return await Task.Run(() => GetAllPersons());
        }

        public List<IPerson> GetPersonsByName(string name)
        {
            return Data.Persons.Where(x => x.FirstName == name).Select(x => x).ToList();
        }

        public async Task<List<IPerson>> GetPersonsByNameAsync(string name)
        {
            return await Task.Run(() => GetPersonsByName(name));
        }
        public void AddPerson(IPerson person)
        {
            Data.Persons.Add(person);
        }
        public async Task AddPersonAsync(IPerson person)
        {
            await Task.Run(() => AddPerson(person));
        }
        public IPerson GetPersonByFullName(string firstName, string lastName, string patronym)
        {
            return Data.Persons.Find(x => x.FirstName == firstName && x.LastName == lastName && x.Patronym == patronym);
        }

        public async Task<IPerson> GetPersonByFullNameAsync(string firstName, string lastName, string patronym)
        {
            return await Task.Run(() => GetPersonByFullName(firstName, lastName, patronym));
        }

        public void RemovePerson(IPerson person)
        {
            Data.Persons.RemoveAll(x => x.FirstName == person.FirstName && x.LastName == person.LastName && x.Patronym == person.Patronym);
        }
        public async Task RemovePersonAsync(IPerson person)
        {
            await Task.Run(() => RemovePerson(person));
        }
    }
}
