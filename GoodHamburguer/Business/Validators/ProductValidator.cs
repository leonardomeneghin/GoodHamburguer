using FluentValidation;
using GoodHamburguerAPI.Model;

namespace GoodHamburguerAPI.Business.Validators
{
    public class ProductValidator : AbstractValidator<Order>
    {
        ProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

        }
    }
}
