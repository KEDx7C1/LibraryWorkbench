using LibraryWorkbench.Aggregators;
using LibraryWorkbench.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.1
    /// </summary>
    public class ReadingPersonsRepository : IReadingPersonsRepository
    {
        public List<ReadingPersonAggregator> GetReadingPersons()
        {
            return Data.ReadingPersons;
        }
        public async Task<List<ReadingPersonAggregator>> GetReadingPersonsAsync()
        {
            return await Task.Run(() => GetReadingPersons());
        }
        public void AddReadingPerson(ReadingPersonAggregator person)
        {
            Data.ReadingPersons.Add(person);
        }
        public async Task AddReadingPersonAsync(ReadingPersonAggregator person)
        {
            await Task.Run(() => AddReadingPerson(person));
        }
    }
}
