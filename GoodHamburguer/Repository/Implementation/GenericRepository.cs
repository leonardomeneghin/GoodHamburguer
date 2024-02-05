using GoodHamburguerAPI.Model;
using Infrastructure.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguerAPI.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        MSSQLContext _context;
        DbSet<T> _dataSet;
        public GenericRepository(MSSQLContext context)
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
            
            if (!Exists(entity.id)) return;

            var result = _dataSet.FirstOrDefault<T>(x => x.id.Equals(entity.id));
            if (result != null)
            {
                _dataSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _dataSet.Any(x=>x.id.Equals(id));
        }

        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(int id)
        {
            return _dataSet.FirstOrDefault(x => x.id.Equals(id));
        }

        public T Update(T entity)
        {
            if (!Exists(entity.id)) return null;

            var entityResult = _dataSet.FirstOrDefault(x => x.id.Equals(entity.id));
            _dataSet.Update(entityResult).CurrentValues.SetValues(entity);
            return entityResult;

        }
    }
}
