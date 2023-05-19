namespace Vidlly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInForeingKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id1" });
            RenameColumn(table: "dbo.Movies", name: "Genre_Id1", newName: "GenreId");
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Movies", "GenreId", c => c.Int());
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Genres", "Id");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genre_Id1");
            CreateIndex("dbo.Movies", "Genre_Id1");
            AddForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres", "Id");
        }
    }
}
