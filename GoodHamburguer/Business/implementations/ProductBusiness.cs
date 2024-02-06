using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Repository;
using GoodHamburguerAPI.Repository.Implementation;

namespace GoodHamburguerAPI.Business.implementations
{
    public class ProductBusiness : IProductBusiness
    {
        private IGenericRepository<Product> _repository;
        public ProductBusiness(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }
        public List<Product> ListAllMenuItems()
        {
            return _repository.FindAll();
        }

        public List<Product> ListExtras()
        {
            var items = _repository.FindAll();
            
            items.Where(x => x.id_item_type.Equals());
            

        }

        public List<Product> ListSandwiches()
        {
            throw new NotImplementedException();
        }
    }
}
