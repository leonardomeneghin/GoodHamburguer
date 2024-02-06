using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;

namespace GoodHamburguerAPI.Repository
{
    public interface IOrderRepository
    {
        public List<ProductDTO> GetProductTypes(List<Product> products);
    }
}
