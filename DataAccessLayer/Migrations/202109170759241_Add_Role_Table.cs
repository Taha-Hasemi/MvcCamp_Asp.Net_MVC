namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Role_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID)
                .ForeignKey("dbo.Admins", t => t.AdminID, cascadeDelete: true)
                .Index(t => t.AdminID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "AdminID", "dbo.Admins");
            DropIndex("dbo.Roles", new[] { "AdminID" });
            DropTable("dbo.Roles");
        }
    }
}
