namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UploadFiles_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UploadFiles",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 200),
                        FilePath = c.String(maxLength: 2000),
                        MessageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.Messages", t => t.MessageID, cascadeDelete: true)
                .Index(t => t.MessageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UploadFiles", "MessageID", "dbo.Messages");
            DropIndex("dbo.UploadFiles", new[] { "MessageID" });
            DropTable("dbo.UploadFiles");
        }
    }
}
