namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_WriterID_to_SenderMail_in_Message_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "WriterID", "dbo.Writers");
            DropIndex("dbo.Messages", new[] { "WriterID" });
            AddColumn("dbo.Messages", "SenderMail", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "WriterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "WriterID", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "SenderMail");
            CreateIndex("dbo.Messages", "WriterID");
            AddForeignKey("dbo.Messages", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
        }
    }
}
