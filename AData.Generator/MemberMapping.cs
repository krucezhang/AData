using AData.DataGenerator.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator
{
    public class MemberMapping
    {
        public bool Ignored { get; set; }

        public IMemberAccessor MemberAccessor { get; set; }

        public IDataSource DataSource { get; set; }
    }
}
