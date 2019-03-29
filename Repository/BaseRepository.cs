using Data;
using Data.Model;
using Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _dbContext;
        private readonly IDbSet<T> _dbSet;

        public BaseRepository()
        {
            _dbContext = new DataContext();
            _dbSet = _dbContext.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetSingle(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            Commit();
        }

        public void Edit(T entity)
        {
            var item = _dbSet.Find(entity.Id);
            if (item == null)
            {
                return;
            }

            _dbContext.Entry(item).CurrentValues.SetValues(entity);
            Commit();
        }

        public void Delete(int id)
        {
            var item = _dbSet.Find(id);
            if (item == null)
            {
                return;
            }

            _dbContext.Entry(item).State = EntityState.Deleted;
            Commit();
        }

        public bool Commit()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
