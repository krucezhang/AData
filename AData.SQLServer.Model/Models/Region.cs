using System;
using System.Collections.Generic;

namespace AData.SQLServer.Model.Models
{
    public partial class Region : Entity
    {
        public Region()
        {
            this.Name = string.Empty;
        }

        public string Name { get; set; }
        public System.Guid? Manager { get; set; }
    }
}
