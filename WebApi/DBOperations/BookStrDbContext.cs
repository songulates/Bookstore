namespace WebApi.DBOperations
{
   
    using Microsoft.EntityFrameworkCore;
    public class BookStrDbContext : DbContext //dbcontex yüklenen entity framework coredan geliyo bookstore dccontexden kalıtım alcak
    {
        //defaut contractor oluşturuyor optiob alıyo basede yani kalıtım aldığımız db contekten sınıfından gelen options
        public BookStrDbContext(DbContextOptions<BookStrDbContext> options): base(options) 
        {

        }
        //contexte book entitisini ekledik books ismi ile entitinin herşeyine erişebilirz
        public DbSet<Book> Books {get; set;} //dbcontexde kulanacağım entity veya model BOOK uygulamanın nesnesini books nesnesini kullanıcaz entty tekil isim çoğul
    //orm araçları databasedeki objelerle koddaki nesneer arasında köprü kuruyor
    
    }


}