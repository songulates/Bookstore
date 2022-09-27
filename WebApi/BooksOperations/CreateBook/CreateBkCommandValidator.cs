using FluentValidation;

namespace WebApi.BooksOperations.CreateBook
{
    public class CreateBkCommandValidator:AbstractValidator<CreateBookComnd> //CreateBookComnd sınıfı bookcommandı valide eder. validasyon klası olarak kullnıcak
    {
        public CreateBkCommandValidator()
        {
            RuleFor(command=>command.Model.GenreId).GreaterThan(0);
            RuleFor(command=>command.Model.PageCount).GreaterThan(0);
            RuleFor(command=>command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command=>command.Model.Adi).NotEmpty().MinimumLength(4);
        }

    }
}