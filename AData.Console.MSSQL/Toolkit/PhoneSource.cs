using AData.Common;
using AData.DataGenerator;
using AData.DataGenerator.Sources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.Console.MSSQL.Toolkit
{
    public class PhoneSource : DataSourceContainName
    {

        /// <summary>
        /// The default phone number format
        /// </summary>
        public const string DefaultFormat = "({0}) {1}-{2}";

        private static readonly string[] _names = { "Phone", "Fax", "Mobile" };
        private static readonly Type[] _types = { typeof(string) };
        private readonly string _format;


        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneSource"/> class.
        /// </summary>
        public PhoneSource() : this(DefaultFormat)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneSource"/> class.
        /// </summary>
        /// <param name="format">The format.</param>
        public PhoneSource(string format) : base(_types, _names)
        {
            _format = format ?? DefaultFormat;
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
            string areaCode = RandomGenerator.Current.Next(100, 999).ToString(CultureInfo.InvariantCulture);
            string exchange = RandomGenerator.Current.Next(100, 999).ToString(CultureInfo.InvariantCulture);
            string number = RandomGenerator.Current.Next(1, 9999).ToString(CultureInfo.InvariantCulture).PadLeft(4, '0');

            return string.Format(_format, areaCode, exchange, number);
        }

    }
}
