using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWorkbench.Aggregators;

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
