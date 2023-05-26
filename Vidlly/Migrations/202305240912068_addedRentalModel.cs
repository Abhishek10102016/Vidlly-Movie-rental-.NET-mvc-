namespace Vidlly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRentalModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Movie_Id = c.Int(nullable: false),
                        Mustomer_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Mustomer_id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Mustomer_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Mustomer_id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Mustomer_id" });
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
