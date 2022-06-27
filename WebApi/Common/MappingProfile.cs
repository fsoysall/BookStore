using AutoMapper;
using WebApi.Data;

namespace WebApi.Common
{

    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Book, BooksVM>().ForMember(d => d.Genre, o => o.MapFrom(s => ((eBookGenre)s.GenreId).ToString()));

        }

    }

}