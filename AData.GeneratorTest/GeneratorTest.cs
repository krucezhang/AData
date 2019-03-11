using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AData.DataGenerator;
using AData.GeneratorTest.Models;
using AData.DataGenerator.Sources;

namespace AData.GeneratorTest
{
    [TestClass]
    public class GeneratorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var generator = Generator.Create(c => c
                    .Entity<User>(e =>
                    {
                        e.AutoMap();

                        e.Property(p => p.Name).DataSource<NameSource>();
                    })
                 );

            var managers = generator.List<User>(10);

            foreach (User item in managers)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
