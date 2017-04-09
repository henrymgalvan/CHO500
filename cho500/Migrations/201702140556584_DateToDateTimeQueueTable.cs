namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateToDateTimeQueueTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Queues", "DateTimeQueued", c => c.DateTime(nullable: false));
            DropColumn("dbo.Queues", "DateQueued");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Queues", "DateQueued", c => c.DateTime(nullable: false));
            DropColumn("dbo.Queues", "DateTimeQueued");
        }
    }
}
