using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.SQLServer.Model
{
    public abstract class Entity
    {
        public System.Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
