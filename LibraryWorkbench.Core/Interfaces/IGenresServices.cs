using System.Linq;
using LibraryWorkbench.Core.DTO;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IGenresServices
    {
        IQueryable<DimGenreDto> GetAllGenres();
        IQueryable<GenresStatisticDto> GetGenresStat();
        void CreateGenre(DimGenreDto genre);
    }
}