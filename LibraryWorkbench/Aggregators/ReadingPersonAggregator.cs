using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LibraryWorkbench.DTO;

namespace LibraryWorkbench.Aggregators
{
    public class ReadingPersonAggregator
    {
        [Required]
        public PersonDTO User { get; }

        [Required]
        public BookDTO Book { get; }

        [Required]
        //[JsonConverter(typeof(ReadingUserTimeConverter))]
        public DateTimeOffset GettingTime { get; }

        public ReadingPersonAggregator (PersonDTO user, BookDTO book, DateTimeOffset gettingTime)
        {
            User = user;
            Book = book;
            GettingTime = gettingTime;
        }
    }
}
