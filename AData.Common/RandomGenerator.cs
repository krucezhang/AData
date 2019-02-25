using AData.Common.Extensions;
using System;
using System.Security.Cryptography;
using System.Threading;

namespace AData.Common
{
    public static class RandomGenerator
    {
        // one random generator per thread
        private static readonly RandomNumberGenerator _seed = RandomNumberGenerator.Create();
        private static readonly ThreadLocal<Random> _local = new ThreadLocal<Random>(() => new Random(_seed.Next()));

        public static Random Current => _local.Value;
    }
}
