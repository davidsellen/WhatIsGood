namespace WhatsGood.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventDbMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Artist", "Genre_Id", "dbo.Genre");
            DropIndex("dbo.Artist", new[] { "Genre_Id" });
            AlterColumn("dbo.Artist", "CountryName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Artist", "PhotoUrl", c => c.String(maxLength: 200));
            AlterColumn("dbo.Artist", "WebSiteUrl", c => c.String(maxLength: 200));
            AlterColumn("dbo.Artist", "Email", c => c.String(maxLength: 200));
            AlterColumn("dbo.Artist", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Artist", "Genre_Id");
            AddForeignKey("dbo.Artist", "Genre_Id", "dbo.Genre", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artist", "Genre_Id", "dbo.Genre");
            DropIndex("dbo.Artist", new[] { "Genre_Id" });
            AlterColumn("dbo.Artist", "Genre_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Artist", "Email", c => c.String());
            AlterColumn("dbo.Artist", "WebSiteUrl", c => c.String());
            AlterColumn("dbo.Artist", "PhotoUrl", c => c.String());
            AlterColumn("dbo.Artist", "CountryName", c => c.String());
            CreateIndex("dbo.Artist", "Genre_Id");
            AddForeignKey("dbo.Artist", "Genre_Id", "dbo.Genre", "Id", cascadeDelete: true);
        }
    }
}
