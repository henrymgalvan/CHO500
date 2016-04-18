namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloodTypeTableAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "BloodTypesId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "BloodTypesId");
            AddForeignKey("dbo.People", "BloodTypesId", "dbo.BloodTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "BloodTypesId", "dbo.BloodTypes");
            DropIndex("dbo.People", new[] { "BloodTypesId" });
            DropColumn("dbo.People", "BloodTypesId");
        }
    }
}
