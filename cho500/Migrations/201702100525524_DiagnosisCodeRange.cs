namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiagnosisCodeRange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ICD_10_CM_DiagnosisCode", "DiagnosisCodeRange", c => c.String());
            DropColumn("dbo.ICD_10_CM_DiagnosisCode", "DiagnosisCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ICD_10_CM_DiagnosisCode", "DiagnosisCode", c => c.String());
            DropColumn("dbo.ICD_10_CM_DiagnosisCode", "DiagnosisCodeRange");
        }
    }
}
