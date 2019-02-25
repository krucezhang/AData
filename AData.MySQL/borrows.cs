namespace AData.MySQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("booksdb.borrows")]
    public partial class borrows
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string BookId { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime ExpectReturnDate { get; set; }
    }
}
