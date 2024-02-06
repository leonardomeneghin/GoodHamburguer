using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Model.GoodHamburguer;

namespace GoodHamburguerAPI.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> ListAllExtrasOnly()
        {
            using (var context = new GoodHamburguerContext())
            {
                return (from p in context.TbProducts
                        join pt in context.TbItemTypes on p.IdItemType equals pt.IdItemType
                        where pt.ItemTypeName.Contains("soft drink") || pt.ItemTypeName.Contains("fries")
                        select new Product()
                        {
                            Id = p.IdProduct,
                            id_item_type = pt.IdItemType,
                            Name = p.Name,
                            Price = p.Price
                        }).ToList();
            }
        }

        public List<Product> ListAllSandwichesOnly()
        {
            using (var context = new GoodHamburguerContext())
            {
                return (from p in context.TbProducts
                        join pt in context.TbItemTypes on p.IdItemType equals pt.IdItemType
                        where pt.ItemTypeName.Contains("sandwich")
                        select new Product()
                        {
                            Id = p.IdProduct,
                            id_item_type = pt.IdItemType,
                            Name = p.Name,
                            Price = p.Price
                        }).ToList();
            }
        }
    }
}
