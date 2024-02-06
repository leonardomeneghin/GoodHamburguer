using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Repository;
using GoodHamburguerAPI.Repository.Implementation;

namespace GoodHamburguerAPI.Business.implementations
{
    public class ProductBusiness : IProductBusiness
    {
        private IGenericRepository<Product> _repository;
        private IProductRepository _productRepository;
        public ProductBusiness(IGenericRepository<Product> repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }
        public List<Product> ListAllMenuItems()
        {
            return _repository.FindAll();
        }

        public List<Product> ListExtras()
        {
            return _productRepository.ListAllExtrasOnly();           

        }

        public List<Product> ListSandwiches()
        {
            return _productRepository.ListAllSandwichesOnly();
        }
    }
}
