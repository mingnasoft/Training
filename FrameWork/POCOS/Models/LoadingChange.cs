namespace POCOS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoadingChange")]
    public partial class LoadingChange
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoadingChange()
        {
            LoadingChange_Detail = new HashSet<LoadingChange_Detail>();
        }

        [Key]
        [StringLength(30)]
        public string LoadingNo { get; set; }

        [StringLength(10)]
        public string CmpNo { get; set; }

        [StringLength(500)]
        public string ChangeMemo { get; set; }

        public int IsConfirm { get; set; }

        public int IsFinConfirm { get; set; }

        [StringLength(10)]
        public string CPN { get; set; }

        public DateTime CTime { get; set; }

        [StringLength(10)]
        public string MPN { get; set; }

        public DateTime MTime { get; set; }

        public bool IsValidate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoadingChange_Detail> LoadingChange_Detail { get; set; }
    }
}
