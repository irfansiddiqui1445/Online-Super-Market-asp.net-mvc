namespace Eproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [Key]
        [StringLength(200)]
        public string Pro_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Pro_Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Catogary { get; set; }

        
        [StringLength(200)]
        public string Brand { get; set; }

        [Required]
        [StringLength(200)]
        public string Shop { get; set; }

        [Required]
        [StringLength(2000)]
        public string Des { get; set; }

        [Required]
        [StringLength(200)]
        public string Status { get; set; }

        [Required]
        [StringLength(200)]
        public string Price { get; set; }

        [Required]
        [StringLength(200)]
        public string Date_Time { get; set; }

        [StringLength(200)]
        public string Image { get; set; }
    }
}
