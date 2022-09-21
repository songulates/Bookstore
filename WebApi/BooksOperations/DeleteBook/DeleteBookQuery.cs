using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BooksOperations.DeleteBook
{
    public class DeleteBookQuery
    {

        private readonly BookStrDbContext _dbcontext;
         public int BookId {get;set;}
       
        public DeleteBookQuery(BookStrDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Handle()
        {
            var book=_dbcontext.Books.SingleOrDefault(x=>x.Id==BookId);// kıtap listemde olan bir kitap olup olmadığuna bakalım
            if(book is null)
               throw new InvalidOperationException("silinecek kitap yok");
            _dbcontext.Books.Remove(book);//listemde ktap varsa remove metodu ile sil
            _dbcontext.SaveChanges();
           
        }
       

    }
}