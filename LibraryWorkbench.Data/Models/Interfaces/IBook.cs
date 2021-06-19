namespace LibraryWorkbench.Data.Models
{
    /// <summary>
    ///     2.0
    /// </summary>
    public interface IBook
    {
        int BookId { get; set; }
        string Name { get; set; }
        Author Author { get; set; }
    }
}