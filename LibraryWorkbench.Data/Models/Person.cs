using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryWorkbench.Data.Models
{
    /// <summary>
    ///     2.2.1, 2.2.2.Б
    /// </summary>
    public abstract class PersonShort : BasicEntity
    {
        [Required] [Column("first_name")] public string FirstName { get; set; }

        [Required] [Column("last_name")] public string LastName { get; set; }

        [Column("middle_name")] public string MiddleName { get; set; }
    }

    /// <summary>
    ///     2.0.2, 2.2.1
    /// </summary>
    public class Person : PersonShort, IPerson
    {
        public List<Book> Books { get; set; } = new List<Book>();

        [JsonIgnore] public List<LibraryCard> LibraryCards { get; set; } = new List<LibraryCard>();

        [Column("person_id")] public int PersonId { get; set; }

        [Column("birth_date")] public DateTime Birthday { get; set; }
    }
}