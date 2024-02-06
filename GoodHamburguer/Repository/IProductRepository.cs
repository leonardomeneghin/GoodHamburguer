using GoodHamburguerAPI.Model;

namespace GoodHamburguerAPI.Repository
{
    public interface IProductRepository
    {
        public List<Product> ListAllExtrasOnly();
        public List<Product> ListAllSandwichesOnly();
    }
}
