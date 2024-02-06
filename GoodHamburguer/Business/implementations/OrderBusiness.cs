using GoodHamburguerAPI.Business.Rules.Discount;
using GoodHamburguerAPI.Business.Rules.Discount.Discount;
using GoodHamburguerAPI.Business.Rules.Discount.Discount.Interface;
using GoodHamburguerAPI.Business.Validators;
using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Repository;
using GoodHamburguerAPI.Repository.Implementation;

namespace GoodHamburguerAPI.Business.implementations
{
    public class OrderBusiness : IOrderBusiness
    {
        private IGenericRepository<Order> _repository;
        private IOrderRepository _orderRepository;
        private IDiscountApply _discount;
        private ProductValidator _productValidator;
        public OrderBusiness(IGenericRepository<Order> repository, IOrderRepository orderRepository)
        {
            _repository = repository;
            _orderRepository = orderRepository;
            _productValidator = new ProductValidator();
        }

        public List<Order> ListOrders()
        {
            return _repository.FindAll();
        }

        public ProductsWithDiscount MakeOrder(List<Product> products)
        {
            ProductsWithDiscount result;
            //Obter todos os tipos de produtos que o usuário colocou.
            var productsWithTypeList = _orderRepository.GetProductTypes(products);
            //Chamar o validator aqui
            _productValidator.Validate(products);
            //Verificar se aplica desconto
            var hasDrink = productsWithTypeList.Where(x => x.product_type_name.Contains("soft drink")).Select(p => p).Count();
            var hasFries = productsWithTypeList.Where(x => x.product_type_name.Contains("fries")).Select(p => p).Count();
            var hasSandwich = productsWithTypeList.Where(x => x.product_type_name.Contains("sandwich")).Select(p => p).Count();

            if (hasDrink >=1 && hasFries >=1 && hasSandwich >=1)
            {
                _discount = new Discount20();
                result = _discount.ApplyDiscount(products);
            } else if (hasDrink>=1 && hasSandwich >=1)
            {
                _discount = new Discount20();
                result = _discount.ApplyDiscount(products);
            } else if (hasFries >= 1 && hasSandwich >= 1)
            {
                _discount = new Discount10();
                result = _discount.ApplyDiscount(products);
            }
            else
            {
                result = new ProductsWithDiscount()
                {
                    Products = products,
                    DiscountApplyed = 0,
                    total_price = Convert.ToDecimal(products.Sum(x => x.Price))
                };
            }
            var order = new Order()
            {
                DateOrder = DateTime.Now,
                //DiscountApplyed = result.DiscountApplyed,
                TotalPrice = result.total_price
            };
            var orderEntity = _repository.Create(order);
            return result;
            
        }
    }
}
