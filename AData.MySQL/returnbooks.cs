namespace AData.MySQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("booksdb.returnbooks")]
    public partial class returnbooks
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string BookId { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
