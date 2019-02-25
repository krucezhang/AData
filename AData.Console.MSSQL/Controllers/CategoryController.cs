using AData.Business.Interface;
using AData.Console.MSSQL.Toolkit;
using AData.MongoDB;
using AData.MongoDB.Models;
using DataGenerator;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AData.Console.MSSQL.Controllers
{
    public class CategoryController
    {
        private ICategoryAppSvc categoryAppSvc;

        public CategoryController()
        {
            using (var resolver = new DependencyResolver<MongoDbContext>())
            {
                this.categoryAppSvc = resolver.Resolve<ICategoryAppSvc>();
            }
        }

        public int Count
        {
            get
            {
                return this.categoryAppSvc.GetCount();
            }
        }

        public void Post()
        {
            var generator = Generator.Create(c =>
                c.Entity<Category>(e =>
                {
                    e.Property(p => p.Id).Value("");
                    e.Property(p => p.Name).DataSource<BookCategorySource>();
                })
            );

            var categories = generator.List<Category>(22);

            foreach (Category item in categories)
            {
                this.categoryAppSvc.Create(item);

                System.Console.WriteLine(JsonConvert.SerializeObject(item));
            }
        }

        public void GetAll()
        {
            var categories = this.categoryAppSvc.GetAll();

            foreach (Category item in categories)
            {
                System.Console.WriteLine(JsonConvert.SerializeObject(item));
            }
        }
    }
}
