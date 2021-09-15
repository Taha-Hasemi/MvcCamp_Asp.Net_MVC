namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgr2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
