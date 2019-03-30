namespace EnterpriseSolution.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_Author : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
