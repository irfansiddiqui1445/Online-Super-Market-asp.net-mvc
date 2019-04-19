namespace Eproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("publicuseraccount")]
    public partial class publicuseraccount
    {
        [Key]
        [StringLength(200)]
        public string User_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string UserType { get; set; }

        [Required]
        [StringLength(200)]
        public string Contact { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(200)]
        public string CCN { get; set; }

        [Required]
        [StringLength(200)]
        public string CCEx { get; set; }
    }
}
