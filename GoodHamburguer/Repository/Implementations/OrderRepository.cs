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
    }
}
