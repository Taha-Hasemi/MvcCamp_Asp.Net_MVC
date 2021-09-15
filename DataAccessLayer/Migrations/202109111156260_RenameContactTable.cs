namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameContactTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contects", newName: "Contacts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Contacts", newName: "Contects");
        }
    }
}
