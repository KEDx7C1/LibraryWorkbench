using LibraryWorkbench.Core.DTO;
using System.Linq;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IGenresServices
    {
        IQueryable<DimGenreDto> GetAllGenres();
        IQueryable<GenresStatisticDto> GetGenresStat();
        void CreateGenre(DimGenreDto genre);
    }
}
