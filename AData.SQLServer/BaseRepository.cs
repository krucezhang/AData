using AData.Core.Interfaces;
using AData.SQLServer.Model;
using AData.SQLServer.Model.Models;
using EntityFramework.Extensions;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace AData.SQLServer
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected CakeInfosContext Context = new CakeInfosContext();


        /// <summary>
        /// 根据过滤条件，获取记录
        /// </summary>
        /// <param name="exp">The exp.</param>
        public IQueryable<T> Find(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp);
        }

        public bool IsExist(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Any(exp);
        }

        /// <summary>
        /// 查找单个
        /// </summary>
        public T FindSingle(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().AsNoTracking().FirstOrDefault(exp);
        }

        /// <summary>
        /// 根据过滤条件获取记录数
        /// </summary>
        public int GetCount(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp).Count();
        }

        public void Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            Context.Set<T>().Add(entity);
            Save();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void BatchAdd(T[] entities)
        {
            foreach (var entity in entities)
            {
                entity.Id = Guid.NewGuid();
            }
            Context.Set<T>().AddRange(entities);
            Save();
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            //todo:如果状态没有任何更改，会报错
            entry.State = EntityState.Modified;

            Save();
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Save();
        }

        /// <summary>
        /// 按指定id更新实体,会更新整个实体
        /// </summary>
        /// <param name="identityExp">The identity exp.</param>
        /// <param name="entity">The entity.</param>
        public void Update(Expression<Func<T, object>> identityExp, T entity)
        {
            Context.Set<T>().AddOrUpdate(identityExp, entity);
            Save();
        }

        /// <summary>
        /// 实现按需要只更新部分更新
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="entity">The entity.</param>
        public void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            Context.Set<T>().Where(where).Update(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> exp)
        {
            Context.Set<T>().Where(exp).Delete();
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw new Exception(e.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);
            }
        }

        private IQueryable<T> Filter(Expression<Func<T, bool>> exp)
        {
            var dbSet = Context.Set<T>().AsQueryable();
            if (exp != null)
                dbSet = dbSet.Where(exp);
            return dbSet;
        }
    }
}
