namespace POCOS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Ord_OrderChange_Detail
    {
        [Key]
        [StringLength(10)]
        public string CmpNo { get; set; }

        [StringLength(30)]
        public string OrderNo { get; set; }

        public int? ItemNO { get; set; }

        [StringLength(30)]
        public string FiledName { get; set; }

        [StringLength(30)]
        public string FiledNameDes { get; set; }

        public int? OldValue { get; set; }

        public int? NewValue { get; set; }

        [StringLength(50)]
        public string name { get; set; }
    }
}
