namespace KingShipper.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public User()
        //{
        //    Orders = new HashSet<Order>();
        //    UserBusinesses = new HashSet<UserBusiness>();
        //}

        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(350)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(150)]
        public string Password { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public short RoleID { get; set; }

        [StringLength(250)]
        public string Avartar { get; set; }

        public bool? Status { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Order> Orders { get; set; }

        //public virtual Role Role { get; set; }

        //public virtual Banner Banner { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<UserBusiness> UserBusinesses { get; set; }

        //public virtual UserPermission UserPermission { get; set; }
    }
}
