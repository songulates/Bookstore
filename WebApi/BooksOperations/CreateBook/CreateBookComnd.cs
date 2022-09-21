
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BooksOperations.CreateBook
{
    //MODELE ihtiyacımız var,modeli dışardan setleyeceğiz,çünkü kullanıcıdan geiyo, geldiği noktada kontroller içinde 
    //CreateBookComnd içinde modeli setlemek lazımki buraya dolu gelsin
    
    public class CreateBookComnd
    {
        public CreateBookModel Model {get;set;}
        private readonly BookStrDbContext _dbContext;
        public CreateBookComnd(BookStrDbContext dbContext)
        {
            _dbContext=dbContext;

        }
        public void Handle()
        {
            var book=_dbContext.Books.SingleOrDefault(x=>x.Adi==Model.Adi);
            if(book is not null)
                throw new InvalidOperationException("kitap zaten var");
            book=new Book();//varsa bu kitap bad requet dön yoksa ekle add le
            book.Adi=Model.Adi;
            book.GenreId=Model.GenreId;
            book.PageCount=Model.GenreId;
            book.PublishDate=Model.PublishDate;
            _dbContext.Books.Add(book); //KİTAP LİSTENME ADDLE book eklenir
            _dbContext.SaveChanges(); //kaydolması için
        }
        //entity ile model ayrıştrılacak.Model yaratacağız vievmodel değil ama biz viev modeli UI a dönmek için kullandığımız ifade
          //model adında snıf oluşturcaz
          public class CreateBookModel
          {
            //bir kitap yaratak idtediğimizde neleri almamız gerekiyo
            public string Adi { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
          }

    }
}