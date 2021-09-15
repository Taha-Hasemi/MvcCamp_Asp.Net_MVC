namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_MessageRead_In_MessageTable_And_Contact_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "MessageRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "MessageRead");
            DropColumn("dbo.Messages", "MessageRead");
        }
    }
}
