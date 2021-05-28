﻿using AutoMapper;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Http;
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
        public BookDTO CreateBook(BookDTO bookDto)
        {
            Book book = _mapper.Map<Book>(bookDto);
            Author author = _authors.GetAll().Where(x => x.FirstName.Equals(bookDto.Author.FirstName)
                && x.LastName.Equals(bookDto.Author.LastName) && (x.MiddleName.Equals(bookDto.Author.MiddleName)))
                .FirstOrDefault();
            if (author != null)
                book.Author = author;
            else
                book.Author = _mapper.Map<Author>(bookDto.Author);
            List<DimGenre> genres = new List<DimGenre>();
            foreach (var g in bookDto.Genres)
            {
                DimGenre genre = _genres.GetAll().Where(x => x.GenreName.Equals(g.GenreName)).FirstOrDefault();
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
            _books.Save();
            return _mapper.Map<BookDTO>(book);
        }
        public BookDTO GetBook(int id)
        {
            return _mapper.Map<BookDTO>(_books.Get(id));
        }
        public IEnumerable<BookDTO> GetAllBooks()
        {
            return _mapper.Map<IEnumerable<BookDTO>>(_books.GetAll());
        }
        public int DeleteBook(int id)
        {
            Book book;
            try
            {
                book = _books.Get(id);
            }
            catch
            {
                return StatusCodes.Status404NotFound;
            }

            if (!_persons.GetAll().Any(x => x.Books.Contains(book)))
            {
                _books.Delete(id);
                _books.Save();
                return StatusCodes.Status200OK;
            }
            else
                return StatusCodes.Status405MethodNotAllowed;
        }
        public BookDTO ChangeGanre(BookDTO bookDto)
        {
            IEnumerable<DimGenre> allGenres = _genres.GetAll();
            Book book = _books.Get(bookDto.BookId);
            List<DimGenre> genres = new List<DimGenre>();
            DimGenre tmp = new DimGenre();
            foreach (var g in bookDto.Genres)
            {
                tmp = allGenres.Where(x => x.GenreName.Equals(g.GenreName)).FirstOrDefault();
                if (tmp == null)
                    genres.Add(new DimGenre() { GenreName = g.GenreName });
                else
                    genres.Add(tmp);
            }
            
            book.Genres.RemoveAll(g => !bookDto.Genres.ToList().Exists(gg => gg.GenreName.ToLower().Equals(g.GenreName.ToLower())));
            book.Genres.AddRange(genres.Where(g => !book.Genres.Any(x=>x.GenreName.ToLower().Equals(g.GenreName.ToLower()))));

            _books.Update(book);
            _books.Save();
            return _mapper.Map<BookDTO>(_books.Get(book.BookId));
        }
        public IEnumerable<BookDTO> GetBooksByAuthor(string firstName, string lastName, string middleName)
        {

            IEnumerable<Book> books = _books.GetAll();
            IEnumerable <Book> authorBooks = books.Where(x => (x.Author.FirstName.Equals(firstName) || firstName == null) &&
                (x.Author.LastName.Equals(lastName) || lastName == null) &&
                (x.Author.MiddleName.Equals(middleName) || middleName == null));
            return _mapper.ProjectTo<BookDTO>(authorBooks.AsQueryable());
        }
        public IEnumerable<BookDTO> GetBooksByGenre(string genre)
        {
            IEnumerable <BookDTO> books = _mapper.ProjectTo<BookDTO>(_books.GetAll());
            return books.Where(x => x.Genres.Any(y => y.GenreName.Equals(genre)));
        }
        public void Dispose()
        {
            _books.Dispose();
        }
    }
}