using System;
using System.Collections.Generic;

namespace AData.SQLServer.Model.Models
{
    public partial class User : Entity
    {
        public User()
        {
            this.Account = string.Empty;
            this.Name = string.Empty;
            this.Age = 0;
            this.Phone = string.Empty;
        }

        public string Account { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }
}
