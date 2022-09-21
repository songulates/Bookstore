using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi
{
    public class Book //propertylerini  oluştur Book için neler var 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Auto Increment ID kolonunun eklenmesi
        public int Id { get; set; }
        public string Adi { get; set; }
        public int GenreId { get; set; }//kitap türü
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        //prop la hızlca property oluşturabilirsin
    }
}