namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repare11 : DbMigration
    {
        public override void Up()
        {
            
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
