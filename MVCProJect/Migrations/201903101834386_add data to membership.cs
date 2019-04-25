
namespace MVCProJect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatomembership : DbMigration
    {
        public override void Up()
        {
			Sql("INSERT INTO Memberships(Id,Name,SignUpFee,Duration,Discount) VALUES(1,'Free',0,0,0)");
			Sql("INSERT INTO Memberships(Id,Name,SignUpFee,Duration,Discount) VALUES(2,'Monthly',30,1,10)");
			Sql("INSERT INTO Memberships(Id,Name,SignUpFee,Duration,Discount) VALUES(3,'Quarterly',90,3,15)");
			Sql("INSERT INTO Memberships(Id,Name,SignUpFee,Duration,Discount) VALUES(4,'Annual',300,12,20)");
		}
        
        public override void Down()
        {
        }
    }
}
