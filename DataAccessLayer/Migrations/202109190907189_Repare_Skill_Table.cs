namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repare_Skill_Table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "WriterID", "dbo.Writers");
            DropIndex("dbo.Skills", new[] { "WriterID" });
            AddColumn("dbo.Skills", "Name", c => c.String());
            DropColumn("dbo.Skills", "WriterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "WriterID", c => c.Int(nullable: false));
            DropColumn("dbo.Skills", "Name");
            CreateIndex("dbo.Skills", "WriterID");
            AddForeignKey("dbo.Skills", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
        }
    }
}
