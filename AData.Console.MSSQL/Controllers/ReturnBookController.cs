using AData.Business.Interface;
using AData.MySQL;
using AData.SQLServer.Models;
using DataGenerator;
using DataGenerator.Sources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.Console.MSSQL.Controllers
{
    public class ReturnBookController
    {
        private IReturnBookAppSvc returnBookAppSvc;
        private IStudentAppSvc studentAppSvc;
        private IBookAppSvc bookAppSvc;

        public ReturnBookController()
        {
            using (var resolver = new DependencyResolver<MySQLBookDbContext>())
            {
                this.returnBookAppSvc = resolver.Resolve<IReturnBookAppSvc>();
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
                return this.returnBookAppSvc.GetCount();
            }
        }

        public void Post(int count)
        {
            var studentIds = this.GetStudentIds();
            var bookIds = this.GetBookIds();

            var expectRetutrnDays = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            var generator = Generator.Create(c =>
                c.Entity<returnbooks>(e =>
                {
                    e.Property(p => p.BookId).DataSource(bookIds);
                    e.Property(p => p.StudentId).DataSource(studentIds);
                    e.Property(p => p.ReturnDate).DateTimeSource(new DateTime(2018, 10, 1), new DateTime(2019, 12, 12));
                })
            );

            var returnbookRecords = generator.List<returnbooks>(count);
            foreach (returnbooks item in returnbookRecords)
            {
                this.returnBookAppSvc.Create(item);
                System.Console.WriteLine(JsonConvert.SerializeObject(item));
            }
        }

        private List<string> GetStudentIds()
        {
            var students = this.studentAppSvc.GetAll();
            var studentIds = new List<string>();
            foreach (Student item in students)
            {
                studentIds.Add(item.Id);
            }

            return studentIds;
        }

        private List<string> GetBookIds()
        {
            var books = this.bookAppSvc.GetAll();
            var bookIds = new List<string>();
            foreach (Book item in books)
            {
                bookIds.Add(item.Id);
            }

            return bookIds;
        }
    }
}
