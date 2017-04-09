namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ICD_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ICD_10_CM_Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ICD_10_CM_DiagnosisSectionCodeID = c.Int(nullable: false),
                        ICD_10_CM_Code = c.String(),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ICD_10_CM_DiagnosisSectionCode", t => t.ICD_10_CM_DiagnosisSectionCodeID, cascadeDelete: true)
                .Index(t => t.ICD_10_CM_DiagnosisSectionCodeID);
            
            CreateTable(
                "dbo.ICD_10_CM_DiagnosisSectionCode",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ICD_10_CM_DiagnosisCodeID = c.Int(nullable: false),
                        DiagnosisSectionCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ICD_10_CM_DiagnosisCode", t => t.ICD_10_CM_DiagnosisCodeID, cascadeDelete: true)
                .Index(t => t.ICD_10_CM_DiagnosisCodeID);
            
            CreateTable(
                "dbo.ICD_10_CM_DiagnosisCode",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ICD_10_CM_CodeRangeID = c.Int(nullable: false),
                        DiagnosisCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ICD_10_CM_CodeRange", t => t.ICD_10_CM_CodeRangeID, cascadeDelete: true)
                .Index(t => t.ICD_10_CM_CodeRangeID);
            
            CreateTable(
                "dbo.ICD_10_CM_CodeRange",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CodeRange = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ICD_10_CM_Category", "ICD_10_CM_DiagnosisSectionCodeID", "dbo.ICD_10_CM_DiagnosisSectionCode");
            DropForeignKey("dbo.ICD_10_CM_DiagnosisSectionCode", "ICD_10_CM_DiagnosisCodeID", "dbo.ICD_10_CM_DiagnosisCode");
            DropForeignKey("dbo.ICD_10_CM_DiagnosisCode", "ICD_10_CM_CodeRangeID", "dbo.ICD_10_CM_CodeRange");
            DropIndex("dbo.ICD_10_CM_DiagnosisCode", new[] { "ICD_10_CM_CodeRangeID" });
            DropIndex("dbo.ICD_10_CM_DiagnosisSectionCode", new[] { "ICD_10_CM_DiagnosisCodeID" });
            DropIndex("dbo.ICD_10_CM_Category", new[] { "ICD_10_CM_DiagnosisSectionCodeID" });
            DropTable("dbo.ICD_10_CM_CodeRange");
            DropTable("dbo.ICD_10_CM_DiagnosisCode");
            DropTable("dbo.ICD_10_CM_DiagnosisSectionCode");
            DropTable("dbo.ICD_10_CM_Category");
        }
    }
}
