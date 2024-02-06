using GoodHamburguerAPI.Model;
using GoodHamburguerAPI.Model.GoodHamburguer;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguerAPI.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        GoodHamburguerContext _context;
        DbSet<T> _dataSet;
        public GenericRepository(GoodHamburguerContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }  
        public T Create(T entity)
        {
            _dataSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            
            if (!Exists(entity.Id)) return;

            var result = _dataSet.FirstOrDefault<T>(x => x.Id.Equals(entity.Id));
            if (result != null)
            {
                _dataSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _dataSet.Any(x=>x.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(int id)
        {
            return _dataSet.FirstOrDefault(x => x.Id.Equals(id));
        }

        public T Update(T entity)
        {
            if (!Exists(entity.Id)) return null;

            var entityResult = _dataSet.FirstOrDefault(x => x.Id.Equals(entity.Id));
            _dataSet.Update(entityResult).CurrentValues.SetValues(entity);
            return entityResult;

        }
    }
}
