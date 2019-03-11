using AData.Common;
using AData.DataGenerator;
using AData.DataGenerator.Sources;
using System;

namespace AData.Console.MSSQL.Toolkit
{
    public class BookNameDataSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Name" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly string[] _attributes =
        {
            // Environ
            "數學", "线性", "IT", "探索", "一个月包教包会", "30分钟立见成效",
            // Stealth and cunning
            "JavaScript架构", "设计模式"
        };

        private static readonly string[] _objects =
        {
            "地理", "生物", "化学", "语文", "作文", "反射", "委托",
            "装箱拆箱"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="NameSource"/> class.
        /// </summary>
        public BookNameDataSource() : base(_types, _names)
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
            var a = _attributes[RandomGenerator.Current.Next(0, _attributes.Length)];
            var o = _objects[RandomGenerator.Current.Next(0, _objects.Length)];

            return $"{a} {o} 书";
        }
    }
}
