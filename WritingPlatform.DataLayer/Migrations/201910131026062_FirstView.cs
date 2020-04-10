namespace WritingPlatform.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstView : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(maxLength: 250),
                        UserId = c.Int(),
                        WorkId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Works", t => t.WorkId)
                .Index(t => t.UserId)
                .Index(t => t.WorkId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 250),
                        Email = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.Int(),
                        WorkId = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Works", t => t.WorkId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.WorkId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        DateOfPublication = c.DateTime(nullable: false, storeType: "date"),
                        Content = c.String(nullable: false),
                        GenreId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.GenreId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "UserId", "dbo.Users");
            DropForeignKey("dbo.Ratings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Ratings", "WorkId", "dbo.Works");
            DropForeignKey("dbo.Works", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Comments", "WorkId", "dbo.Works");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Works", new[] { "UserId" });
            DropIndex("dbo.Works", new[] { "GenreId" });
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropIndex("dbo.Ratings", new[] { "WorkId" });
            DropIndex("dbo.Comments", new[] { "WorkId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Works");
            DropTable("dbo.Ratings");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
        }
    }
}
