using LibraryWorkbench.Data.Models.Interfaces;
using LibraryWorkbench.Data.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWorkbench.Core.Results
{
    public class RemoveBooks
    {
        public static async Task<int> RemoveBook(string author, string title, IBooksRepository books)
        {
            IBook book = await books.GetBookByAuthorAndTitleAsync(author, title);
            if (book != null)
            {
                await books.RemoveBookAsync(book);
                return StatusCodes.Status200OK;
            }
            else return StatusCodes.Status404NotFound;
        }
    }
}
