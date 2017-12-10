namespace KingShipper.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        [Key]
        public int UserID { get; set; }

        public int? Id { get; set; }

        [StringLength(350)]
        public string ImageURL { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public virtual User User { get; set; }
    }
}
