namespace EnterpriseSolution.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Author_Book : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AuthorName = c.String(),
                        AuthorShortCode = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateOfDeath = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RefNo = c.String(),
                        Name = c.String(),
                        Image = c.String(),
                        Price = c.Double(nullable: false),
                        ShortDescription = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        AuthorId = c.Long(nullable: false),
                        BookCategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.BookCategories", t => t.BookCategoryId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.BookCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "BookCategoryId", "dbo.BookCategories");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "BookCategoryId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
