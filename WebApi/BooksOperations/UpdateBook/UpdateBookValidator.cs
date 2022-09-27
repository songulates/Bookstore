using FluentValidation;
using WebApi.BooksOperations.GetBookDetail;
using WebApi.BooksOperations.UpdateBook;

namespace WebApi.BksOperations.UpdateBook
{
    public class UpdateBookValidator:AbstractValidator<UpdateBookCommand> //CreateBookComnd sınıfı bookcommandı valide eder. validasyon klası olarak kullnıcak
    {
        public UpdateBookValidator()
        {
            RuleFor(command=>command.BookId).GreaterThan(0);
            RuleFor(command=>command.Model.Adi).NotEmpty().MinimumLength(4);
            RuleFor(command=>command.Model.GenreId).GreaterThan(0);
            
        }

    }
}