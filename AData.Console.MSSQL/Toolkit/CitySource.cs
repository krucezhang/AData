using AData.Common;
using AData.DataGenerator;
using AData.DataGenerator.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.Console.MSSQL.Toolkit
{
    public class CitySource : DataSourceMatchName
    {
        private static readonly string[] _names = { "City" };
        private static readonly Type[] _types = { typeof(string) };
        private static readonly string[] _cities =
        {
            "东城区", "西城区", "崇文区", "宣武区", "朝阳区", "丰台区", "石景山区", "海淀区", "门头沟区", "房山区", "通州区", "顺义区", "昌平区", "大兴区", "怀柔区",
            "平谷区", "密云县", "延庆县", "延庆镇","西安市","延安市","铜川市","渭南市","咸阳市","宝鸡市","汉中市",
            "榆林市","安康市","商洛市"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CitySource"/> class.
        /// </summary>
        public CitySource() : base(_types, _names)
        {
        }

        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public override object NextValue(IGenerateContext generateContext)
        {
            var i = RandomGenerator.Current.Next(0, _cities.Length);
            return _cities[i];
        }
    }
}
