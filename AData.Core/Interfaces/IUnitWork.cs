﻿using AData.SQLServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AData.Core.Interfaces
{
    public interface IUnitWork
    {
        T FindSingle<T>(Expression<Func<T, bool>> exp = null) where T : class;
        bool IsExist<T>(Expression<Func<T, bool>> exp) where T : class;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> exp = null) where T : class;

        int GetCount<T>(Expression<Func<T, bool>> exp = null) where T : class;

        void Add<T>(T entity) where T : Entity;

        void BatchAdd<T>(T[] entities) where T : Entity;

        /// <summary>
        /// 更新一个实体的所有属性
        /// </summary>
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        /// <summary>
        /// 按指定的ID进行批量更新
        /// </summary>
        void Update<T>(Expression<Func<T, object>> identityExp, T entity) where T : class;

        /// <summary>
        /// 实现按需要只更新部分更新
        /// <para>如：Update<T>(u =>u.Id==1,u =>new User{Name="ok"}) where T:class;</para>
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新后的实体</param>
        void Update<T>(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity) where T : class;
        /// <summary>
        /// 批量删除
        /// </summary>
        void Delete<T>(Expression<Func<T, bool>> exp) where T : class;

        void Save();


        int ExecuteSqlCommand(string sql, params object[] parameters);


        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        string ConnectionString { get; }
    }
}
