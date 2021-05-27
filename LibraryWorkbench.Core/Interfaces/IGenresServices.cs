using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Core.Interfaces
{
    public interface IGenresServices
    {
        IEnumerable<DimGenreDTO> GetGenres();
        IEnumerable<GenresStatisticDTO> GetGenresStat();
        void CreateGenre(DimGenreDTO genre);
    }
}
