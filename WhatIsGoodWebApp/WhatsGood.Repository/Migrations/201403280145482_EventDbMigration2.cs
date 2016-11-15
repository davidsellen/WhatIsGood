namespace WhatsGood.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventDbMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Establishment", "Accessibility", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Establishment", "Accessibility");
        }
    }
}
