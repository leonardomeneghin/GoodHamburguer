using GoodHamburguerAPI.Business.Rules.Discount.Discount;
using GoodHamburguerAPI.Business.Rules.Discount.Discount.Interface;
using GoodHamburguerAPI.Data.VO;
using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Repository;
using System.Drawing;

namespace GoodHamburguerAPI.Business.implementations
{
    public class OrderBusiness : IOrderBusiness
    {
        private IGenericRepository<Order> _repository;
        private IGenericRepository<Product> _repositoryProduct;
        private IGenericRepository<ItemOrdered> _repositoryItemOrdered;
        private IOrderRepository _orderRepository;
        private IDiscountApply _discount;
        //Bloater alert, should add some DTO with all generic repositories.
        public OrderBusiness(IGenericRepository<Order> repository, 
                            IOrderRepository orderRepository, 
                            IGenericRepository<Product> repositoryProduct,
                            IGenericRepository<ItemOrdered> repositoryItemOrdered)
        {
            _repository = repository;
            _orderRepository = orderRepository;
            _repositoryItemOrdered = repositoryItemOrdered;
            _repositoryProduct = repositoryProduct;
        }

        public List<Order> ListOrders()
        {
            return _repository.FindAll();
        }

        public ProductsWithDiscount MakeOrder(List<ProductVO> productsVO)
        {
            var products = ConvertVOToModel(productsVO);

            var  allProducts = _repositoryProduct.FindAll();
            //Na lista inserida
            //Buscar se o registro não existe. Se não existir, informar.

            ProductsWithDiscount result;
            //Obter todos os tipos de produtos que o usuário colocou.
            var productsWithTypeList = _orderRepository.GetProductTypes(products);

            //Verificar duplicados
            var repetidos = products .GroupBy(x => x.Id)
                 .Where(g => g.Count() > 1)
                 .Select(g => g.Key)
                 .ToList();
            if (repetidos.Count() > 0)
                throw new Exception("Have dubled itens, please verify your order");
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
                DiscountApplyed = result.DiscountApplyed,
                TotalPrice = result.total_price
            };
            var orderEntity = _repository.Create(order);
            //Foreach item we should add the item ordered
            //Assume that idProduct is correct because of menu controller.
            result.Products.ForEach(entity => 
            {
                _repositoryItemOrdered.Create(new ItemOrdered() 
                { 
                    IdOrder = orderEntity.Id,
                    IdProduct = entity.Id
                });
            });
          
            return result;
            
        }

        public void RemoveOrder(Order order)
        {
            var getOrderedItems = _repositoryItemOrdered.FindAll().Where(x => x.IdOrder.Equals(order.Id)).Select(p => p).ToList();
            foreach (var entity in getOrderedItems)
            {
                _repositoryItemOrdered.Delete(entity);
            }
            
            _repository.Delete(order);
            
        }

        public List<Product> Update(OrderVO order, List<ProductVO> products)
        {
            var productModels = ConvertVOToModel(products);
            return _orderRepository.Update(new Order() { Id = order.Id }, productModels);
            
        }

        private List<Product> ConvertVOToModel(List<ProductVO> products)
        {
            List<Product> productModel = new List<Product>();
            foreach (var item in products)
            {
                productModel.Add(new Product()
                {
                Id = item.Id,
                IdItemType = item.IdItemType,
                Name = item.Name,
                Price = item.Price
                });

            }
            return productModel;
        }
    }
}
