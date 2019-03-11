using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator
{
    public interface IMappingContext
    {
        ClassMapping ClassMapping { get; }

        MemberMapping MemberMapping { get; }

    }
}
