using LibraryWorkbench.Aggregators;
using System.Collections.Generic;

namespace LibraryWorkbench.Interfaces
{
    /// <summary>
    /// 2.1
    /// </summary>
    interface IReadingPersonsRepository
    {
        List<ReadingPersonAggregator> GetReadingUsers();
        void AddReadingUser(ReadingPersonAggregator user);
    }
}
