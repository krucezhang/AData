using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator.Reflection
{
    public interface IMethodAccessor
    {
        MethodInfo MethodInfo { get; }

        string Name { get; }

        object Invoke(object instance, params object[] arguments);
    }
}
