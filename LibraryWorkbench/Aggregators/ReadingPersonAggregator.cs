using LibraryWorkbench.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Aggregators
{
    /// <summary>
    /// 2.1.1, 2.2.1
    /// </summary>
    public class ReadingPersonAggregator
    {
        [Required]
        public PersonDTO Person { get; set; }
        [Required]
        public BookDTO Book { get; set; }
        [Required]
        public DateTimeOffset GettingTime { get; set; }
        public ReadingPersonAggregator()
        { }
        public ReadingPersonAggregator(PersonDTO person, BookDTO book, DateTimeOffset gettingTime)
        {
            Person = person;
            Book = book;
            GettingTime = gettingTime;
        }
    }
}
