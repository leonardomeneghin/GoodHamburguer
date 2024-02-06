using FluentValidation;
using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;
using Microsoft.AspNetCore.Localization;

namespace GoodHamburguerAPI.Business.Validators
{
    public class ProductValidator : AbstractValidator<List<Product>>
    {
        private IDictionary<string, int> sub_group_aggregation_item = new Dictionary<string, int>()
        {
            ["sandwich"] = 1,
            ["soft drink"] = 2,
            ["fries"] = 2
        };
        public ProductValidator()
        {
            
            RuleFor(x => x).NotEmpty();
            RuleFor(products => products)
                .Must(products => products.GroupBy(p => p.IdItemType)
                    .Any(g => g.Count() > 1))
            .WithMessage("You cannot put more than 1 item of each type");
            RuleFor(products => products)
                .Must(products => products.GroupBy(o => new { o.Name, o.Id }).Any(p => p.Count() > 1))
                .WithMessage("You cannot insert two identical items, please verify your order");


        }
    }
}
