using AutoMapper;
using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Data.Models;

namespace LibraryWorkbench
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(x => x.PersonId, s => s.MapFrom(x => x.PersonId))
                .ForMember(x => x.FirstName, s => s.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, s => s.MapFrom(x => x.LastName))
                .ForMember(x => x.MiddleName, s => s.MapFrom(x => x.MiddleName))
                .ForMember(x => x.Birthday, s => s.MapFrom(x => x.Birthday));
            CreateMap<PersonDto, Person>()
                .ForMember(x => x.PersonId, s => s.MapFrom(x => x.PersonId))
                .ForMember(x => x.FirstName, s => s.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, s => s.MapFrom(x => x.LastName))
                .ForMember(x => x.MiddleName, s => s.MapFrom(x => x.MiddleName))
                .ForMember(x => x.Birthday, s => s.MapFrom(x => x.Birthday));
            CreateMap<DimGenre, DimGenreDto>()
                .ForMember(x => x.GenreId, s => s.MapFrom(x => x.GenreId))
                .ForMember(x => x.GenreName, s => s.MapFrom(x => x.GenreName));
            CreateMap<DimGenreDto, DimGenre>()
                .ForMember(x => x.GenreId, s => s.MapFrom(x => x.GenreId))
                .ForMember(x => x.GenreName, s => s.MapFrom(x => x.GenreName));
            CreateMap<Author, AuthorDto>()
                .ForMember(x => x.AuthorId, s => s.MapFrom(x => x.AuthorId))
                .ForMember(x => x.FirstName, s => s.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, s => s.MapFrom(x => x.LastName))
                .ForMember(x => x.MiddleName, s => s.MapFrom(x => x.MiddleName));
            CreateMap<AuthorDto, Author>()
                .ForMember(x => x.AuthorId, s => s.MapFrom(x => x.AuthorId))
                .ForMember(x => x.FirstName, s => s.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, s => s.MapFrom(x => x.LastName))
                .ForMember(x => x.MiddleName, s => s.MapFrom(x => x.MiddleName));
            CreateMap<Book, BookDto>()
                .ForMember(x => x.BookId, s => s.MapFrom(x => x.BookId))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Author, s => s.MapFrom(x => x.Author))
                .ForMember(x => x.Genres, s => s.MapFrom(x => x.Genres))
                .ForMember(x => x.Year, s => s.MapFrom(x => x.Year));
            CreateMap<BookDto, Book>()
                .ForMember(x => x.BookId, s => s.MapFrom(x => x.BookId))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Author, s => s.MapFrom(x => x.Author))
                .ForMember(x => x.Genres, s => s.MapFrom(x => x.Genres))
                .ForMember(x => x.Year, s => s.MapFrom(x => x.Year));
            CreateMap<Person, PersonExtDto>()
                .ForMember(x => x.PersonId, s => s.MapFrom(x => x.PersonId))
                .ForMember(x => x.FirstName, s => s.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, s => s.MapFrom(x => x.LastName))
                .ForMember(x => x.MiddleName, s => s.MapFrom(x => x.MiddleName))
                .ForMember(x => x.Birthday, s => s.MapFrom(x => x.Birthday))
                .ForMember(x => x.Books, s => s.MapFrom(x => x.Books));
            CreateMap<BookWithoutAuthorDto, Book>()
                .ForMember(x => x.BookId, s => s.MapFrom(x => x.BookId))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Genres, s => s.MapFrom(x => x.Genres));
            CreateMap<Book, BookWithoutAuthorDto>()
                .ForMember(x => x.BookId, s => s.MapFrom(x => x.BookId))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Genres, s => s.MapFrom(x => x.Genres));
        }
    }
}
