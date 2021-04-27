using System;

namespace LibraryWorkbench.Data.Models.Interfaces
{
    /// <summary>
    /// 2.0
    /// </summary>
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Patronym { get; set; }
        DateTime Birthday { get; set; }
    }
}
