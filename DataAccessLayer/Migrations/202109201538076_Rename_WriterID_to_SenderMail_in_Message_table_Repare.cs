namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_WriterID_to_SenderMail_in_Message_table_Repare : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "SenderMail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "SenderMail", c => c.Int(nullable: false));
        }
    }
}
