using AutoMapper;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Core.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _books;
        private readonly IPersonsRepository _persons;
        private readonly IGenresRepository _genres;
        private readonly IAuthorsRepository _authors;
        private readonly IMapper _mapper;
        public BooksService(IBooksRepository booksRepository, IPersonsRepository personsRepository,
            IGenresRepository genresRepository, IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _books = booksRepository;
            _persons = personsRepository;
            _genres = genresRepository;
            _authors = authorsRepository;
            _mapper = mapper;
        }
        public BookDto CreateBook(BookDto bookDto)
        {
            Book book = _mapper.Map<Book>(bookDto);
            Author author = _authors.GetAll()
                .FirstOrDefault(x => x.FirstName.Equals(bookDto.Author.FirstName)
                && x.LastName.Equals(bookDto.Author.LastName) && (x.MiddleName.Equals(bookDto.Author.MiddleName)));
            if (author != null)
                book.Author = author;
            else
                book.Author = _mapper.Map<Author>(bookDto.Author);
            List<DimGenre> genres = new List<DimGenre>();
            foreach (var g in bookDto.Genres)
            {
                DimGenre genre = _genres.GetAll().FirstOrDefault(x => x.GenreName.Equals(g.GenreName));
                if (genre != null)
                {
                    genres.Add(genre);
                }
                else
                    genres.Add(new DimGenre()
                    {
                        GenreName = g.GenreName
                    });
            }
            book.Genres = genres;
            _books.Create(book);
            return _mapper.Map<BookDto>(book);
        }
        public BookDto GetBook(int id)
        {
            return _mapper.Map<BookDto>(_books.Get(id));
        }
        public IQueryable<BookDto> GetAllBooks()
        {
            return _mapper.ProjectTo<BookDto>(_books.GetAll());
        }
        public void DeleteBook(int id)
        {
            Book book = _books.Get(id);

            if (!_persons.GetAll().Any(x => x.Books.Contains(book)))
            {
                _books.Delete(id);
            }
            else throw new Exception($"Some person has books with id{id}");
        }
        public BookDto ChangeGanre(BookDto bookDto)
        {
            IQueryable<DimGenre> allGenres = _genres.GetAll();
            Book book = _books.Get(bookDto.BookId);
            List<DimGenre> genres = new List<DimGenre>();
            DimGenre genre = new DimGenre();
            foreach (var g in bookDto.Genres)
            {
                genre = allGenres.FirstOrDefault(x => x.GenreName.Equals(g.GenreName));
                if (genre == null)
                    genres.Add(new DimGenre() { GenreName = g.GenreName });
                else
                    genres.Add(genre);
            }

            book.Genres.RemoveAll(g => !bookDto.Genres.ToList()
                .Exists(gg => gg.GenreName.ToLower().Equals(g.GenreName.ToLower())));
            book.Genres.AddRange(genres.Where(g => !book.Genres
                .Any(x => x.GenreName.ToLower().Equals(g.GenreName.ToLower()))));

            _books.Update(book);
            return _mapper.Map<BookDto>(book);
        }
        public IQueryable<BookDto> GetBooksByAuthor(string firstName, string lastName, string middleName)
        {
            IQueryable<BookDto> authorBooks = _mapper.ProjectTo<BookDto>(_books.GetAll().AsQueryable()
                .Where(x => (x.Author.FirstName == firstName || firstName == null) &&
                (x.Author.LastName == lastName || lastName == null) &&
                (x.Author.MiddleName == middleName || middleName == null)));

            return authorBooks;
        }
        public IQueryable<BookDto> GetBooksByGenre(string genre)
        {
            IQueryable<BookDto> books = _mapper.ProjectTo<BookDto>(_books.GetAll()
                .AsQueryable().Where(x => x.Genres.Any(y => y.GenreName.Equals(genre))));
            return books;
        }
    }
}
