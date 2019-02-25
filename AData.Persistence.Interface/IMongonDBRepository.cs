using AData.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AData.Persistence.Interface
{
    public interface IMongonDBRepository<TEntity>: IDisposable where TEntity : Entity
    {
        TEntity GetById(string id);

        int Count();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

        TEntity Save(TEntity entity);

        void Delete(string id);
    }
}
