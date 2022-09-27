using AutoMapper;
using WebApi.BooksOperations.GetBookDetail;
using WebApi.BooksOperations.GetBooks;
using static WebApi.BooksOperations.CreateBook.CreateBookComnd;

namespace WebApi.Common 
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel , Book>();  //createbook objesi book objesine maplanabilsin

            CreateMap<Book, BookDetailViewMOdel>().ForMember(dest => dest.Genre , opt=> opt.MapFrom(src =>((GenreEnum)src.GenreId).ToString()));
             CreateMap<Book , BooksViewModel>().ForMember(dest => dest.Genre , opt=> opt.MapFrom(src =>((GenreEnum)src.GenreId).ToString()));

        }
    }


}