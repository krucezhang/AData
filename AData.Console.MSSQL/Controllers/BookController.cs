using AData.Business.Interface;
using AData.Console.MSSQL.Toolkit;
using AData.MongoDB.Models;
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
    public class BookController
    {
        private IBookAppSvc bookAppSvc;
        private ICategoryAppSvc categoryAppSvc;

        public BookController()
        {
            using (var resolver = new DependencyResolver<BooksDbContext>())
            {
                this.bookAppSvc = resolver.Resolve<IBookAppSvc>();
                this.categoryAppSvc = resolver.Resolve<ICategoryAppSvc>();
            }
        }

        public int Count
        {
            get
            {
                return this.bookAppSvc.GetCount();
            }
        }

        public void Post(int count)
        {
            var categories = this.categoryAppSvc.GetAll();
            var categoryNames = new List<string>();
            foreach (Category item in categories)
            {
                categoryNames.Add(item.Id);
            }

            var generator = Generator.Create(c =>
                c.Entity<Book>(e =>
                {
                    e.Property(p => p.Name).DataSource<BookNameDataSource>();
                    e.Property(p => p.Publisher).DataSource<PublisherSource>();
                    e.Property(p => p.Author).DataSource<LastNameSource>();
                    e.Property(p => p.Category).DataSource(categoryNames);
                    e.Property(p => p.RecordDate).DateTimeSource(new DateTime(1990, 1, 1), new DateTime(2019, 12, 12));
                })
            );

            var books = generator.List<Book>(count);

            foreach (Book book in books)
            {
                this.bookAppSvc.Create(book);

                System.Console.WriteLine(JsonConvert.SerializeObject(book));
            }
        }
    }
}
