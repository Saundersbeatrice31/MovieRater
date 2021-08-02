namespace MovieRater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRatingClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieRating = c.Double(nullable: false),
                        TheaterRating = c.Double(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        RatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.RatId, cascadeDelete: true)
                .Index(t => t.RatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rating", "RatId", "dbo.Movie");
            DropIndex("dbo.Rating", new[] { "RatId" });
            DropTable("dbo.Rating");
        }
    }
}
