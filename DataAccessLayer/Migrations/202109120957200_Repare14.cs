namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repare14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "Writer_WriterID", "dbo.Writers");
            DropIndex("dbo.Messages", new[] { "Writer_WriterID" });
            RenameColumn(table: "dbo.Messages", name: "Writer_WriterID", newName: "WriterID");
            AddColumn("dbo.Messages", "RecieverMail", c => c.String());
            AlterColumn("dbo.Messages", "WriterID", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "WriterID");
            AddForeignKey("dbo.Messages", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
            DropColumn("dbo.Messages", "SenderID");
            DropColumn("dbo.Messages", "RecieverID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "RecieverID", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "SenderID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Messages", "WriterID", "dbo.Writers");
            DropIndex("dbo.Messages", new[] { "WriterID" });
            AlterColumn("dbo.Messages", "WriterID", c => c.Int());
            DropColumn("dbo.Messages", "RecieverMail");
            RenameColumn(table: "dbo.Messages", name: "WriterID", newName: "Writer_WriterID");
            CreateIndex("dbo.Messages", "Writer_WriterID");
            AddForeignKey("dbo.Messages", "Writer_WriterID", "dbo.Writers", "WriterID");
        }
    }
}
