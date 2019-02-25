using System;
using System.Collections.Generic;

namespace AData.SQLServer.Models
{
    public partial class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public System.DateTime RecordDate { get; set; }
    }
}
