using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator.Reflection
{
    public class PropertyAccessor : MemberAccessor
    {
        private readonly PropertyInfo _propertyInfo;
        private readonly Lazy<Func<object, object>> _getter;
        private readonly Lazy<Action<object, object>> _setter;

        public override Type MemberType { get; }
        public override MemberInfo MemberInfo => _propertyInfo;
        public override string Name { get; }
        public override bool HasGetter { get; }
        public override bool HasSetter { get; }


        public PropertyAccessor(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                throw new ArgumentNullException(nameof(propertyInfo));

            _propertyInfo = propertyInfo;
            Name = _propertyInfo.Name;
            MemberType = _propertyInfo.PropertyType;

            HasGetter = _propertyInfo.CanRead;
            _getter = new Lazy<Func<object, object>>(() => DelegateFactory.CreateGet(_propertyInfo));

            HasSetter = _propertyInfo.CanWrite;
            _setter = new Lazy<Action<object, object>>(() => DelegateFactory.CreateSet(_propertyInfo));
        }

        public override object GetValue(object instance)
        {
            if (_getter == null || !HasGetter)
                throw new InvalidOperationException($"Property '{Name}' does not have a getter.");

            var get = _getter.Value;
            if (get == null)
                throw new InvalidOperationException($"Property '{Name}' does not have a getter.");

            return get(instance);
        }

        public override void SetValue(object instance, object value)
        {
            if (_setter == null || !HasSetter)
                throw new InvalidOperationException($"Property '{Name}' does not have a setter.");

            var set = _setter.Value;
            if (set == null)
                throw new InvalidOperationException($"Property '{Name}' does not have a setter.");

            set(instance, value);
        }

    }
}
