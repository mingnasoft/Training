namespace codefirstfromdatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public students()
        {
            teachers = new HashSet<teachers>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? school_Id { get; set; }

        public virtual iPhones iPhones { get; set; }

        public virtual schools schools { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teachers> teachers { get; set; }
    }
}
