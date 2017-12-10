namespace KingShipper.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserBusiness")]
    public partial class UserBusiness
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string BusinessID { get; set; }

        public short? Status { get; set; }

        //public virtual Business Business { get; set; }

        //public virtual User User { get; set; }
    }
}
