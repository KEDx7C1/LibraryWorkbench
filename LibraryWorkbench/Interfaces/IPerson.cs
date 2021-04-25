using System;

namespace LibraryWorkbench.Interfaces
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
