namespace POCOS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Psword { get; set; }

        public int RoleID { get; set; }

        public string Brief { get; set; }

        public DateTime Ctime { get; set; }

        public DateTime Ltime { get; set; }

        public int IsEnable { get; set; }

        public virtual Roles Roles { get; set; }
    }
}
