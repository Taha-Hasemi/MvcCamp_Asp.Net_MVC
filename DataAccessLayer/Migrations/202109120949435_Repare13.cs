namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repare13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "RecieverID_WriterID", "dbo.Writers");
            DropForeignKey("dbo.Messages", "SenderID_WriterID", "dbo.Writers");
            DropIndex("dbo.Messages", new[] { "RecieverID_WriterID" });
            DropIndex("dbo.Messages", new[] { "SenderID_WriterID" });
            AddColumn("dbo.Messages", "SenderID", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "RecieverID", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "RecieverID_WriterID");
            DropColumn("dbo.Messages", "SenderID_WriterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "SenderID_WriterID", c => c.Int());
            AddColumn("dbo.Messages", "RecieverID_WriterID", c => c.Int());
            DropColumn("dbo.Messages", "RecieverID");
            DropColumn("dbo.Messages", "SenderID");
            CreateIndex("dbo.Messages", "SenderID_WriterID");
            CreateIndex("dbo.Messages", "RecieverID_WriterID");
            AddForeignKey("dbo.Messages", "SenderID_WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Messages", "RecieverID_WriterID", "dbo.Writers", "WriterID");
        }
    }
}
