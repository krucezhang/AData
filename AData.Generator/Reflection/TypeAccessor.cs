using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AData.DataGenerator.Reflection
{
    public class TypeAccessor
    {
        private static readonly ConcurrentDictionary<Type, TypeAccessor> _typeCache = new ConcurrentDictionary<Type, TypeAccessor>();
        private readonly ConcurrentDictionary<string, IMemberAccessor> _memberCache = new ConcurrentDictionary<string, IMemberAccessor>();
        private readonly ConcurrentDictionary<int, IMethodAccessor> _methodCache = new ConcurrentDictionary<int, IMethodAccessor>();
        private readonly ConcurrentDictionary<int, IEnumerable<IMemberAccessor>> _propertyCache = new ConcurrentDictionary<int, IEnumerable<IMemberAccessor>>();

        private readonly Lazy<Func<object>> _constructor;

        public Type Type { get; }

        public TypeAccessor(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            Type = type;
            _constructor = new Lazy<Func<object>>(() => DelegateFactory.CreateConstructor(Type));
        }

        public static TypeAccessor GetAccessor<T>()
        {
            return GetAccessor(typeof(T));
        }
        public IMemberAccessor FindProperty<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            return FindProperty(propertyExpression.Body as MemberExpression);
        }

        private IMemberAccessor FindProperty(MemberExpression memberExpression)
        {
            if (memberExpression == null)
                throw new ArgumentException("The expression is not a member access expression.", nameof(memberExpression));

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException("The member access expression does not access a property.", nameof(memberExpression));

            var getMethod = property.GetGetMethod(true);
            if (getMethod.IsStatic)
                throw new ArgumentException("The referenced property is a static property.", nameof(memberExpression));

            var accessor = CreateAccessor(property);
            return accessor;
        }

        public static TypeAccessor GetAccessor(Type type)
        {
            return _typeCache.GetOrAdd(type, t => new TypeAccessor(t));
        }

        public IEnumerable<IMemberAccessor> GetProperties()
        {
            return GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        }

        public IEnumerable<IMemberAccessor> GetProperties(BindingFlags flags)
        {
            return _propertyCache.GetOrAdd((int)flags, k =>
            {
                var typeInfo = Type.GetTypeInfo();
                var properties = typeInfo.GetProperties(flags);
                return properties.Select(GetAccessor);
            });
        }

        public IMemberAccessor GetAccessor(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                throw new ArgumentNullException(nameof(propertyInfo));

            return _memberCache.GetOrAdd(propertyInfo.Name, n => CreateAccessor(propertyInfo));
        }

        private static IMemberAccessor CreateAccessor(PropertyInfo propertyInfo)
        {
            return propertyInfo == null ? null : new PropertyAccessor(propertyInfo);
        }

        public object Create()
        {
            var constructor = _constructor.Value;
            if (constructor == null)
                throw new InvalidOperationException($"Could not find constructor for '{Type.Name}'.");

            return constructor.Invoke();
        }
    }
}
