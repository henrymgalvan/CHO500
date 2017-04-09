namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QueueNoAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Queues", "QueueNo", c => c.Int(nullable: false));
            AddColumn("dbo.Queues", "DateQueued", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Queues", "DateQueued");
            DropColumn("dbo.Queues", "QueueNo");
        }
    }
}
