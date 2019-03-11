using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator.Reflection
{
    public interface IMemberAccessor : IMemberInfo
    {
        object GetValue(object instance);

        void SetValue(object instance, object value);
    }
}
