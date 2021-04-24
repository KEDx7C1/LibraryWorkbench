using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWorkbench.DTO;
using LibraryWorkbench.Interfaces;


namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.0
    /// </summary>
    public class PersonsRepository : IPersonsRepository
    {
        public List<PersonDTO> Get()
        {
            return Data.Users;
        }

        public List<PersonDTO> GetByName(string name)
        {
            return Data.Users.Where(x => x.FirstName == name).Select(x => x).ToList();
        }
        public void Add(PersonDTO user)
        {
            Data.Users.Add(user);
        }

        public void Remove(string firstName, string lastName, string patronym)
        {
            Data.Users.RemoveAll(x => x.FirstName == firstName && x.LastName == lastName && x.Patronym == patronym);
        }
    }
}
