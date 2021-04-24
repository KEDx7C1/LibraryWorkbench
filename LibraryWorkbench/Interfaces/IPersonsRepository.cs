using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWorkbench.DTO;

namespace LibraryWorkbench.Interfaces
{
    /// <summary>
    /// 2.0
    /// </summary>
    interface IPersonsRepository
    {
        public List<PersonDTO> Get();
        public List<PersonDTO> GetByName(string name);
        public void Add(PersonDTO user);
        public void Remove(string firstName, string lastName, string patronym);
    }
}
