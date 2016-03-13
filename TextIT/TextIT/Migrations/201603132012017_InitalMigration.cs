namespace TextIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tekstovi", "oznaka_hashTagID", "dbo.HashTags");
            DropIndex("dbo.Tekstovi", new[] { "oznaka_hashTagID" });
            DropColumn("dbo.Tekstovi", "hashID");
            DropColumn("dbo.Tekstovi", "oznaka_hashTagID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tekstovi", "oznaka_hashTagID", c => c.Int());
            AddColumn("dbo.Tekstovi", "hashID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tekstovi", "oznaka_hashTagID");
            AddForeignKey("dbo.Tekstovi", "oznaka_hashTagID", "dbo.HashTags", "hashTagID");
        }
    }
}
