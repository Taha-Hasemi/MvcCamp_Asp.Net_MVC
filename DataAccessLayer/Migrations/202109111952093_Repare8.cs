namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repare8 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Writer_WriterID", c => c.Int());
            CreateIndex("dbo.Messages", "Writer_WriterID");
            AddForeignKey("dbo.Messages", "Writer_WriterID", "dbo.Writers", "WriterID");
        }
    }
}
