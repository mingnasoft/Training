namespace codefirstfromdatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtest02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.test02",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.test02");
        }
    }
}
