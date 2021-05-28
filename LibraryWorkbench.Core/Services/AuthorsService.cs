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

namespace LibraryWorkbench.Core.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authors;
        private readonly IBooksRepository _books;
        private readonly IMapper _mapper;
        public AuthorsService(IAuthorsRepository authorsRepository, IBooksRepository booksRepository, IMapper mapper)
        {
            _authors = authorsRepository;
            _books = booksRepository;
            _mapper = mapper;
        }
        public IEnumerable<AuthorDTO> GetAuthors()
        {
            return _mapper.ProjectTo<AuthorDTO>(_authors.GetAll());
        }
        public AuthorWithBooksDTO GetBooksByAuthor(int authorId)
        {
            AuthorWithBooksDTO authorWithBooksDTO = new AuthorWithBooksDTO();
            authorWithBooksDTO.Author = _mapper.Map<AuthorDTO>(_authors.Get(authorId));
            authorWithBooksDTO.Books = _mapper.ProjectTo<BookWithoutAuthorDTO>(_books.GetAll().Where(x => x.AuthorId == authorId));
            return authorWithBooksDTO;
            
        }
        public AuthorWithBooksDTO CreateAuthorWithBooks(AuthorWithBooksDTO authorWithBooks)
        {
            AuthorDTO authorDto = authorWithBooks.Author;
            IEnumerable<Book> books = _mapper.ProjectTo<Book>(authorWithBooks.Books.AsQueryable());
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
                authorWithBooks.Author = _mapper.Map<AuthorDTO>(author);
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
        public IEnumerable<AuthorDTO> GetAuthorsByYear(int year, string order)
        {
            if (order.ToLower() != "desc" && order.ToLower() != "asc")
                order = "asc";
            IQueryable<Author> authors;
            switch (order.ToLower())
            {
                case "asc":
                    authors = _books.GetAll().Where(x => x.Year == year).Select(x => x.Author).OrderBy(a => a.LastName).Distinct();
                    break;
                case "desc":
                    authors = _books.GetAll().Where(x => x.Year == year).Select(x => x.Author).OrderByDescending(a => a.LastName).Distinct();
                    break;
                default:
                    authors = _books.GetAll().Where(x => x.Year == year).Select(x => x.Author).OrderBy(a => a.LastName).Distinct();
                    break;
            }
            return _mapper.ProjectTo<AuthorDTO>(authors);
        }
        public IEnumerable<AuthorDTO> GetAuthorsByBookNamepart(string namePart)
        {
            IQueryable<Author> authors = _books.GetAll().Where(x => x.Name.Contains(namePart)).Select(x => x.Author).Distinct();
            return _mapper.ProjectTo<AuthorDTO>(authors);
        }
        public void Dispose()
        {
            _authors.Dispose();
        }
    }
}
