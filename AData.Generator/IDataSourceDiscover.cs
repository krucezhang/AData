using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator
{
    public interface IDataSourceDiscover : IDataSource
    {
        int Priority { get; }

        bool TryMap(IMappingContext mappingContext);
    }
}
