using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator.Reflection
{
    internal static class DelegateFactory
    {
        public static Func<object, object[], object> CreateMethod(MethodInfo methodInfo)
        {
            return DynamicMethodFactory.CreateMethod(methodInfo);
        }

        public static Func<object> CreateConstructor(Type type)
        {
            return DynamicMethodFactory.CreateConstructor(type);
        }

        public static Func<object, object> CreateGet(PropertyInfo propertyInfo)
        {
            return DynamicMethodFactory.CreateGet(propertyInfo);
        }

        public static Func<object, object> CreateGet(FieldInfo fieldInfo)
        {
            return DynamicMethodFactory.CreateGet(fieldInfo);
        }

        public static Action<object, object> CreateSet(PropertyInfo propertyInfo)
        {
            return DynamicMethodFactory.CreateSet(propertyInfo);
        }

        public static Action<object, object> CreateSet(FieldInfo fieldInfo)
        {
            return DynamicMethodFactory.CreateSet(fieldInfo);
        }
    }
}
