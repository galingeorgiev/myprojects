namespace Schools.Tests.Fakes
{
    using Schools.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    class FakeRepository<T> : IRepository<T> where T : class
    {
        public IList<T> Entities = new List<T>();

        public void Add(T entity)
        {
            this.Entities.Add(entity);
        }
        public T Get(int id)
        {
            return this.Entities[id];
        }

        public IQueryable<T> All()
        {
            return this.Entities.AsQueryable();
        }

        public void Update(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Find(Expression<Func<T, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
