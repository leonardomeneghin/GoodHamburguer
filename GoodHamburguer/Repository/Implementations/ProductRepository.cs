using GoodHamburguerAPI.Model;

namespace GoodHamburguerAPI.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> ListAllExtrasOnly()
        {
            using (var context = new GoodHamburguerContext())
            {
                return (from p in context.Products
                        join pt in context.ItemTypes on p.IdItemType equals pt.Id
                        where pt.ItemTypeName.Contains("soft drink") || pt.ItemTypeName.Contains("fries")
                        select new Product()
                        {
                            Id = p.Id,
                            IdItemType = pt.Id,
                            Name = p.Name,
                            Price = p.Price
                        }).ToList();
            }
        }

        public List<Product> ListAllSandwichesOnly()
        {
            using (var context = new GoodHamburguerContext())
            {
                return (from p in context.Products
                        join pt in context.ItemTypes on p.IdItemType equals pt.Id
                        where pt.ItemTypeName.Contains("sandwich")
                        select new Product()
                        {
                            Id = p.Id,
                            IdItemType = pt.Id,
                            Name = p.Name,
                            Price = p.Price
                        }).ToList();
            }
        }
    }
}
