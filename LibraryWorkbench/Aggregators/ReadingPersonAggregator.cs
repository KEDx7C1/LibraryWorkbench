using LibraryWorkbench.DTO;
using LibraryWorkbench.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryWorkbench.Aggregators
{
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
