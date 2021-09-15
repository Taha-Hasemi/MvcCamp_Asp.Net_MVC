namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repare7 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Writer2_WriterID", c => c.Int());
            AddColumn("dbo.Messages", "RecieverID", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "SenderID", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "RecieverMail");
            DropColumn("dbo.Messages", "SenderMail");
            RenameColumn(table: "dbo.Messages", name: "Writer_WriterID", newName: "Writer_WriterID1");
            AddColumn("dbo.Messages", "Writer_WriterID", c => c.Int());
            CreateIndex("dbo.Messages", "Writer_WriterID1");
            CreateIndex("dbo.Messages", "Writer2_WriterID");
            AddForeignKey("dbo.Messages", "Writer2_WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Messages", "Writer_WriterID", "dbo.Writers", "WriterID");
        }
    }
}
