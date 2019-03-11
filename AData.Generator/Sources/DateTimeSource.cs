﻿using AData.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator.Sources
{
    public class DateTimeSource : DataSourcePropertyType
    {
        private readonly DateTime _min;
        private readonly DateTime _max;

        public DateTimeSource()
            : base(new[] { typeof(DateTime), typeof(DateTimeOffset) })
        {
            int year = DateTime.Now.Year;
            _min = new DateTime(year - 10, 1, 1);
            _max = new DateTime(year + 3, 1, 1);
        }

        public DateTimeSource(DateTime min, DateTime max)
            : base(new[] { typeof(DateTime), typeof(DateTimeOffset) })
        {
            _min = min;
            _max = max;
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            var range = (_max - _min).Ticks;
            var ticks = (long)(RandomGenerator.Current.NextDouble() * range);

            var nextValue = _min.AddTicks(ticks);

            if (generateContext?.MemberType == typeof(DateTimeOffset))
                return new DateTimeOffset(nextValue);

            return nextValue;
        }
    }
}
