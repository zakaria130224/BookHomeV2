namespace EnterpriseSolution.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_User : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "RoleId");
            CreateIndex("dbo.Users", "BranchId");
            AddForeignKey("dbo.Users", "BranchId", "dbo.Branches", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "RoleId", "dbo.UserRoles", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.UserRoles");
            DropForeignKey("dbo.Users", "BranchId", "dbo.Branches");
            DropIndex("dbo.Users", new[] { "BranchId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
        }
    }
}
