using GoodHamburguerAPI.DTO;
using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Model.GoodHamburguer;
using System.Data;
using System.Drawing;

namespace GoodHamburguerAPI.Business
{
    public interface IOrderBusiness
    {
        //List all orders
        public List<Order> ListOrders();
        public ProductsWithDiscount MakeOrder(List<Product> products);
    }
}
