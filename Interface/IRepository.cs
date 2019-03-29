using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IRepository<T> where T : Entity
    {
        List<T> GetAll();
        T GetSingle(int id);
        void Insert(T entity);
        void Edit(T entity);
        void Delete(int id);
        bool Commit();
    }
}
