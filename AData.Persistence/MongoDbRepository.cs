using AData.MongoDB;
using AData.Persistence.Interface;
using Microsoft.Practices.Unity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AData.Persistence
{
    public abstract class MongoDbRepository<TEntity> : IMongonDBRepository<TEntity> where TEntity : Entity
    {
        private bool disposed = false;

        [Dependency]
        public MongoDbContext DbContext { get; set; }
        

        protected IMongoCollection<TEntity> Collection {
            get
            {
                return DbContext.Collection<TEntity>();
            }
        }

        public TEntity GetById(string id)
        {
            return Collection.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync().Result;
        }

        public int Count()
        {
            return (int)Collection.CountDocuments(new BsonDocument());
        }

        public TEntity Save(TEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
            }

            Collection.ReplaceOneAsync(
                x => x.Id.Equals(entity.Id),

                entity,
                new UpdateOptions
                {
                    IsUpsert = true
                });

            return entity;
        }

        public void Delete(string id)
        {
            Collection.DeleteOneAsync(x => x.Id.Equals(id));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Collection.Find(new BsonDocument()).ToListAsync().Result;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.Find(predicate).ToListAsync().Result;
        }

        #region IDisposible

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (this.DbContext != null)
                    {
                        this.DbContext.Dispose();
                        this.DbContext = null;
                    }
                }
                disposed = true;
            }
        }

        ~MongoDbRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}
