namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_UploadFiles_table2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UploadFiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UploadFiles",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 200),
                        FilePath = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.FileID);
            
        }
    }
}
