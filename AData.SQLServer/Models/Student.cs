using System;
using System.Collections.Generic;

namespace AData.SQLServer.Models
{
    public partial class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Profession { get; set; }
    }
}
