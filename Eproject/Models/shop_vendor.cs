namespace Eproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class shop_vendor
    {
        [Key]
        [StringLength(200)]
        public string Shop_Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Shop_Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Shopkeeper_Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Shop_Address { get; set; }

        [Required]
        [StringLength(200)]
        public string Shopkeeper_Refference_ID { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        [StringLength(200)]
        public string Shop_Logo { get; set; }

        [Required]
        [StringLength(200)]
        public string Catagory { get; set; }
    }
}
