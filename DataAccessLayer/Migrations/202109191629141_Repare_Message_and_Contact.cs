namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repare_Message_and_Contact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "MessageStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "MessageState");
            DropColumn("dbo.Contacts", "MessageState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "MessageState", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageState", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "MessageStatus");
            DropColumn("dbo.Messages", "MessageStatus");
        }
    }
}
