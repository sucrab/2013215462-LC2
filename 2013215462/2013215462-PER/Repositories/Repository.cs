using _2013215462_ENT.lRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace _2013215462_PER.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DiazDbContext _Context;

        public Repository(DiazDbContext _Context)
        {
            // TODO: Complete member initialization
            this._Context = _Context;
        }

        public Repository() { }


        public void add(TEntity entity)
        {
            _Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().AddRange(entities);
        }

        public TEntity Get(int? Id)
        {
            return _Context.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate);
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
