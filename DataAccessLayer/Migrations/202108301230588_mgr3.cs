namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgr3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "WriterDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterDescription", c => c.String());
        }
    }
}
