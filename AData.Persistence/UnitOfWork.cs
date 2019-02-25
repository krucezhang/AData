using AData.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace AData.Persistence
{
    public class UnitOfWork : IUnitOfWork<DbContext>
    {
        private DbTransaction _transaction;
        private DbContext _dbContext;
        private static int? sqlCommandTimeout;

        public UnitOfWork(DbContext context)
        {
            if (sqlCommandTimeout.HasValue)
            {
                ((IObjectContextAdapter)context).ObjectContext.CommandTimeout = sqlCommandTimeout.Value;
            }
            _dbContext = context;
        }

        static UnitOfWork()
        {
            sqlCommandTimeout = GetSqlCommandTimeout();
        }

        public bool IsInTransaction
        {
            get { return _transaction != null; }
        }

        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            if (_transaction != null)
            {
                throw new Exception("BeginTransaction ERROR");
            }
            OpenConnection();
            _transaction = ((IObjectContextAdapter)_dbContext).ObjectContext.Connection.BeginTransaction(isolationLevel);
        }

        public void RollBackTransaction()
        {
            if (_transaction == null)
            {
                throw new Exception("RollBackTransaction ERROR");
            }
            if (IsInTransaction)
            {
                try
                {
                    _transaction.Rollback();
                }
                finally
                {
                    ReleaseCurrentTransaction();
                }
            }
        }

        public void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new Exception("CommitTransaction ERROR");
            }

            ((IObjectContextAdapter)_dbContext).ObjectContext.SaveChanges();
            _transaction.Commit();
            ReleaseCurrentTransaction();
        }

        public void SaveChanges()
        {
            if (IsInTransaction)
            {
                throw new Exception("SaveChanges ERROR");
            }
            ((IObjectContextAdapter)_dbContext).ObjectContext.SaveChanges();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<TElement>(sql, parameters);
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes off the managed and unmanaged resources used.
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_dbContext != null)
                    {
                        _dbContext.Dispose();
                        _dbContext = null;
                    }
                }

                _disposed = true;
            }
        }

        private bool _disposed;
        #endregion

        public void OpenConnection()
        {
            switch (((IObjectContextAdapter)_dbContext).ObjectContext.Connection.State)
            {
                case ConnectionState.Broken:
                case ConnectionState.Closed:
                    ((IObjectContextAdapter)_dbContext).ObjectContext.Connection.Open();
                    break;
                case ConnectionState.Connecting:
                case ConnectionState.Executing:
                case ConnectionState.Fetching:
                case ConnectionState.Open:
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Release the current transaction
        /// </summary>
        private void ReleaseCurrentTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
            CloseConnection();
        }
        /// <summary>
        /// Close connection
        /// </summary>
        private void CloseConnection()
        {
            if (_dbContext != null)
            {
                var adapter = (IObjectContextAdapter)_dbContext;
                if (adapter != null && adapter.ObjectContext != null && adapter.ObjectContext.Connection != null)
                {
                    if (adapter.ObjectContext.Connection.State == ConnectionState.Open)
                    {
                        adapter.ObjectContext.Connection.Close();
                    }
                }
            }
        }

        public DbContext Context
        {
            get { return _dbContext; }
        }

        /// <summary>
        /// Get the timeout in seconds from sqlcommandtimeout application settings
        /// (Default 300 seconds)
        /// </summary>
        /// <returns></returns>
        private static int? GetSqlCommandTimeout()
        {
            return 300;
        }
    }
}
