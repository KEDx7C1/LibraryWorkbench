using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWorkbench.Data
{
    public interface IGenresRepository : IDisposable
    {
        IQueryable<DimGenre> GetAll();
        DimGenre Get(int id);
        void Create(DimGenre genre);
        void Update(DimGenre genre);
        void Delete(int id);
        void Save();
    }
}
