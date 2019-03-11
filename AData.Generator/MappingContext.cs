using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator
{
    public class MappingContext : IMappingContext
    {
        public ClassMapping ClassMapping { get; }

        public MemberMapping MemberMapping { get; }


        public MappingContext(ClassMapping classMapping, MemberMapping memberMapping)
        {
            ClassMapping = classMapping;
            MemberMapping = memberMapping;
        }
    }
}
