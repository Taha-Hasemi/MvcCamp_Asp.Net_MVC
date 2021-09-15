namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_OtherValues_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OtherValues",
                c => new
                    {
                        OtherID = c.Int(nullable: false, identity: true),
                        FileName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OtherID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OtherValues");
        }
    }
}
