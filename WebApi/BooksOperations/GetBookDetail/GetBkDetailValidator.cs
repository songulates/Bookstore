using FluentValidation;
using WebApi.BooksOperations.GetBookDetail;

namespace WebApi.BksOperations.GetBookDetail
{
    public class GetBkDetailValidator:AbstractValidator<GetBookDetailQuery> //CreateBookComnd sınıfı bookcommandı valide eder. validasyon klası olarak kullnıcak
    {
        public GetBkDetailValidator()
        {
            RuleFor(query=>query.BookId).GreaterThan(0);
            
        }

    }
}