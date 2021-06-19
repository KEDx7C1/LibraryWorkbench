using System.Linq;
using LibraryWorkbench.Data.Models;

namespace LibraryWorkbench.Data
{
    public interface IGenresRepository
    {
        IQueryable<DimGenre> GetAll();
        DimGenre Get(int id);
        DimGenre Create(DimGenre genre);
        DimGenre Update(DimGenre genre);
        void Delete(int id);
    }
}