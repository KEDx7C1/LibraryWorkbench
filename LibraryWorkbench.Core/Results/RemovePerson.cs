using LibraryWorkbench.Data.Data.Interfaces;
using LibraryWorkbench.Data.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWorkbench.Core.Results
{
    public class RemovePersons
    {
        public static async Task<int> RemovePerson(string firstName, string lastName, string patronym, IPersonsRepository persons)
        {
            IPerson person = await persons.GetPersonByFullNameAsync(firstName, lastName, patronym);
            if (person != null)
            {
                await persons.RemovePersonAsync(person);
                return StatusCodes.Status200OK;
            }
            else
                return StatusCodes.Status404NotFound;
        }
    }
}
