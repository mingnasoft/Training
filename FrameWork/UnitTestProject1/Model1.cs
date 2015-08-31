namespace UnitTestProject1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<T_Ord_OrderChange_Detail> T_Ord_OrderChange_Detail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Ord_OrderChange_Detail>()
                .Property(e => e.CmpNo)
                .IsUnicode(false);

            modelBuilder.Entity<T_Ord_OrderChange_Detail>()
                .Property(e => e.OrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<T_Ord_OrderChange_Detail>()
                .Property(e => e.FiledName)
                .IsUnicode(false);

            modelBuilder.Entity<T_Ord_OrderChange_Detail>()
                .Property(e => e.FiledNameDes)
                .IsUnicode(false);
        }
    }
}
