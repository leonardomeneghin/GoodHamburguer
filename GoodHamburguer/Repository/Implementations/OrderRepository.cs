using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Repository.Implementation;

namespace GoodHamburguerAPI.Repository.Implementations
{
    public class OrderRepository : IOrderRepository
    {

        public List<ProductDTO> GetProductTypes(List<Product> products)
        {
            using(var context = new GoodHamburguerContext())
            {
                var filter = products.Select(x => x.Id).ToList();
                var entidades = (from p in context.Products
                                join tp in context.ItemTypes on p.IdItemType equals tp.Id
                                where filter.Contains(p.Id)
                                select new ProductDTO()
                                {
                                    Id = p.Id,
                                    IdItemType = p.IdItemType,
                                    Name = p.Name,
                                    Price = p.Price,
                                    product_type_name = tp.ItemTypeName
                                }).ToList();
                return entidades;
            }
        }

        public List<Product> Update(Order order, List<Product> products)
        {
            using var context = new GoodHamburguerContext();
            var allItemOrdered = (from i in context.ItemOrdereds
                                 where i.IdOrder.Equals(order.Id)
                                 select i).ToList();
            context.RemoveRange(allItemOrdered);
            var itemOrdered = (from prod in products
                               select new ItemOrdered() { IdOrder = order.Id, IdProduct = prod.Id }).ToList();
            context.AddRange(itemOrdered);

            var orderToUpdate = (from o in context.Orders
                                 where o.Id.Equals(order.Id)
                                 select o).FirstOrDefault();
            orderToUpdate.TotalPrice = Convert.ToDecimal(products.Sum(x => x.Price));
            orderToUpdate.DateOrder = DateTime.Now;
            orderToUpdate.DiscountApplyed = 0;
            context.Update(orderToUpdate);
            context.SaveChanges();
            return products;
        }
    }
}
