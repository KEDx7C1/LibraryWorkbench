using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWorkbench.DTO;
using LibraryWorkbench.Interfaces;
using LibraryWorkbench.Aggregators;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// 2.1
    /// </summary>
    public class ReadingPersonsRepository :IReadingPersonsRepository
    {
        public List<ReadingPersonAggregator> GetReadingUsers()
        {
            return Data.ReadingUsers;
        }

        public void AddReadingUser (ReadingPersonAggregator user)
        {
            Data.ReadingUsers.Add(user);
        }
    }
}
