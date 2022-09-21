using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BooksOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStrDbContext _context;
        public int BookId {get;set;}
        public UpdateBookModel Model {get;set;}
        public UpdateBookCommand(BookStrDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book=_context.Books.SingleOrDefault(x=>x.Id==BookId);
            if(book is  null)
               throw new InvalidOperationException("Kitap Buunamadı");
            book.GenreId=Model.GenreId != default ? Model.GenreId:book.GenreId; //model.genreıd default değilse verisi varsa git uptadet book .genreidullan değilse kendi değerini kullan
            book.Adi=Model.Adi != default ? Model.Adi:book.Adi;
             _context.SaveChanges();
        }
        //model oluşturalım
        public class UpdateBookModel
        {
            public string Adi { get; set; }
            public int GenreId { get; set; }
        }
    }
}