namespace MVCProJect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatogenre : DbMigration
    {
        public override void Up()
        {
			Sql("INSERT INTO Genres (Id,Type) VALUES (1,'Percussion')");
			Sql("INSERT INTO Genres (Id,Type) VALUES (2,'String')");
			Sql("INSERT INTO Genres (Id,Type) VALUES (3,'Wind')");
		}
        
        public override void Down()
        {
        }
    }
}
