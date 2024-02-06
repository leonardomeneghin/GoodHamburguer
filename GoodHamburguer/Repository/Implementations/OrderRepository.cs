using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Model.GoodHamburguer;
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
                var entidades = (from p in context.TbProducts
                                join tp in context.TbItemTypes on p.IdItemType equals tp.IdItemType
                                where filter.Contains(p.IdProduct)
                                select new ProductDTO()
                                {
                                    Id = p.IdProduct,
                                    id_item_type = p.IdItemType,
                                    Name = p.Name,
                                    Price = p.Price,
                                    product_type_name = tp.ItemTypeName
                                }).ToList();
                return entidades;
            }
        }
    }
}
