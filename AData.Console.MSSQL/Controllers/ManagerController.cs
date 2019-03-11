using AData.Business.Interface;
using AData.Console.MSSQL.Toolkit;
using AData.DataGenerator;
using AData.DataGenerator.Sources;
using AData.MongoDB;
using AData.Common.Extensions;
using AData.MongoDB.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AData.Console.MSSQL.Controllers
{
    public class ManagerController
    {
        private IManagersAppSvc managersAppSvc;

        public ManagerController()
        {
            using (var resolver = new DependencyResolver<MongoDbContext>())
            {
                this.managersAppSvc = resolver.Resolve<IManagersAppSvc>();
            }
        }

        public int Count
        {
            get
            {
                return this.managersAppSvc.GetCount();
            }
        }

        public void Post(int count)
        {
            var addressGenerator = Generator.Create(c =>
                c.Entity<AddressModel>(e =>
                {
                    e.Property(p => p.Province).DataSource<NameSource>();
                    e.Property(p => p.City).DataSource<CitySource>();
                    e.Property(p => p.StreetNo).DataSource<StreetSource>();
                })
            );

            var address = addressGenerator.List<AddressModel>(20);

            var generator = Generator.Create(c =>
                c.Entity<Managers>(e =>
                {
                    e.Property(p => p.Id).Value("");
                    e.Property(p => p.Name).DataSource<NameSource>();
                    e.Property(p => p.Age).IntegerSource(30, 60);
                    e.Property(p => p.Phone).DataSource<PhoneSource>();
                    e.Property(p => p.Address).DataSource(new[] { address.RandomList(2) });
                })
            );

            var managers = generator.List<Managers>(count);

            foreach (Managers item in managers)
            {
                this.managersAppSvc.Create(item);

                System.Console.WriteLine(JsonConvert.SerializeObject(item));
            }
        }
    }
}
