using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryWorkbench.Data.Models
{
    public class LibraryCard
    {
        [Column("person_id")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Column("issue_date")]
        public DateTimeOffset IssueDate { get; set; }
    }
}
