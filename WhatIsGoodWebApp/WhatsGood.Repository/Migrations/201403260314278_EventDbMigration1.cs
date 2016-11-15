namespace WhatsGood.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventDbMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileInformation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Url = c.String(maxLength: 300),
                        Description = c.String(maxLength: 250),
                        Extension = c.String(maxLength: 5),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EstablishmentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.establishmentFiles",
                c => new
                    {
                        establishmentId = c.Int(nullable: false),
                        fileInformationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.establishmentId, t.fileInformationId })
                .ForeignKey("dbo.Establishment", t => t.establishmentId, cascadeDelete: true)
                .ForeignKey("dbo.FileInformation", t => t.fileInformationId, cascadeDelete: true)
                .Index(t => t.establishmentId)
                .Index(t => t.fileInformationId);
            
            AddColumn("dbo.Address", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Address", "CreatedBy", c => c.String());
            AddColumn("dbo.Address", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Address", "UpdatedBy", c => c.String());
            AddColumn("dbo.Artist", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Artist", "CreatedBy", c => c.String());
            AddColumn("dbo.Artist", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Artist", "UpdatedBy", c => c.String());
            AddColumn("dbo.Genre", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Genre", "CreatedBy", c => c.String());
            AddColumn("dbo.Genre", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Genre", "UpdatedBy", c => c.String());
            AddColumn("dbo.Contact", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Contact", "CreatedBy", c => c.String());
            AddColumn("dbo.Contact", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Contact", "UpdatedBy", c => c.String());
            AddColumn("dbo.Establishment", "OwnParking", c => c.Boolean(nullable: false));
            AddColumn("dbo.Establishment", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Establishment", "CreatedBy", c => c.String());
            AddColumn("dbo.Establishment", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Establishment", "UpdatedBy", c => c.String());
            AddColumn("dbo.Establishment", "Type_Id", c => c.Int());
            AddColumn("dbo.Event", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Event", "CreatedBy", c => c.String());
            AddColumn("dbo.Event", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Event", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Establishment", "Name", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.Establishment", "Type_Id");
            AddForeignKey("dbo.Establishment", "Type_Id", "dbo.EstablishmentType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Establishment", "Type_Id", "dbo.EstablishmentType");
            DropForeignKey("dbo.establishmentFiles", "fileInformationId", "dbo.FileInformation");
            DropForeignKey("dbo.establishmentFiles", "establishmentId", "dbo.Establishment");
            DropIndex("dbo.Establishment", new[] { "Type_Id" });
            DropIndex("dbo.establishmentFiles", new[] { "fileInformationId" });
            DropIndex("dbo.establishmentFiles", new[] { "establishmentId" });
            AlterColumn("dbo.Establishment", "Name", c => c.String(maxLength: 150));
            DropColumn("dbo.Event", "UpdatedBy");
            DropColumn("dbo.Event", "UpdatedDate");
            DropColumn("dbo.Event", "CreatedBy");
            DropColumn("dbo.Event", "CreatedDate");
            DropColumn("dbo.Establishment", "Type_Id");
            DropColumn("dbo.Establishment", "UpdatedBy");
            DropColumn("dbo.Establishment", "UpdatedDate");
            DropColumn("dbo.Establishment", "CreatedBy");
            DropColumn("dbo.Establishment", "CreatedDate");
            DropColumn("dbo.Establishment", "OwnParking");
            DropColumn("dbo.Contact", "UpdatedBy");
            DropColumn("dbo.Contact", "UpdatedDate");
            DropColumn("dbo.Contact", "CreatedBy");
            DropColumn("dbo.Contact", "CreatedDate");
            DropColumn("dbo.Genre", "UpdatedBy");
            DropColumn("dbo.Genre", "UpdatedDate");
            DropColumn("dbo.Genre", "CreatedBy");
            DropColumn("dbo.Genre", "CreatedDate");
            DropColumn("dbo.Artist", "UpdatedBy");
            DropColumn("dbo.Artist", "UpdatedDate");
            DropColumn("dbo.Artist", "CreatedBy");
            DropColumn("dbo.Artist", "CreatedDate");
            DropColumn("dbo.Address", "UpdatedBy");
            DropColumn("dbo.Address", "UpdatedDate");
            DropColumn("dbo.Address", "CreatedBy");
            DropColumn("dbo.Address", "CreatedDate");
            DropTable("dbo.establishmentFiles");
            DropTable("dbo.EstablishmentType");
            DropTable("dbo.FileInformation");
        }
    }
}
