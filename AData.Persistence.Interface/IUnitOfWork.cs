using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;

namespace AData.Persistence.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsInTransaction { get; }

        void SaveChanges();

        void BeginTransaction();

        void BeginTransaction(IsolationLevel isolationLevel);

        void RollBackTransaction();

        void CommitTransaction();

        /// <summary>
        /// Execute the given DDL/DLL Command the database.
        /// </summary>
        /// <param name="sql">the command string</param>
        /// <param name="paramaters">the parameters to apply to the command string.</param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, params object[] paramaters);

        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
    }

    public interface IUnitOfWork<out TContext> : IUnitOfWork
    {
        TContext Context { get; }
    }
}
