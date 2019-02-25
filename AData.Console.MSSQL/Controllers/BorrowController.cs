using AData.Business.Interface;
using AData.MySQL;
using AData.SQLServer.Models;
using DataGenerator;
using DataGenerator.Sources;
using System;
using System.Collections.Generic;
using AData.Common.Extensions;
using Newtonsoft.Json;

namespace AData.Console.MSSQL.Controllers
{
    public class BorrowController
    {
        private IBorrowAppSvc borrowAppSvc;
        private IStudentAppSvc studentAppSvc;
        private IBookAppSvc bookAppSvc;

        public BorrowController()
        {
            using (var resolver = new DependencyResolver<MySQLBookDbContext>())
            {
                this.borrowAppSvc = resolver.Resolve<IBorrowAppSvc>();
            }

            using (var resolver = new DependencyResolver<BooksDbContext>())
            {
                this.studentAppSvc = resolver.Resolve<IStudentAppSvc>();
                this.bookAppSvc = resolver.Resolve<IBookAppSvc>();
            }
        }

        public int Count
        {
            get
            {
                return this.borrowAppSvc.GetCount();
            }
        }

        public void Post(int count)
        {
            this.borrowAppSvc.Create(count);
        }
    }
}
