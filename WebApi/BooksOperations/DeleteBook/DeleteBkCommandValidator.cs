using FluentValidation;

namespace WebApi.BooksOperations.DeleteBook
{
    public class DeleteBkCommandValidator:AbstractValidator<DeleteBookQuery> //CreateBookComnd sınıfı bookcommandı valide eder. validasyon klası olarak kullnıcak
    {
        public DeleteBkCommandValidator()
        {
            RuleFor(command=>command.BookId).GreaterThan(0);
        }

    }
}