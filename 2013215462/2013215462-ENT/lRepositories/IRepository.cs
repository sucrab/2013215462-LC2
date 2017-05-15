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
        //C reates

        void add(TEntity entity);
        void addRange(IEnumerable<TEntity> entities);

        //R eads

        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        IEnumerator<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //U pdates

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);


        //D eletes

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
