namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Skill_table2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "Name");
        }
    }
}
