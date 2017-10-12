namespace KingShipper.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
       

        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(350)]
        public string Address { get; set; }

        public DateTime? Birthday { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public short RoleID { get; set; }

        public bool? Status { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }
    }
}
