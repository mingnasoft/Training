namespace POCOS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LoadingChange_Detail
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string CmpNo { get; set; }

        [Required]
        [StringLength(30)]
        public string LoadingNo { get; set; }

        [StringLength(30)]
        public string FiledName { get; set; }

        [StringLength(30)]
        public string FiledNameDes { get; set; }

        [StringLength(300)]
        public string OldValue { get; set; }

        [StringLength(300)]
        public string NewValue { get; set; }

        public virtual LoadingChange LoadingChange { get; set; }
    }
}
