namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomFields",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IsActive = c.Boolean(),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PartCustomField",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IsActive = c.Boolean(),
                        PartRefId = c.Guid(nullable: false),
                        CustomFieldRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.PartRefId, t.CustomFieldRefId })
                .ForeignKey("dbo.CustomFields", t => t.CustomFieldRefId, cascadeDelete: true)
                .ForeignKey("dbo.Part", t => t.PartRefId, cascadeDelete: true)
                .Index(t => t.PartRefId)
                .Index(t => t.CustomFieldRefId);
            
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IsActive = c.Boolean(),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartCustomField", "PartRefId", "dbo.Part");
            DropForeignKey("dbo.PartCustomField", "CustomFieldRefId", "dbo.CustomFields");
            DropIndex("dbo.PartCustomField", new[] { "CustomFieldRefId" });
            DropIndex("dbo.PartCustomField", new[] { "PartRefId" });
            DropTable("dbo.Part");
            DropTable("dbo.PartCustomField");
            DropTable("dbo.CustomFields");
        }
    }
}
