namespace POCOS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Core.Objects.DataClasses;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Category1 = new HashSet<Category>();
          
        }

        [Key]
        public string RowID { get; set; }

    

        [Required]
        public string title { get; set; }

        public int SeqNo { get; set; }

        public string ParentRowID { get; set; }

        public bool IsEnable { get; set; }

        public DateTime ltime { get; set; }

        public DateTime ctime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Category1 { get; set; }

        public virtual Category Category2 { get; set; }
    }
}
