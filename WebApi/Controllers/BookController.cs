

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BooksOperations.CreateBook;
using WebApi.BooksOperations.DeleteBook;
using WebApi.BooksOperations.GetBookDetail;
using WebApi.BooksOperations.GetBooks;
using WebApi.BooksOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BooksOperations.CreateBook.CreateBookComnd;
using static WebApi.BooksOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Controllers
{
    

    [Route("[controller]s")]// route ekliyoruz resource hangi endpointle nasıl erişeceğini gelen reqesti hangi resource karşılayacağı bilgisi


    [ApiController] //controllerimizin bir HTTP RESPOnse döneceğini nasıl söylüyorz apicontroller attribute ekliyoruz
    public class BookController : ControllerBase
    {
        private readonly BookStrDbContext _context;//KONSTRACTIR aracılığıyla BookStrDbContext erişebilirz 
        //uygulama içerisinde değiştirilemesin diye readonly yaptık
        public BookController(BookStrDbContext context)
        {
            _context = context; //private ı inject edilen instanca atadım
            
        }

        [HttpGet]
        //kitap listesini getirecek bir endpointe ihtiyac var
        public IActionResult GetBooks()
        {
            //GetBooksQuery query=new GetBooksQuery(_context);
            GetBooksQuery query=new GetBooksQuery(_context);
            var result= query.Handle();
            return Ok(result); 

        }
        
         [HttpGet("{id}")]
        public IActionResult GetBooksId(int id)
        {
            BookDetailViewMOdel result;
            try
            {
            GetBookDetailQuery query=new GetBookDetailQuery(_context);
            query.BookId=id;
            result=query.Handle();
            
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
            
            
            return Ok(result);

        }
        //from query ile id alma

        //  [HttpGet]
        // public Book Get([FromQuery] string id)
        // {
        //     var book=BookList.Where(book=>book.Id== Convert.ToInt32(id)).SingleOrDefault();
        //     return book;

        // }
        //post ile kitap ekleme yapılacak
        [HttpPost]
        public IActionResult Addbook([FromBody] CreateBookModel newbook)
        {
             CreateBookComnd createBookComnd=new CreateBookComnd(_context);
            try
            {
                createBookComnd.Handle();
                createBookComnd.Model=newbook;
            }
            catch (Exception ex)
            {
                
               return BadRequest(ex.Message);
            }
           
            
            return Ok();
        }
        
        //PUT işlemi
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel Updatedbook)//doşardan entity yani BOOK yerine updatebookmodel alcak
        {
            try
            {
            UpdateBookCommand command=new UpdateBookCommand(_context);
            command.BookId=id;
            command.Model=Updatedbook;
            command.Handle();
             
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
            _context.SaveChanges();
            return Ok();
           
        }
        [HttpDelete("{id}")] //ROUTE DAN ıd bilgisi almamaız lazım
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookQuery query=new DeleteBookQuery(_context);
                query.BookId=id;
                query.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            } 
            
            return Ok();

        }
    }
}