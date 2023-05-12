namespace Vidlly.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    
    public partial class SetGenreIntoDatabase : DbMigration
    {
        public override void Up()
        {
           
            Sql("INSERT INTO Genres (Name) VALUES ( 'Family')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Romance')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
            
        }
        
        public override void Down()
        {
        }
    }
}
