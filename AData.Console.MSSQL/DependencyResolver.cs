using AData.Business;
using AData.Business.Interface;
using AData.MongoDB.Models;
using AData.MySQL;
using AData.Persistence;
using AData.Persistence.Interface;
using AData.Persistence.Repositories;
using AData.SQLServer.Models;
using Microsoft.Practices.Unity;
using System;
using System.Data.Entity;

namespace AData.Console.MSSQL
{
    public class DependencyResolver<TEntity> : IDisposable where TEntity : DbContext, new()
    {
        private IUnityContainer container;

        public DependencyResolver()
        {
            container = new UnityContainer();

            container.RegisterType<DbContext, TEntity>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IRepository<Book>, BookRepository>();
            container.RegisterType<IRepository<Student>, StudentRepository>();
            container.RegisterType<IRepository<borrows>, BorrowRepository>();
            container.RegisterType<IRepository<returnbooks>, ReturnBookRepository>();
            container.RegisterType<IMongonDBRepository<Category>, CategoryRepository>();
            container.RegisterType<IMongonDBRepository<Managers>, ManagersRepository>();
            container.RegisterType<IMongonDBRepository<Tickets>, TicketsRepository>();

            container.RegisterType<IBookAppSvc, BookAppSvc>();
            container.RegisterType<IStudentAppSvc, StudentAppSvc>();
            container.RegisterType<IBorrowAppSvc, BorrowAppSvc>();
            container.RegisterType<IReturnBookAppSvc, ReturnBookAppSvc>();
            container.RegisterType<ICategoryAppSvc, CategoryAppSvc>();
            container.RegisterType<IManagersAppSvc, ManagerAppSvc>();
            container.RegisterType<ITicketsAppSvc, TicketsAppSvc>();
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public void Dispose()
        {
            if (container != null)
            {
                container.Dispose();
            }
        }
    }
}
