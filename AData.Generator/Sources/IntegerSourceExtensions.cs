using AData.DataGenerator.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator.Sources
{
    public static class IntegerSourceExtensions
    {

        public static MemberConfigurationBuilder<TEntity, short> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, short> builder, short min, short max)
        {
            builder.DataSource(() => new IntegerSource(min, max));
            return builder;
        }

        public static MemberConfigurationBuilder<TEntity, int> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, int> builder, int min, int max)
        {
            builder.DataSource(() => new IntegerSource(min, max));
            return builder;
        }
        public static MemberConfigurationBuilder<TEntity, double> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, double> builder, int min, int max)
        {
            builder.DataSource(() => new IntegerSource(min, max));
            return builder;
        }


        public static MemberConfigurationBuilder<TEntity, decimal> IntegerSource<TEntity>(this MemberConfigurationBuilder<TEntity, decimal> builder, int min, int max)
        {
            builder.DataSource(() => new IntegerSource(min, max));
            return builder;
        }
    }
}
