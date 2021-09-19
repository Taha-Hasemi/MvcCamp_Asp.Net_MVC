namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Skill_Columns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "PhotoShop", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "WindowsForm", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "ConsoleForm", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "EntityFramework", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "PubgM24", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "PubgM24");
            DropColumn("dbo.Skills", "EntityFramework");
            DropColumn("dbo.Skills", "ConsoleForm");
            DropColumn("dbo.Skills", "WindowsForm");
            DropColumn("dbo.Skills", "PhotoShop");
        }
    }
}
