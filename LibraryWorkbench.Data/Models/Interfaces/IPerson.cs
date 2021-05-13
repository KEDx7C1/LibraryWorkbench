using System;

namespace LibraryWorkbench.Data.Models
{
    /// <summary>
    /// 2.0
    /// </summary>
    public interface IPerson
    {
        int PersonId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        DateTime Birthday { get; set; }
    }
}
