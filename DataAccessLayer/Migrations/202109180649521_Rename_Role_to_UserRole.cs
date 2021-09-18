namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_Role_to_UserRole : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "UserRoles");
            AlterColumn("dbo.UserRoles", "RoleName", c => c.String(maxLength: 30));
            AlterColumn("dbo.UserRoles", "RoleColor", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRoles", "RoleColor", c => c.String());
            AlterColumn("dbo.UserRoles", "RoleName", c => c.String());
            RenameTable(name: "dbo.UserRoles", newName: "Roles");
        }
    }
}
