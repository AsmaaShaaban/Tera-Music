namespace MVCProJect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UML1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UMLs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(),
                        MusicInstrument_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.MusicInstruments", t => t.MusicInstrument_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.MusicInstrument_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UMLs", "MusicInstrument_Id", "dbo.MusicInstruments");
            DropForeignKey("dbo.UMLs", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.UMLs", new[] { "MusicInstrument_Id" });
            DropIndex("dbo.UMLs", new[] { "Customer_Id" });
            DropTable("dbo.UMLs");
        }
    }
}
