using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Model.GoodHamburguer;

namespace GoodHamburguerAPI.Business.Rules.Discount.Discount.Interface
{
    public interface IDiscountApply
    {
        public ProductsWithDiscount ApplyDiscount(List<Product> products);
    }
}
