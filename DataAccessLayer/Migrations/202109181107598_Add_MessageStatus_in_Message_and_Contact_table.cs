namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_MessageStatus_in_Message_and_Contact_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "MessageStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "MessageStatus");
            DropColumn("dbo.Messages", "MessageStatus");
        }
    }
}
