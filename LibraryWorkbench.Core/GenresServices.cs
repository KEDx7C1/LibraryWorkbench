using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Core
{
    public class GenresServices
    {
        public static IEnumerable<DimGenre> GetGenres(DataContext context)
        {
            return context.DimGenres;
        }

        public static Object GetGenresStat(DataContext context)
        {
            var result = context.Books.SelectMany(g => g.Genres.Select(n => n.GenreName)).GroupBy(g => g, (n, c) => new
            {
                genreName = n,
                genreCount = c.Count()
            });
            return result;
        }

        public static void CreateGenre(DimGenre genre, DataContext context)
        {
            GenresRepository genres = new GenresRepository(context);
            if (!context.DimGenres.Any(x => x.GenreName.Equals(genre.GenreName)))
                genres.Create(genre);
            genres.Save();
        }
    }
}
