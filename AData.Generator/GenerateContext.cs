using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator
{
    public class GenerateContext : IGenerateContext
    {
        public Generator Generator { get; set; }

        public Type ClassType { get; set; }

        public Type MemberType { get; set; }

        public string MemberName { get; set; }

        public object Instance { get; set; }
    }
}
