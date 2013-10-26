using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCodeJewels.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        T Get(int id);

        void Add(T item);

        void Delete(int id);

        void Update(int id, T item);
    }
}
