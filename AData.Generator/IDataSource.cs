using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator
{
    public interface IDataSource
    {
        object NextValue(IGenerateContext generateContext);
    }
}
