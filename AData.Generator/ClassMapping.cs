using AData.DataGenerator.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.DataGenerator
{
    public class ClassMapping : ICloneable
    {
        public ClassMapping()
        {
            AutoMap = true;
            Members = new List<MemberMapping>();
            SyncRoot = new object();
        }

        public ClassMapping(TypeAccessor typeAccessor) : this()
        {
            TypeAccessor = typeAccessor;
        }

        public bool AutoMap { get; set; }

        public bool Ignored { get; set; }

        public bool Mapped { get; set; }

        public Func<Type, object> Factory { get; set; }

        public TypeAccessor TypeAccessor { get; set; }

        public List<MemberMapping> Members { get; }

        public object SyncRoot { get; }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public ClassMapping Clone()
        {
            var classMapping = new ClassMapping
            {
                AutoMap = AutoMap,
                Ignored = Ignored,
                Mapped = Mapped,
                TypeAccessor = TypeAccessor,

            };


            foreach (var m in Members)
            {
                var memberMapping = new MemberMapping
                {
                    Ignored = m.Ignored,
                    MemberAccessor = m.MemberAccessor,
                    DataSource = m.DataSource
                };

                classMapping.Members.Add(memberMapping);
            }

            return classMapping;
        }
    }
}
