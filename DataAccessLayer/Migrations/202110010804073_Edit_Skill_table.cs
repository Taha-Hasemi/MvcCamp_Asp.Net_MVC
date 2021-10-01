namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Skill_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Skill1", c => c.String());
            AddColumn("dbo.Skills", "Skill2", c => c.String());
            AddColumn("dbo.Skills", "Skill3", c => c.String());
            AddColumn("dbo.Skills", "Rate1", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "Rate2", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "Rate3", c => c.Int(nullable: false));
            DropColumn("dbo.Skills", "Name");
            DropColumn("dbo.Skills", "CSharp");
            DropColumn("dbo.Skills", "SQL");
            DropColumn("dbo.Skills", "DotNet");
            DropColumn("dbo.Skills", "AspDotNet");
            DropColumn("dbo.Skills", "Algorithm");
            DropColumn("dbo.Skills", "PhotoShop");
            DropColumn("dbo.Skills", "WindowsForm");
            DropColumn("dbo.Skills", "ConsoleForm");
            DropColumn("dbo.Skills", "EntityFramework");
            DropColumn("dbo.Skills", "PubgM24");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "PubgM24", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "EntityFramework", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "ConsoleForm", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "WindowsForm", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "PhotoShop", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "Algorithm", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "AspDotNet", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "DotNet", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "SQL", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "CSharp", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "Name", c => c.String());
            DropForeignKey("dbo.Skills", "AdminID", "dbo.Admins");
            DropIndex("dbo.Skills", new[] { "AdminID" });
            DropColumn("dbo.Skills", "AdminID");
            DropColumn("dbo.Skills", "Rate3");
            DropColumn("dbo.Skills", "Rate2");
            DropColumn("dbo.Skills", "Rate1");
            DropColumn("dbo.Skills", "Skill3");
            DropColumn("dbo.Skills", "Skill2");
            DropColumn("dbo.Skills", "Skill1");
        }
    }
}
