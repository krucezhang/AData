using AData.Common;
using AData.DataGenerator;
using AData.DataGenerator.Sources;
using System;
using System.Globalization;

namespace AData.Console.MSSQL.Toolkit
{
    public class StreetSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Street", "Street1", "Address", "Address1", "AddressLine1" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly string[] _suffix = { "AVE", "BLVD", "CTR", "CIR", "CT", "DR", "HWY", "LN", "PKWY", "ST" };
        private static readonly string[] _streets =
        {
             "太乙路", "太白路", "太华路", "长樱路", "案板街","竹笆市", "骡马市", "西木头市", "安仁坊", "端履门", "德福巷","洒金桥", "冰窖巷", "菊花园", "下马陵（蛤蟆陵)", "粉巷", "索罗巷","后宰门", "书院门", "炭市街", "马厂子", "景龙池", "甜水井", "柏树林"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="StreetSource"/> class.
        /// </summary>
        public StreetSource() : base(_types, _names)
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
            string street = _streets[RandomGenerator.Current.Next(0, _streets.Length)];
            string number = RandomGenerator.Current.Next(10, 8000).ToString(CultureInfo.InvariantCulture);

            return $"{number} {street}";
        }

    }
}
