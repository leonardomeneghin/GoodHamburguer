using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;

namespace GoodHamburguerAPI.Business.Rules.Discount.Discount.Interface
{
    public interface IDiscountApply
    {
        public ProductsWithDiscount ApplyDiscount(List<Product> products);
    }
}
