namespace Vidlly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAvailableNumberInMovieModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rentals", name: "Mustomer_id", newName: "Customer_id");
            RenameIndex(table: "dbo.Rentals", name: "IX_Mustomer_id", newName: "IX_Customer_id");
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
            RenameIndex(table: "dbo.Rentals", name: "IX_Customer_id", newName: "IX_Mustomer_id");
            RenameColumn(table: "dbo.Rentals", name: "Customer_id", newName: "Mustomer_id");
        }
    }
}
