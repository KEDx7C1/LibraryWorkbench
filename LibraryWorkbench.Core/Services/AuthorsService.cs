﻿using AutoMapper;
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
        private readonly IBooksService _bookService;
        public AuthorsService(IAuthorsRepository authorsRepository, IBooksRepository booksRepository, IMapper mapper, IBooksService bookService)
        {
            _authors = authorsRepository;
            _books = booksRepository;
            _mapper = mapper;
            _bookService = bookService;
        }
        public IQueryable<AuthorDto> GetAllAuthors()
        {
            return _mapper.ProjectTo<AuthorDto>(_authors.GetAll());
        }
        public AuthorWithBooksDto GetBooksByAuthor(int authorId)
        {
            AuthorWithBooksDto authorWithBooksDTO = new AuthorWithBooksDto
            {
                Author = _mapper.Map<AuthorDto>(_authors.Get(authorId)),
                Books = _mapper.ProjectTo<BookWithoutAuthorDto>(_books.GetAll().Where(x => x.AuthorId == authorId))
            };
            return authorWithBooksDTO;
            
        }
        public AuthorWithBooksDto CreateAuthorWithBooks(AuthorWithBooksDto authorWithBooks)
        {
            Author author = _mapper.Map<Author>(CreateAuthor(authorWithBooks.Author));
            if (authorWithBooks.Books != null)
            {
                IQueryable<Book> books = _mapper.ProjectTo<Book>(authorWithBooks.Books.AsQueryable());
                foreach (var b in books)
                {
                    b.Author = author;
                    _bookService.CreateBook(_mapper.Map<BookDto>(b));
                }
            }
            authorWithBooks.Author = _mapper.Map<AuthorDto>(author);
            authorWithBooks.Books = _bookService.GetBooksByAuthor(author.FirstName, author.LastName, author.MiddleName);
            return authorWithBooks;
        }
        public AuthorDto CreateAuthor(AuthorDto authorDto)
        {
            if (!_authors.GetAll().Any(x => x.FirstName == authorDto.FirstName
                && x.LastName == authorDto.LastName && x.MiddleName == authorDto.MiddleName))
            {
                Author author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    MiddleName = authorDto.MiddleName
                };
                ;
                return _mapper.Map<AuthorDto>(_authors.Create(author));
            }
            else
                throw new Exception("Author already exist");
        }
        public void DeleteAuthor(int authorId)
        {
            Author author = _authors.Get(authorId);
            if (author == null)
                throw new Exception($"Author with id{authorId} not found");
            if (_books.GetAll().Any(x => x.Author.Equals(author)))
                throw new Exception($"Author with id{authorId} have books");
            else
            {
                _authors.Delete(author.AuthorId);
            }
        }
        public IQueryable<AuthorDto> GetAuthorsByYear(int year, bool isOrderByDesc)
        {
            IQueryable<Author> authors;
            if (isOrderByDesc)
                authors = _books.GetAll().Where(x => x.Year == year).Select(x => x.Author).OrderByDescending(a => a.LastName).Distinct();
            else
                authors = _books.GetAll().Where(x => x.Year == year).Select(x => x.Author).OrderBy(a => a.LastName).Distinct();

            return _mapper.ProjectTo<AuthorDto>(authors);
        }
        public IQueryable<AuthorDto> GetAuthorsByBookNamepart(string namePart)
        {
            IQueryable<Author> authors = _books.GetAll().Where(x => x.Name.Contains(namePart)).Select(x => x.Author).Distinct();
            return _mapper.ProjectTo<AuthorDto>(authors);
        }
    }
}
