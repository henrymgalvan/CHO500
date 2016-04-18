namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedStaffToPerson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "staff_ID", "dbo.People");
            DropIndex("dbo.Staffs", new[] { "staff_ID" });
            RenameColumn(table: "dbo.Staffs", name: "staff_ID", newName: "PersonID");
            AlterColumn("dbo.Staffs", "PersonID", c => c.Int(nullable: false));
            CreateIndex("dbo.Staffs", "PersonID");
            AddForeignKey("dbo.Staffs", "PersonID", "dbo.People", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "PersonID", "dbo.People");
            DropIndex("dbo.Staffs", new[] { "PersonID" });
            AlterColumn("dbo.Staffs", "PersonID", c => c.Int());
            RenameColumn(table: "dbo.Staffs", name: "PersonID", newName: "staff_ID");
            CreateIndex("dbo.Staffs", "staff_ID");
            AddForeignKey("dbo.Staffs", "staff_ID", "dbo.People", "ID");
        }
    }
}
