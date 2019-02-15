using System;
using System.Collections.Generic;

namespace AData.SQLServer.Model.Models
{
    public partial class Shop : Entity
    {
        public Shop()
        {
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.ZCode = string.Empty;
            this.ContactName = string.Empty;
        }

        public string ShopId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ZCode { get; set; }
        public string ContactName { get; set; }
        public System.Guid? ShopManager { get; set; }
        public System.Guid? RegionId { get; set; }
    }
}
