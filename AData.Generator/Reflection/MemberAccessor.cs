using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator.Reflection
{
    public abstract class MemberAccessor : IMemberAccessor, IEquatable<IMemberAccessor>
    {
        public abstract Type MemberType { get; }

        public abstract MemberInfo MemberInfo { get; }

        public abstract string Name { get; }

        public abstract bool HasGetter { get; }

        public abstract bool HasSetter { get; }

        public abstract object GetValue(object instance);

        public abstract void SetValue(object instance, object value);

        public bool Equals(IMemberAccessor other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Equals(other.MemberInfo, MemberInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(MemberAccessor))
                return false;

            return Equals((MemberAccessor)obj);
        }

        public override int GetHashCode()
        {
            return MemberInfo.GetHashCode();
        }
    }
}
