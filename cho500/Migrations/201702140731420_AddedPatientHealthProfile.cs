namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPatientHealthProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientHealthProfiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(nullable: false),
                        AdmittedBy = c.String(),
                        DateOfConsult = c.DateTime(nullable: false),
                        ChiefComplaint = c.String(),
                        BPFirstReading = c.String(),
                        BPSecondReading = c.String(),
                        PulseRate = c.Int(nullable: false),
                        RR = c.Int(nullable: false),
                        Temperature = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WeightInKgms = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HeightInCm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WaistCircumference = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PatientHealthProfiles");
        }
    }
}
