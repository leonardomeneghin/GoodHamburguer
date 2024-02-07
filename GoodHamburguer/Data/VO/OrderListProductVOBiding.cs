using GoodHamburguerAPI.Model;

namespace GoodHamburguerAPI.Data.VO
{
    public class OrderListProductVOBiding
    {
        public OrderVO Order { get; set; }
        public List<ProductVO> products { get; set; }
    }
}
