namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_SenderID_To_SenderMail_And_Edit_RecieverID_To_RecieverMail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Subject", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Subject", c => c.String(maxLength: 50));
        }
    }
}
