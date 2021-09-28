namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_AdminStatus_in_Admin_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdmninStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdmninStatus");
        }
    }
}
