using GoodHamburguerAPI.Business.Rules.Discount.Discount.Interface;
using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;

namespace GoodHamburguerAPI.Business.Rules.Discount.Discount
{
    public class Discount20 : IDiscountApply
    {
        private decimal discountValue = 0.2m;
        public ProductsWithDiscount ApplyDiscount(List<Product> products)
        {
            foreach (var product in products)
            {
                product.Price = Convert.ToDecimal(product.Price * (1 - discountValue));
            }
            return new ProductsWithDiscount
            {
                Products = products,
                DiscountApplyed = discountValue
            };
        }
    }
}
