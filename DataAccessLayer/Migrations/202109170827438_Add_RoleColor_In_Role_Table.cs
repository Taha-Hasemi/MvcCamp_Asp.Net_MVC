namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_RoleColor_In_Role_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "RoleColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "RoleColor");
        }
    }
}
