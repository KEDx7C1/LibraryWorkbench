﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryWorkbench.Interfaces
{
    /// <summary>
    /// 2.0
    /// </summary>
    interface IPersonsRepository
    {
        List<IPerson> GetAllPersons();
        Task<List<IPerson>> GetAllPersonsAsync();
        List<IPerson> GetPersonsByName(string name);
        Task<List<IPerson>> GetPersonsByNameAsync(string name);
        void AddPerson(IPerson user);
        Task AddPersonAsync(IPerson person);
        IPerson GetPersonByFullName(string firstName, string lastName, string patronym);
        Task<IPerson> GetPersonByFullNameAsync(string firstName, string lastName, string patronym);
        void RemovePerson(IPerson person);
        Task RemovePersonAsync(IPerson person);
    }
}
