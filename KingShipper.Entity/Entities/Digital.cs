namespace KingShipper.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Digital")]
    public partial class Digital
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public double? Height { get; set; }

        public double? Width { get; set; }

        public double? Thickness { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public int? MaterialID { get; set; }

        public virtual Material Material { get; set; }
    }
}
