namespace TextIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grupas", "korisnikID", c => c.Int(nullable: false));
            CreateIndex("dbo.Grupas", "korisnikID");
            AddForeignKey("dbo.Grupas", "korisnikID", "dbo.Korisnici", "korisnikID", cascadeDelete: true);
            DropColumn("dbo.Korisnici", "grupaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Korisnici", "grupaID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Grupas", "korisnikID", "dbo.Korisnici");
            DropIndex("dbo.Grupas", new[] { "korisnikID" });
            DropColumn("dbo.Grupas", "korisnikID");
        }
    }
}
