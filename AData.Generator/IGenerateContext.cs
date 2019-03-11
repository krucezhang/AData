using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator
{
    public interface IGenerateContext
    {
        Generator Generator { get; set; }

        Type ClassType { get; }

        Type MemberType { get; }

        string MemberName { get; }

        object Instance { get; }
    }
}
