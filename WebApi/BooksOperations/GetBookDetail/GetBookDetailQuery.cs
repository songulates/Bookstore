using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;
namespace WebApi.BooksOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStrDbContext _dbcontext;//sonra constructur ekledim
        private readonly IMapper _mapper;
        public int BookId {get;set;}
        public GetBookDetailQuery(BookStrDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewMOdel Handle()
        {
            var book=_dbcontext.Books.Where(book=>book.Id==BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("kitap bulunamadı");
            BookDetailViewMOdel vm=_mapper.Map<BookDetailViewMOdel>(book);//new BookDetailViewMOdel();
            // vm.Adi=book.Adi;
            // vm.PageCount=book.PageCount;
            // vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");
            // vm.Genre=((GenreEnum)book.GenreId).ToString();
            return vm;
        }
        //gerye book entity dönmemek için her bir UI VE VİEW İÇİN VİEWMODEL KULLAN

    }
    public class BookDetailViewMOdel
    {
        public string Adi { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}