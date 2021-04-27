using LibraryWorkbench.Data.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWorkbench.Data.Models
{
    /// <summary>
    /// 2.2.1, 2.2.2.Б
    /// </summary>
    public abstract class PersonShort : IEquatable<PersonShort>
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
        public bool Equals(PersonShort person)
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

        public PersonShort()
        { }
    }
    /// <summary>
    /// 2.0.2, 2.2.1
    /// </summary>
    public class Person : PersonShort, IPerson
    {
        [Required]
        public DateTime Birthday { get; set; }
        public Person()
        { }
    }
}
