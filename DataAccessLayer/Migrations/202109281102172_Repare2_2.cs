namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repare2_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Admins", "AdmninStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdmninStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Admins", "AdminStatus");
        }
    }
}
