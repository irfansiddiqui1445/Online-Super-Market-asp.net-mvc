namespace Eproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cart")]
    public partial class cart
    {
        [Key]
        [StringLength(200)]
        public string Cart_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Product_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Date_Time { get; set; }

        [Required]
        [StringLength(200)]
        public string User_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Quantity { get; set; }
    }
}
