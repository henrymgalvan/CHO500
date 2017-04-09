namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyCategoryToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ICD_10_CM_Category", "Category", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ICD_10_CM_Category", "Category", c => c.Int(nullable: false));
        }
    }
}
