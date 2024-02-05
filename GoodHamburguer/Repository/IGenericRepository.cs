using GoodHamburguerAPI.Model;

namespace GoodHamburguerAPI.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public T Create(T entity);
        public T Update(T entity);
        public T FindById(int id);
        void Delete(T entity);
        List<T> FindAll();
        bool Exists(int id);
    }
}
