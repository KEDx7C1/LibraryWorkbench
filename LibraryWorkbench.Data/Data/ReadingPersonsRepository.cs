using LibraryWorkbench.Data.Data.Interfaces;
using LibraryWorkbench.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.1
    /// </summary>
    public class ReadingPersonsRepository : IReadingPersonsRepository
    {
        public List<ReadingPerson> GetReadingPersons()
        {
            return DataTables.DataTables.ReadingPersons;
        }
        public async Task<List<ReadingPerson>> GetReadingPersonsAsync()
        {
            return await Task.Run(() => GetReadingPersons());
        }
        public void AddReadingPerson(ReadingPerson person)
        {
            DataTables.DataTables.ReadingPersons.Add(person);
        }
        public async Task AddReadingPersonAsync(ReadingPerson person)
        {
            await Task.Run(() => AddReadingPerson(person));
        }
    }
}
