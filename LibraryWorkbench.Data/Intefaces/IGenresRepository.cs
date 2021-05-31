using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
