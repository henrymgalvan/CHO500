namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonStaffTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "PersonID", "dbo.People");
            DropForeignKey("dbo.People", "LastUpdatedBy_Id", "dbo.Staffs");
            DropIndex("dbo.People", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Staffs", new[] { "PersonID" });
            RenameColumn(table: "dbo.People", name: "CreatedBy_Id", newName: "Staff_Id");
            RenameIndex(table: "dbo.People", name: "IX_CreatedBy_Id", newName: "IX_Staff_Id");
            AddColumn("dbo.People", "CreatedByStaffId", c => c.Int(nullable: false));
            AddColumn("dbo.Staffs", "FullName", c => c.String());
            DropColumn("dbo.People", "DateLastUpdated");
            DropColumn("dbo.People", "LastUpdatedBy_Id");
            DropColumn("dbo.Staffs", "PersonID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "PersonID", c => c.Int(nullable: false));
            AddColumn("dbo.People", "LastUpdatedBy_Id", c => c.Int());
            AddColumn("dbo.People", "DateLastUpdated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Staffs", "FullName");
            DropColumn("dbo.People", "CreatedByStaffId");
            RenameIndex(table: "dbo.People", name: "IX_Staff_Id", newName: "IX_CreatedBy_Id");
            RenameColumn(table: "dbo.People", name: "Staff_Id", newName: "CreatedBy_Id");
            CreateIndex("dbo.Staffs", "PersonID");
            CreateIndex("dbo.People", "LastUpdatedBy_Id");
            AddForeignKey("dbo.People", "LastUpdatedBy_Id", "dbo.Staffs", "Id");
            AddForeignKey("dbo.Staffs", "PersonID", "dbo.People", "ID", cascadeDelete: true);
        }
    }
}
