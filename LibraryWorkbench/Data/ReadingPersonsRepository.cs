using LibraryWorkbench.Aggregators;
using LibraryWorkbench.Interfaces;
using System.Collections.Generic;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.1
    /// </summary>
    public class ReadingPersonsRepository : IReadingPersonsRepository
    {
        public List<ReadingPersonAggregator> GetReadingUsers()
        {
            return Data.ReadingUsers;
        }

        public void AddReadingUser(ReadingPersonAggregator user)
        {
            Data.ReadingUsers.Add(user);
        }
    }
}
