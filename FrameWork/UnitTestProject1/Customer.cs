namespace UnitTestProject1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomreNo { get; set; }

        [Required]
        public string CustomreName { get; set; }

        public string ShortName { get; set; }

        public string Qipei { get; set; }

        [Required]
        public string Contact1 { get; set; }

        public string Contact2 { get; set; }

        [Required]
        public string Tel1 { get; set; }

        public string Tel2 { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        [Required]
        public string Address { get; set; }

        public int IsEnable { get; set; }

        public DateTime ctime { get; set; }

        public DateTime ltime { get; set; }
    }
}
