namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QueueTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Queues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        FamilyName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        PhilHealthNo = c.String(),
                        ChiefComplaint = c.String(),
                        Barangay = c.String(),
                        HouseholdNo = c.String(),
                        Status = c.String(),
                        Served = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Queues");
        }
    }
}
