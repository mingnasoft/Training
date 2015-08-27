namespace codefirstfromdatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDBContext")
        {
        }

        public virtual DbSet<iPhones> iPhones { get; set; }
        public virtual DbSet<schools> schools { get; set; }
        public virtual DbSet<students> students { get; set; }
        public virtual DbSet<teachers> teachers { get; set; }
        public virtual DbSet<test01> test01 { get; set; }
        public virtual DbSet<test02> test02 { get; set; }
        public virtual DbSet<V_student_iPhone> V_student_iPhone { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<schools>()
                .HasMany(e => e.students)
                .WithOptional(e => e.schools)
                .HasForeignKey(e => e.school_Id);

            modelBuilder.Entity<students>()
                .HasOptional(e => e.iPhones)
                .WithRequired(e => e.students);

            modelBuilder.Entity<students>()
                .HasMany(e => e.teachers)
                .WithMany(e => e.students)
                .Map(m => m.ToTable("teacherstudents").MapLeftKey("student_Id").MapRightKey("teacher_Id"));
        }
    }
}
