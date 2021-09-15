namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repare1 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Writer_WriterID1", "dbo.Writers");
            DropIndex("dbo.Messages", new[] { "Writer_WriterID1" });
            DropColumn("dbo.Messages", "Writer_WriterID1");
            DropColumn("dbo.Messages", "RecieverID");
            DropColumn("dbo.Messages", "SenderID");
            RenameIndex(table: "dbo.Messages", name: "IX_Writer2_WriterID", newName: "IX_SenderID_WriterID");
            RenameColumn(table: "dbo.Messages", name: "Writer2_WriterID", newName: "SenderID_WriterID");
            RenameColumn(table: "dbo.Messages", name: "Writer_WriterID", newName: "RecieverID_WriterID");
            AddColumn("dbo.Messages", "Writer_WriterID", c => c.Int());
            CreateIndex("dbo.Messages", "RecieverID_WriterID");
            AddForeignKey("dbo.Messages", "Writer_WriterID", "dbo.Writers", "WriterID");
        }
    }
}
