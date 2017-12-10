namespace KingShipper.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductDigital")]
    public partial class ProductDigital
    {
        [Key]
        public int ProductID { get; set; }

        public int? DigitalID { get; set; }

        public virtual Digital Digital { get; set; }

        public virtual Product Product { get; set; }
    }
}
