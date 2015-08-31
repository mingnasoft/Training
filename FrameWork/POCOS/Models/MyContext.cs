namespace POCOS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public  class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        public static MyContext Current
        {
            get
            {

                if (HttpContext.Current.Items["MyContext"] != null)
                {
                    return HttpContext.Current.Items["MyContext"] as MyContext;
                }
                else
                {
                    MyContext _MyContext = new MyContext();
                    HttpContext.Current.Items["MyContext"] = _MyContext;
                    return _MyContext;
                }

            }
        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<LoadingChange> LoadingChange { get; set; }
        public virtual DbSet<LoadingChange_Detail> LoadingChange_Detail { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<T_Ord_OrderChange_Detail> T_Ord_OrderChange_Detail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Category1)
                .WithOptional(e => e.Category2)
                .HasForeignKey(e => e.ParentRowID);

            modelBuilder.Entity<LoadingChange>()
                .Property(e => e.LoadingNo)
                .IsUnicode(false);

            modelBuilder.Entity<LoadingChange>()
                .Property(e => e.CmpNo)
                .IsUnicode(false);

            modelBuilder.Entity<LoadingChange>()
                .Property(e => e.CPN)
                .IsUnicode(false);

            modelBuilder.Entity<LoadingChange>()
                .Property(e => e.MPN)
                .IsUnicode(false);

            modelBuilder.Entity<LoadingChange>()
                .HasMany(e => e.LoadingChange_Detail)
                .WithRequired(e => e.LoadingChange)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoadingChange_Detail>()
                .Property(e => e.CmpNo)
                .IsUnicode(false);

            modelBuilder.Entity<LoadingChange_Detail>()
                .Property(e => e.LoadingNo)
                .IsUnicode(false);

            modelBuilder.Entity<LoadingChange_Detail>()
                .Property(e => e.FiledName)
                .IsUnicode(false);

            modelBuilder.Entity<LoadingChange_Detail>()
                .Property(e => e.FiledNameDes)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.RoleID);
        }
    }
}
