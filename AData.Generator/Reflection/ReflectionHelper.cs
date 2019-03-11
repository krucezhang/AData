using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator.Reflection
{
    public static class ReflectionHelper
    {
        public static string ExtractPropertyName<TValue>(Expression<Func<TValue>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            return ExtractPropertyName(propertyExpression.Body as MemberExpression);
        }

        public static string ExtractPropertyName<TSource, TValue>(Expression<Func<TSource, TValue>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            return ExtractPropertyName(propertyExpression.Body as MemberExpression);
        }

        public static string ExtractPropertyName(MemberExpression memberExpression)
        {
            if (memberExpression == null)
                throw new ArgumentNullException(nameof(memberExpression));

            return memberExpression.Member.Name;
        }

        public static string ExtractColumnName<TValue>(Expression<Func<TValue>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            return ExtractColumnName(propertyExpression.Body as MemberExpression);
        }

        public static string ExtractColumnName<TSource, TValue>(Expression<Func<TSource, TValue>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            return ExtractColumnName(propertyExpression.Body as MemberExpression);
        }

        public static string ExtractColumnName(MemberExpression memberExpression)
        {
            var property = ExtractPropertyInfo(memberExpression);

            var column = property.GetCustomAttribute<System.ComponentModel.DataAnnotations.Schema.ColumnAttribute>();
            if (!string.IsNullOrEmpty(column?.Name))
                return column.Name;

            var display = property.GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>();
            if (!string.IsNullOrEmpty(display?.Name))
                return display.Name;

            return property.Name;
        }

        public static PropertyInfo ExtractPropertyInfo(MemberExpression memberExpression)
        {
            if (memberExpression == null)
                throw new ArgumentException("The expression is not a member access expression.", nameof(memberExpression));

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException("The member access expression does not access a property.", nameof(memberExpression));

            return property;
        }

        public static object CoerceValue(Type desiredType, Type valueType, object value)
        {
            if (desiredType == null)
                throw new ArgumentNullException(nameof(desiredType));

            if (valueType == null)
                throw new ArgumentNullException(nameof(valueType));

            // types match, just copy value
            if (desiredType.IsAssignableFrom(valueType))
                return value;

            bool isNullable = desiredType.GetTypeInfo().IsGenericType && (desiredType.GetGenericTypeDefinition() == typeof(Nullable<>));
            if (isNullable)
            {
                if (value == null)
                    return null;
                if (typeof(string) == valueType && Convert.ToString(value) == string.Empty)
                    return null;
            }

            desiredType = GetUnderlyingType(desiredType);

            if ((desiredType.GetTypeInfo().IsPrimitive || typeof(decimal) == desiredType)
                && typeof(string) == valueType
                && string.IsNullOrEmpty((string)value))
                return 0;

            if (value == null)
                return null;

            // types don't match, try to convert
            if (typeof(Guid) == desiredType)
                return new Guid(value.ToString());

            if (desiredType.GetTypeInfo().IsEnum && typeof(string) == valueType)
                return Enum.Parse(desiredType, value.ToString(), true);

            bool isBinary = desiredType.IsArray && typeof(byte[]) == desiredType;

            if (isBinary && typeof(string) == valueType)
            {
                byte[] bytes = Convert.FromBase64String((string)value);
                return bytes;
            }

            isBinary = valueType.IsArray && typeof(byte[]) == valueType;

            if (isBinary && typeof(string) == desiredType)
            {
                byte[] bytes = (byte[])value;
                return Convert.ToBase64String(bytes);
            }

            try
            {
                if (typeof(string) == desiredType)
                    return value.ToString();

                return Convert.ChangeType(value, desiredType);
            }
            catch
            {
                throw;
            }
        }

        public static Type GetUnderlyingType(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var t = type;
            var typeInfo = t.GetTypeInfo();

            bool isNullable = typeInfo.IsGenericType && (t.GetGenericTypeDefinition() == typeof(Nullable<>));
            if (isNullable)
                return Nullable.GetUnderlyingType(t);

            return t;
        }
    }
}
