using AData.DataGenerator.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator.Builder
{
    public class ConfigurationBuilder
    {
        public ConfigurationBuilder(Configuration configuration)
        {
            Configuration = configuration;
        }

        public Configuration Configuration { get; }

        public ConfigurationBuilder Entity<TEntity>(Action<ClassMappingBuilder<TEntity>> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var type = typeof(TEntity);
            var classMapping = GetClassMap(type);

            var mappingBuilder = new ClassMappingBuilder<TEntity>(classMapping);
            builder(mappingBuilder);

            return this;
        }

        private ClassMapping GetClassMap(Type type)
        {
            var classMapping = Configuration.Mapping.GetOrAdd(type, t =>
            {
                var typeAccessor = TypeAccessor.GetAccessor(t);
                var mapping = new ClassMapping(typeAccessor);
                return mapping;
            });

            return classMapping;
        }
    }
}
