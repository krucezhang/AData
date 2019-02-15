using AData.Core.Interfaces;
using AData.SQLServer.Model;
using AData.SQLServer.Model.Models;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace AData.SQLServer
{
    public class UnitWork : IUnitWork
    {
        protected CakeInfosContext Context = new CakeInfosContext();

        public string ConnectionString
        {
            get
            {
                if (Context != null)
                {
                    return Context.Database.Connection.ConnectionString;
                }

                return string.Empty;
            }
        }

        public bool IsExist<T>(Expression<Func<T, bool>> exp) where T : class
        {
            return Context.Set<T>().Any(exp);
        }

        /// <summary>
        /// 查找单个
        /// </summary>
        public T FindSingle<T>(Expression<Func<T, bool>> exp) where T : class
        {
            return Context.Set<T>().AsNoTracking().FirstOrDefault(exp);
        }

        /// <summary>
        /// 根据过滤条件获取记录数
        /// </summary>
        public int GetCount<T>(Expression<Func<T, bool>> exp = null) where T : class
        {
            return Filter(exp).Count();
        }

        public void Add<T>(T entity) where T : Entity
        {
            entity.Id = Guid.NewGuid();
            Context.Set<T>().Add(entity);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void BatchAdd<T>(T[] entities) where T : Entity
        {
            foreach (var entity in entities)
            {
                entity.Id = Guid.NewGuid();
            }
            Context.Set<T>().AddRange(entities);
        }

        public void Update<T>(T entity) where T : class
        {
            var entry = this.Context.Entry(entity);
            //todo:如果状态没有任何更改，会报错
            entry.State = EntityState.Modified;

        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// 按指定id更新实体,会更新整个实体
        /// </summary>
        /// <param name="identityExp">The identity exp.</param>
        /// <param name="entity">The entity.</param>
        public void Update<T>(Expression<Func<T, object>> identityExp, T entity) where T : class
        {
            Context.Set<T>().AddOrUpdate(identityExp, entity);
        }

        /// <summary>
        /// 实现按需要只更新部分更新
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="entity">The entity.</param>
        public void Update<T>(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity) where T : class
        {
            Context.Set<T>().Where(where).Update(entity);
        }

        public virtual void Delete<T>(Expression<Func<T, bool>> exp) where T : class
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

        private IQueryable<T> Filter<T>(Expression<Func<T, bool>> exp) where T : class
        {
            var dbSet = Context.Set<T>().AsQueryable();
            if (exp != null)
                dbSet = dbSet.Where(exp);
            return dbSet;
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return Context.Database.ExecuteSqlCommand(sql, parameters);
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return Context.Database.SqlQuery<TElement>(sql, parameters);
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> exp = null) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
