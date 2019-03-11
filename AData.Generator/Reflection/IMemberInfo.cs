using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator.Reflection
{
    public interface IMemberInfo
    {
        Type MemberType { get; }

        MemberInfo MemberInfo { get; }

        string Name { get; }

        bool HasGetter { get; }

        bool HasSetter { get; }
    }
}
