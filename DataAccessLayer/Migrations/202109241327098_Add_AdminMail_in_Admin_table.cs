namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_AdminMail_in_Admin_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminMail", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminMail");
        }
    }
}
