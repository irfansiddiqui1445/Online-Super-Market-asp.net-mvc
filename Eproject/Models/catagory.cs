namespace Eproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("catagory")]
    public partial class catagory
    {
        [Key]
        [StringLength(200)]
        public string Cat_ID { get; set; }

        [StringLength(200)]
        public string Sub_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(2000)]
        public string Des { get; set; }
    }
}
