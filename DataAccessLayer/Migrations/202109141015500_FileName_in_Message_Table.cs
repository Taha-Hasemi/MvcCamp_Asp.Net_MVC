namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileName_in_Message_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "FileName", c => c.String(maxLength: 2000));
            DropColumn("dbo.Messages", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "File", c => c.String());
            DropColumn("dbo.Messages", "FileName");
        }
    }
}
