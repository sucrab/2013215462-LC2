using _2013215462_ENT.lRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2013215462_PER.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        void IRepository<TEntity>.add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.addRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.Get(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerator<TEntity> IRepository<TEntity>.Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.UpdateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
