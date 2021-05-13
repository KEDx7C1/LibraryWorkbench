using LibraryWorkbench.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Data.Models
{
    /// <summary>
    /// 2.1.1, 2.2.1
    /// </summary>
    public class ReadingPerson
    {
        [Required]
        public Person Person { get; set; }
        [Required]
        public Book Book { get; set; }
        //[Required]
        //public DateTimeOffset GettingTime { get; set; }
        public ReadingPerson()
        { }
        public ReadingPerson(Person person, Book book)
        {
            Person = person;
            Book = book;
            //GettingTime = gettingTime;
        }
    }
}
