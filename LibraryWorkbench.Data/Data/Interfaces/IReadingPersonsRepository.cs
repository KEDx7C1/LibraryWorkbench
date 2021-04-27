using LibraryWorkbench.Data.Models;
using System.Collections.Generic;

namespace LibraryWorkbench.Data.Data.Interfaces
{
    /// <summary>
    /// 2.1
    /// </summary>
    public interface IReadingPersonsRepository
    {
        List<ReadingPerson> GetReadingPersons();
        void AddReadingPerson(ReadingPerson user);
    }
}
