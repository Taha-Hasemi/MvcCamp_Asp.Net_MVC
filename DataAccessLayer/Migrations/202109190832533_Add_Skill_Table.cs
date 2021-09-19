namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Skill_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        WriterID = c.Int(nullable: false),
                        CSharp = c.Int(nullable: false),
                        SQL = c.Int(nullable: false),
                        DotNet = c.Int(nullable: false),
                        AspDotNet = c.Int(nullable: false),
                        Algorithm = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID)
                .ForeignKey("dbo.Writers", t => t.WriterID, cascadeDelete: true)
                .Index(t => t.WriterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "WriterID", "dbo.Writers");
            DropIndex("dbo.Skills", new[] { "WriterID" });
            DropTable("dbo.Skills");
        }
    }
}
