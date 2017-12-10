namespace KingShipper.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? CategoryID { get; set; }

        public double? Price { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public virtual Category Category { get; set; }

        public virtual ProductDigital ProductDigital { get; set; }
    }
}
