namespace codefirstfromdatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtest01 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.iPhones",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            PhoneName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.students", t => t.Id)
            //    .Index(t => t.Id);
            
            //CreateTable(
            //    "dbo.students",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            school_Id = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.schools", t => t.school_Id)
            //    .Index(t => t.school_Id);
            
            //CreateTable(
            //    "dbo.schools",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            schoolName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.teachers",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            teacherName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.test01",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.V_student_iPhone",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            Name = c.String(),
            //            school_Id = c.Int(),
            //            PhoneName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.teacherstudents",
            //    c => new
            //        {
            //            student_Id = c.Int(nullable: false),
            //            teacher_Id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.student_Id, t.teacher_Id })
            //    .ForeignKey("dbo.students", t => t.student_Id, cascadeDelete: true)
            //    .ForeignKey("dbo.teachers", t => t.teacher_Id, cascadeDelete: true)
            //    .Index(t => t.student_Id)
            //    .Index(t => t.teacher_Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.teacherstudents", "teacher_Id", "dbo.teachers");
            //DropForeignKey("dbo.teacherstudents", "student_Id", "dbo.students");
            //DropForeignKey("dbo.students", "school_Id", "dbo.schools");
            //DropForeignKey("dbo.iPhones", "Id", "dbo.students");
            //DropIndex("dbo.teacherstudents", new[] { "teacher_Id" });
            //DropIndex("dbo.teacherstudents", new[] { "student_Id" });
            //DropIndex("dbo.students", new[] { "school_Id" });
            //DropIndex("dbo.iPhones", new[] { "Id" });
            //DropTable("dbo.teacherstudents");
            //DropTable("dbo.V_student_iPhone");
            DropTable("dbo.test01");
            //DropTable("dbo.teachers");
            //DropTable("dbo.schools");
            //DropTable("dbo.students");
            //DropTable("dbo.iPhones");
        }
    }
}
