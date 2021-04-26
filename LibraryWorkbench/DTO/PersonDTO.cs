using LibraryWorkbench.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.DTO
{
    /// <summary>
    /// 2.2.1, 2.2.2.Б
    /// </summary>
    public abstract class Person : IEquatable<Person>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Patronym { get; set; }
        /// <summary>
        /// 2.1.4.
        /// </summary>
        public bool Equals(Person person)
        {
            if (ReferenceEquals(person, null)) return false;
            if (ReferenceEquals(this, person)) return true;
            return FirstName.Equals(person.FirstName) && LastName.Equals(person.LastName) && Patronym.Equals(person.Patronym);
        }
        public override int GetHashCode()
        {

            int hashFirstName = FirstName.GetHashCode();
            int hashLastName = LastName.GetHashCode();
            int hashPatronym = Patronym.GetHashCode();
            return hashFirstName ^ hashLastName ^ hashPatronym;
        }

        public Person()
        { }
    }
    /// <summary>
    /// 2.0.2, 2.2.1
    /// </summary>
    public class PersonDTO : Person, IPerson
    {
        [Required]
        public DateTime Birthday { get; set; }
        public PersonDTO()
        { }
    }
}
