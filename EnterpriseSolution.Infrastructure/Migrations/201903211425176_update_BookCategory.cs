namespace EnterpriseSolution.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_BookCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookCategories", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookCategories", "IsActive");
        }
    }
}
