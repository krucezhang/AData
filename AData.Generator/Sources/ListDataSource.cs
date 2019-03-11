using AData.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator.Sources
{
    public class ListDataSource<T> : IDataSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListDataSource{T}"/> class.
        /// </summary>
        /// <param name="items">The items to generate from.</param>
        public ListDataSource(IEnumerable<T> items)
        {
            Items = new List<T>(items);
        }


        public List<T> Items { get; }


        public Func<T, int> WeightSelector { get; set; }



        public object NextValue(IGenerateContext generateContext)
        {
            if (Items == null || Items.Count == 0)
                return default(T);


            return Items.Random(WeightSelector);
        }
    }
}
