namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repare12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "RecieverID_WriterID", c => c.Int());
            AddColumn("dbo.Messages", "SenderID_WriterID", c => c.Int());
            AddColumn("dbo.Messages", "Writer_WriterID", c => c.Int());
            CreateIndex("dbo.Messages", "RecieverID_WriterID");
            CreateIndex("dbo.Messages", "SenderID_WriterID");
            CreateIndex("dbo.Messages", "Writer_WriterID");
            AddForeignKey("dbo.Messages", "RecieverID_WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Messages", "SenderID_WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Messages", "Writer_WriterID", "dbo.Writers", "WriterID");
            DropColumn("dbo.Messages", "SenderMail");
            DropColumn("dbo.Messages", "RecieverMail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "RecieverMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Messages", "SenderMail", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Messages", "Writer_WriterID", "dbo.Writers");
            DropForeignKey("dbo.Messages", "SenderID_WriterID", "dbo.Writers");
            DropForeignKey("dbo.Messages", "RecieverID_WriterID", "dbo.Writers");
            DropIndex("dbo.Messages", new[] { "Writer_WriterID" });
            DropIndex("dbo.Messages", new[] { "SenderID_WriterID" });
            DropIndex("dbo.Messages", new[] { "RecieverID_WriterID" });
            DropColumn("dbo.Messages", "Writer_WriterID");
            DropColumn("dbo.Messages", "SenderID_WriterID");
            DropColumn("dbo.Messages", "RecieverID_WriterID");
        }
    }
}
