using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
   
        //Initialize metot tanımlıyoruz verileri insert eden
        public static void Initialize(IServiceProvider serviceProvider) //program.cs baglayacagız uygulama ilk ayaga kalktıgında hep calısacak bir yapı serviceProvider sayesinde oluyor.
        {
            //CONTEXTE İhtiyaç var bilgi kaydetmek için contexte ihtiyaç var
            using (var context=new BookStrDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStrDbContext>>()))
            {
                if(context.Books.Any())// Books  içinde veri varsa calıstırmayacak
                {
                    return;//varsa çalıştırma
                }
                
                
                //Veri yoksa veri ekleme işlemi
                context.Books.AddRange(
                    new Book{Adi="Lean Startup", GenreId=1, AuthorId=1, PageCount=200, PublishDate=new DateTime(2001,06,12)},
                    new Book{Adi="HerLand", GenreId=2,AuthorId=2, PageCount=250, PublishDate=new DateTime(2001,06,12)},
                    new Book{Adi="Dune", GenreId=2, AuthorId=3, PageCount=540, PublishDate=new DateTime(2018,06,12)}
                );

                
                context.SaveChanges();// dbye yazılmasını saglıyoruz yani kaydetmeyi
            }    
        }
    }
}