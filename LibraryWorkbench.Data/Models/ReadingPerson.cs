using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Data.Models
{
    /// <summary>
    ///     2.1.1, 2.2.1
    /// </summary>
    public class ReadingPerson
    {
        public ReadingPerson()
        {
        }

        public ReadingPerson(Person person, Book book)
        {
            Person = person;
            Book = book;
        }

        [Required] public Person Person { get; set; }

        [Required] public Book Book { get; set; }
    }
}