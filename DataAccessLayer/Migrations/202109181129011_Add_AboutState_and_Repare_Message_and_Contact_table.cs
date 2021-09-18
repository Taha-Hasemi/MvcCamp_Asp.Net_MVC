namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_AboutState_and_Repare_Message_and_Contact_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutState", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageState", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "MessageState", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "MessageStatus");
            DropColumn("dbo.Contacts", "MessageStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "MessageStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "MessageState");
            DropColumn("dbo.Messages", "MessageState");
            DropColumn("dbo.Abouts", "AboutState");
        }
    }
}
