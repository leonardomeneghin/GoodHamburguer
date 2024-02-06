using GoodHamburguerAPI.Model;

namespace GoodHamburguerAPI.Business
{
    public interface IProductBusiness
    {
        public List<Product> ListAllMenuItems();
        public List<Product> ListSandwiches();
        public List<Product> ListExtras();
    }
}
