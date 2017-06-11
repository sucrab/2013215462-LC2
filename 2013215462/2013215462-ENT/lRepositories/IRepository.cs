using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT.lRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);


        TEntity Get(int? Id);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
