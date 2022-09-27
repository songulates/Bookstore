
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;
namespace WebApi.BooksOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStrDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStrDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel>  Handle()//geriye bir bok listesi dönelim
        {
            var booklist=_dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
            //book listesini booksviewmodele dönüştürmem lazım, burdan gelen veriyi books viewmodelle dönmek istiyorum
            List<BooksViewModel> vm=_mapper.Map<List<BooksViewModel>>(booklist);
            //foreeach ile booklist içerisinde dönücez
            // foreach (var book in booklist)
            // {
            //     vm.Add(new BooksViewModel()
            //     {
            //      Adi=book.Adi,
            //      Genre=((GenreEnum)book.GenreId).ToString(),//genre stringdi
            //      PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy"),
            //      PageCount=book.PageCount
            //     });
            // }
            return vm; //geriye booklist yerine vm dönelim
        }
    }
     //UI a döneceim veri setini view model ile korumak istiyoruz.İstediğim veri tipinin her zaman UI a döndüğünden emin olmak istiyoruz
    //bunun için view model yapıcaz
    public class BooksViewModel
    {
        public string Adi { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }//kitap türü
       
    }
}