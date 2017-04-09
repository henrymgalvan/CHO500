namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyICD_10_CM_Category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ICD_10_CM_Category", "Description", c => c.String());
            DropColumn("dbo.ICD_10_CM_Category", "ICD_10_CM_Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ICD_10_CM_Category", "ICD_10_CM_Code", c => c.String());
            DropColumn("dbo.ICD_10_CM_Category", "Description");
        }
    }
}
