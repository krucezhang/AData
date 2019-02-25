using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.MongoDB.Models
{
    public class Managers : Entity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public List<AddressModel> Address { get; set; }
    }
}
