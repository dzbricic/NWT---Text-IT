namespace TextIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ocjenas",
                c => new
                    {
                        ocjenaID = c.Int(nullable: false, identity: true),
                        ocjena = c.Int(nullable: false),
                        Tekst_tekstID = c.Int(),
                    })
                .PrimaryKey(t => t.ocjenaID)
                .ForeignKey("dbo.Tekstovi", t => t.Tekst_tekstID)
                .Index(t => t.Tekst_tekstID);
            
            AddColumn("dbo.Grupas", "nazivGrupe", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ocjenas", "Tekst_tekstID", "dbo.Tekstovi");
            DropIndex("dbo.Ocjenas", new[] { "Tekst_tekstID" });
            DropColumn("dbo.Grupas", "nazivGrupe");
            DropTable("dbo.Ocjenas");
        }
    }
}
