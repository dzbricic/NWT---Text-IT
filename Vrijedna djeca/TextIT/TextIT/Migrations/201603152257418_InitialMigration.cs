namespace TextIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grupa",
                c => new
                    {
                        grupaID = c.Int(nullable: false, identity: true),
                        nazivGrupe = c.String(nullable: false),
                        korisnikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.grupaID)
                .ForeignKey("dbo.Korisnici", t => t.korisnikID, cascadeDelete: true)
                .Index(t => t.korisnikID);
            
            CreateTable(
                "dbo.Korisnici",
                c => new
                    {
                        korisnikID = c.Int(nullable: false, identity: true),
                        ime = c.String(nullable: false),
                        prezime = c.String(nullable: false),
                        korisnickoIme = c.String(nullable: false),
                        sifra = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false, maxLength: 128),
                        tipKorisnika = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.korisnikID);
            
            CreateTable(
                "dbo.Komentari",
                c => new
                    {
                        komentarID = c.Int(nullable: false, identity: true),
                        sadrzaj = c.String(nullable: false),
                        datumObjave = c.DateTime(nullable: false),
                        korisnikID = c.Int(nullable: false),
                        Tekst_tekstID = c.Int(),
                    })
                .PrimaryKey(t => t.komentarID)
                .ForeignKey("dbo.Korisnici", t => t.korisnikID, cascadeDelete: true)
                .ForeignKey("dbo.Tekstovi", t => t.Tekst_tekstID)
                .Index(t => t.korisnikID)
                .Index(t => t.Tekst_tekstID);
            
            CreateTable(
                "dbo.Tekstovi",
                c => new
                    {
                        tekstID = c.Int(nullable: false, identity: true),
                        naslov = c.String(nullable: false),
                        sadrzaj = c.String(nullable: false),
                        link = c.String(),
                        like = c.Boolean(nullable: false),
                        datumObjave = c.DateTime(nullable: false),
                        korisnikID = c.Int(nullable: false),
                        Grupa_grupaID = c.Int(),
                    })
                .PrimaryKey(t => t.tekstID)
                .ForeignKey("dbo.Korisnici", t => t.korisnikID, cascadeDelete: true)
                .ForeignKey("dbo.Grupa", t => t.Grupa_grupaID)
                .Index(t => t.korisnikID)
                .Index(t => t.Grupa_grupaID);
            
            CreateTable(
                "dbo.HashTags",
                c => new
                    {
                        hashTagID = c.Int(nullable: false, identity: true),
                        naziv = c.String(nullable: false),
                        Tekst_tekstID = c.Int(),
                    })
                .PrimaryKey(t => t.hashTagID)
                .ForeignKey("dbo.Tekstovi", t => t.Tekst_tekstID)
                .Index(t => t.Tekst_tekstID);
            
            CreateTable(
                "dbo.Ocjena",
                c => new
                    {
                        ocjenaID = c.Int(nullable: false, identity: true),
                        ocjena = c.Int(nullable: false),
                        Tekst_tekstID = c.Int(),
                    })
                .PrimaryKey(t => t.ocjenaID)
                .ForeignKey("dbo.Tekstovi", t => t.Tekst_tekstID)
                .Index(t => t.Tekst_tekstID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tekstovi", "Grupa_grupaID", "dbo.Grupa");
            DropForeignKey("dbo.Ocjena", "Tekst_tekstID", "dbo.Tekstovi");
            DropForeignKey("dbo.Tekstovi", "korisnikID", "dbo.Korisnici");
            DropForeignKey("dbo.Komentari", "Tekst_tekstID", "dbo.Tekstovi");
            DropForeignKey("dbo.HashTags", "Tekst_tekstID", "dbo.Tekstovi");
            DropForeignKey("dbo.Komentari", "korisnikID", "dbo.Korisnici");
            DropForeignKey("dbo.Grupa", "korisnikID", "dbo.Korisnici");
            DropIndex("dbo.Tekstovi", new[] { "Grupa_grupaID" });
            DropIndex("dbo.Ocjena", new[] { "Tekst_tekstID" });
            DropIndex("dbo.Tekstovi", new[] { "korisnikID" });
            DropIndex("dbo.Komentari", new[] { "Tekst_tekstID" });
            DropIndex("dbo.HashTags", new[] { "Tekst_tekstID" });
            DropIndex("dbo.Komentari", new[] { "korisnikID" });
            DropIndex("dbo.Grupa", new[] { "korisnikID" });
            DropTable("dbo.Ocjena");
            DropTable("dbo.HashTags");
            DropTable("dbo.Tekstovi");
            DropTable("dbo.Komentari");
            DropTable("dbo.Korisnici");
            DropTable("dbo.Grupa");
        }
    }
}
