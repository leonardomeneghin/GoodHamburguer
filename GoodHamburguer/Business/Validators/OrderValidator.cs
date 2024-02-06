using FluentValidation;
using GoodHamburguerAPI.Model;

namespace GoodHamburguerAPI.Business.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        OrderValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
