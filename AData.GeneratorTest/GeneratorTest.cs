using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AData.DataGenerator;
using AData.GeneratorTest.Models;

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

                        e.Property(p => p.)
                    })
                 );
        }
    }
}
