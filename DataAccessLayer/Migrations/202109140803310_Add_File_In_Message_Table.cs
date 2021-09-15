namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_File_In_Message_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "File", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "File");
        }
    }
}
