using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Model.GoodHamburguer;

namespace GoodHamburguerAPI.Repository
{
    public interface IOrderRepository
    {
        public List<ProductDTO> GetProductTypes(List<Product> products);
    }
}
