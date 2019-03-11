using AData.Business.Interface;
using AData.Console.MSSQL.Toolkit;
using AData.DataGenerator;
using AData.DataGenerator.Sources;
using AData.SQLServer.Models;
using Newtonsoft.Json;
using System;

namespace AData.Console.MSSQL.Controllers
{
    public class StudentController
    {
        private IStudentAppSvc studentAppSvc;
        private enum SexEnum
        {
            Male,
            Female
        }

        public StudentController()
        {
            using (var resolver = new DependencyResolver<BooksDbContext>())
            {
                this.studentAppSvc = resolver.Resolve<IStudentAppSvc>();
            }
        }

        public int Count
        {
            get
            {
                return this.studentAppSvc.GetCount();
            }
        }

        public void Post(int count)
        {
            var generator = Generator.Create(c => c
                .Entity<Student>(e =>
                {
                    e.Property(p => p.Name).DataSource<NameSource>();
                    e.Property(p => p.Sex).DataSource(Enum.GetNames(typeof(SexEnum)));
                    e.Property(p => p.Age).IntegerSource(18, 35);
                    e.Property(p => p.Profession).DataSource<ProfessionSource>();
                })
            );

            var students = generator.List<Student>(count);

            foreach (Student item in students)
            {
                this.studentAppSvc.Create(item);

                System.Console.WriteLine(JsonConvert.SerializeObject(item));
            }
        }

        public void GetAll()
        {
            var students = this.studentAppSvc.GetAll();

            foreach (Student item in students)
            {
                System.Console.WriteLine(JsonConvert.SerializeObject(item));
            }
        }

        public void GetCount()
        {

        }
    }

    
}
