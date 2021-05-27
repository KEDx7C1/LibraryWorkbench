using LibraryWorkbench.Core.DTO;
using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace LibraryWorkbench
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>()
                .ForMember(x => x.FirstName, s => s.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, s => s.MapFrom(x => x.LastName))
                .ForMember(x => x.MiddleName, s => s.MapFrom(x => x.MiddleName))
                .ForMember(x => x.Birthday, s => s.MapFrom(x => x.Birthday));
            CreateMap<DimGenre, DimGenreDTO>()
                .ForMember(x => x.GenreName, s => s.MapFrom(x => x.GenreName));
            CreateMap<DimGenreDTO, DimGenre>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<Book, BookDTO>();
            CreateMap<Person, PersonExtDTO>();
            CreateMap<Author, AuthorWithBooksDTO>();
            CreateMap<BookWithoutAuthorDTO, Book>()
                .ForMember(x => x.Name, s => s.MapFrom(x => x.Name))
                .ForMember(x => x.Genres, s => s.MapFrom(x => x.Genres));
                //.ForMember(x => x.Author, s => s = null);
        }
    }
}
