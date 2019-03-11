using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator
{
    public class Configuration
    {
        private readonly ConcurrentDictionary<string, object> _cache;

        public Configuration()
        {
            _cache = new ConcurrentDictionary<string, object>();
            Mapping = new ConcurrentDictionary<Type, ClassMapping>();
            Assemblies = new AssemblyResolver();
            AutoMap = true;
        }

        public AssemblyResolver Assemblies { get; }

        public bool AutoMap { get; set; }

        public ConcurrentDictionary<Type, ClassMapping> Mapping { get; }

        public IEnumerable<IDataSourceDiscover> DataSources()
        {
            var dataSources = _cache.GetOrAdd("DataSource", k =>
            {
                var assemblies = Assemblies.Resolve().ToList();

                return assemblies
                    .SelectMany(GetTypesAssignableFrom<IDataSourceDiscover>)
                    .Select(CreateInstance)
                    .OfType<IDataSourceDiscover>()
                    .ToList();
            });

            return dataSources as IEnumerable<IDataSourceDiscover>;
        }

        public void ClearCache()
        {
            _cache.Clear();
        }

        private static object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }

    }
}
