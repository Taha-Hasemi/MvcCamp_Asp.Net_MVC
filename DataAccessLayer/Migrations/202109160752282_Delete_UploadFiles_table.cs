namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_UploadFiles_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UploadFiles", "MessageID", "dbo.Messages");
            DropIndex("dbo.UploadFiles", new[] { "MessageID" });
            DropColumn("dbo.UploadFiles", "MessageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UploadFiles", "MessageID", c => c.Int(nullable: false));
            CreateIndex("dbo.UploadFiles", "MessageID");
            AddForeignKey("dbo.UploadFiles", "MessageID", "dbo.Messages", "MessageID", cascadeDelete: true);
        }
    }
}
