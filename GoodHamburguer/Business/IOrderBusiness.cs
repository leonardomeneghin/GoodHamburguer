using GoodHamburguerAPI.Data.VO;
using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;
using System.Data;
using System.Drawing;

namespace GoodHamburguerAPI.Business
{
    public interface IOrderBusiness
    {
        //List all orders
        public List<Order> ListOrders();
        public ProductsWithDiscount MakeOrder(List<ProductVO> products);
        public void RemoveOrder(Order order);
        public List<Product> Update(OrderVO order, List<ProductVO> products);
    }
}
