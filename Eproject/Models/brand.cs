namespace Eproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("brand")]
    public partial class brand
    {
        [Key]
        [StringLength(200)]
        public string Brand_Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Brand_Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Brand_Discription { get; set; }

        [Required]
        [StringLength(200)]
        public string Brand_Logo { get; set; }
    }
}
