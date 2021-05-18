using AutoMapper;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Core.Interfaces;
using LibraryWorkbench.Data;
using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Core
{
    public class AuthorsService : IAuthorsService
    {
        private readonly DataContext _context;
        private readonly IAuthorsRepository _authors;
        private readonly IBooksRepository _books;
        private readonly IMapper _mapperAuthor;
        private readonly IMapper _mapperBook;
        private readonly IMapper _mapperBookWithoutAuthor;
        public AuthorsService(DataContext context)
        {
            _context = context;
            _authors = new AuthorsRepository(_context);
            _books = new BooksRepository(_context);
            _mapperAuthor = new MapperConfiguration(c => c.CreateMap<Author, AuthorDTO>()).CreateMapper();
            _mapperBook = new MapperConfiguration(c =>
            {
                c.CreateMap<Book, BookDTO>();
                c.CreateMap<Author, AuthorDTO>();
                c.CreateMap<DimGenre, DimGenreDTO>();
            }).CreateMapper();
            _mapperBookWithoutAuthor = new MapperConfiguration(c =>
            {
                c.CreateMap<Book, BookWithoutAuthorDTO>();
                c.CreateMap<DimGenre, DimGenreDTO>();
            }).CreateMapper();
        }
        public IEnumerable<AuthorDTO> GetAuthors()
        {
            return _mapperAuthor.Map<IEnumerable<AuthorDTO>>(_authors.GetAll());
        }
        public AuthorWithBooksDTO GetBooksByAuthor(AuthorDTO authorDto)
        {
            try
            {
                AuthorWithBooksDTO authorWithBooksDTO = new AuthorWithBooksDTO()
                {
                    Author = authorDto,
                    Books = _mapperBookWithoutAuthor.Map<List<BookWithoutAuthorDTO>>(_books.GetAll().Where(x=>x.AuthorId == authorDto.AuthorId))
                };
                return authorWithBooksDTO;
            }

            catch
            {
                throw new ArgumentException();
            }
        }
        public AuthorWithBooksDTO CreateAuthorWithBooks(AuthorWithBooksDTO authorWithBooks)
        {
            AuthorDTO authorDto = authorWithBooks.Author;
            IEnumerable<Book> books = _mapperBook.Map<IEnumerable<Book>>(authorWithBooks.Books);
            try
            {
                Author author = CreateAuthor(authorDto);
                if (books != null)
                    foreach (var b in books)
                    {
                        b.Author = author;
                        _books.Create(b);
                    }
                _books.Save();
                authorWithBooks.Author = _mapperAuthor.Map<AuthorDTO>(author);
                return authorWithBooks;
            }
            catch
            {
                return null;
            }
        }
        public Author CreateAuthor(AuthorDTO authorDto)
        {

            if (!_authors.GetAll().Any(x => x.FirstName.Equals(authorDto.FirstName)
                && x.LastName.Equals(authorDto.LastName) && x.MiddleName.Equals(authorDto.MiddleName)))
            {
                Author author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    MiddleName = authorDto.MiddleName
                };
                _authors.Create(author);

                _authors.Save();
                return author;
            }
            else
                return null;
        }
        public int DeleteAuthor(AuthorDTO authorDto)
        {
            Author author = _authors.Get(authorDto.AuthorId);
            if (author == null)
                return StatusCodes.Status404NotFound;
            if (_books.GetAll().Any(x => x.Author.Equals(author)))
                return StatusCodes.Status405MethodNotAllowed;
            else
            {
                _authors.Delete(author.AuthorId);
                _authors.Save();
                return StatusCodes.Status200OK;
            }
        }
        public IQueryable<AuthorDTO> GetAuthorsByYear(int year, string order)
        {
            if (order.ToLower() != "desc" && order.ToLower() != "asc")
                order = "asc";
            IQueryable<Author> authors;
            switch (order.ToLower())
            {
                case "asc":
                    authors = (IQueryable<Author>)_books.GetAll().Where(x => x.Year == year).Select(x => x.Author).OrderBy(a => a.LastName).Distinct();
                    break;
                case "desc":
                    authors = (IQueryable<Author>)_books.GetAll().Where(x => x.Year == year).Select(x => x.Author).OrderByDescending(a => a.LastName).Distinct();
                    break;
                default:
                    authors = (IQueryable<Author>)_books.GetAll().Where(x => x.Year == year).Select(x => x.Author).OrderBy(a => a.LastName).Distinct();
                    break;
            }
            return _mapperAuthor.Map<IQueryable<AuthorDTO>>(authors);
        }
        public IQueryable<AuthorDTO> GetAuthorsByBookNamepart(string namePart)
        {
            IQueryable<Author> authors = (IQueryable<Author>)_books.GetAll().Where(x => x.Name.Contains(namePart)).Select(x => x.Author).Distinct();
            return _mapperAuthor.Map<IQueryable<AuthorDTO>>(authors);
        }
        public void Dispose()
        {
            _authors.Dispose();
        }
    }
}
