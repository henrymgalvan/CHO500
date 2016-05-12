namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barangays",
                c => new
                    {
                        BarangayID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BarangayID);
            
            CreateTable(
                "dbo.ChildBirthFollowUpVisitIndexViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        DateOfFollowup = c.DateTime(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diagnosis = c.String(),
                        Notes = c.String(),
                        PersonID = c.Int(nullable: false),
                        Physician_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Staffs", t => t.Physician_Id)
                .Index(t => t.Physician_Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Position = c.Int(nullable: false),
                        Title = c.String(),
                        DateHired = c.DateTime(nullable: false),
                        DateTerminated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChildHealthRecords",
                c => new
                    {
                        PersonID = c.Int(nullable: false),
                        Months = c.Int(nullable: false),
                        Weeks = c.Int(nullable: false),
                        Days = c.Int(nullable: false),
                        TypeOfDelivery = c.String(),
                        BirthWeightInPounds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BirthLength = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HeadCircumference = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChestCircumference = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AbdominalCircumference = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BloodType = c.String(),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.People", t => t.PersonID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.ChildBirthFollowUpVisits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        DateOfFollowup = c.DateTime(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diagnosis = c.String(),
                        Notes = c.String(),
                        PersonID = c.Int(nullable: false),
                        Physician_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChildHealthRecords", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.Physician_Id)
                .Index(t => t.PersonID)
                .Index(t => t.Physician_Id);
            
            CreateTable(
                "dbo.ChildImmunizatonRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VaccineID = c.Int(nullable: false),
                        First = c.DateTime(nullable: false),
                        Second = c.DateTime(nullable: false),
                        Third = c.DateTime(nullable: false),
                        Booster1 = c.DateTime(nullable: false),
                        Booster2 = c.DateTime(nullable: false),
                        Booster3 = c.DateTime(nullable: false),
                        Reaction = c.String(),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChildHealthRecords", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        CivilStatus = c.Int(nullable: false),
                        Address = c.String(),
                        HouseholdNo = c.Int(nullable: false),
                        ContactNumber = c.String(),
                        Encoder = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Notes = c.String(),
                        BarangayID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.Barangays", t => t.BarangayID, cascadeDelete: true)
                .Index(t => t.BarangayID);
            
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ConsultationID = c.Int(nullable: false, identity: true),
                        AdmittedBy = c.String(),
                        DateOfConsult = c.DateTime(nullable: false),
                        PreviousConsultDate = c.DateTime(nullable: false),
                        PreviousConsult = c.Int(nullable: false),
                        ChiefComplaint = c.String(),
                        Age = c.Int(nullable: false),
                        BPFirstReading = c.String(),
                        BPSecondReading = c.String(),
                        BPAverage = c.String(),
                        RaisedBP = c.Boolean(nullable: false),
                        PulseRate = c.Int(nullable: false),
                        RR = c.Int(nullable: false),
                        Temperature = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WeightInKgms = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HeightInCm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WaistCircumferenceInCm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CentralAdiposity = c.Boolean(nullable: false),
                        BMI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BMIStatus = c.Int(nullable: false),
                        History = c.String(),
                        PhysicalExam = c.String(),
                        DiagnosisLabResult = c.String(),
                        ManagementTreatment = c.String(),
                        Recommendation = c.String(),
                        Pharmacy = c.String(),
                        Physician = c.String(),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultationID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.Physicians",
                c => new
                    {
                        PhysicianID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PhysicianID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vaccines",
                c => new
                    {
                        VaccineID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.VaccineID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ChildHealthRecords", "PersonID", "dbo.People");
            DropForeignKey("dbo.Consultations", "PersonID", "dbo.People");
            DropForeignKey("dbo.People", "BarangayID", "dbo.Barangays");
            DropForeignKey("dbo.ChildImmunizatonRecords", "PersonID", "dbo.ChildHealthRecords");
            DropForeignKey("dbo.ChildBirthFollowUpVisits", "Physician_Id", "dbo.Staffs");
            DropForeignKey("dbo.ChildBirthFollowUpVisits", "PersonID", "dbo.ChildHealthRecords");
            DropForeignKey("dbo.ChildBirthFollowUpVisitIndexViewModels", "Physician_Id", "dbo.Staffs");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Consultations", new[] { "PersonID" });
            DropIndex("dbo.People", new[] { "BarangayID" });
            DropIndex("dbo.ChildImmunizatonRecords", new[] { "PersonID" });
            DropIndex("dbo.ChildBirthFollowUpVisits", new[] { "Physician_Id" });
            DropIndex("dbo.ChildBirthFollowUpVisits", new[] { "PersonID" });
            DropIndex("dbo.ChildHealthRecords", new[] { "PersonID" });
            DropIndex("dbo.ChildBirthFollowUpVisitIndexViewModels", new[] { "Physician_Id" });
            DropTable("dbo.Vaccines");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Physicians");
            DropTable("dbo.Consultations");
            DropTable("dbo.People");
            DropTable("dbo.ChildImmunizatonRecords");
            DropTable("dbo.ChildBirthFollowUpVisits");
            DropTable("dbo.ChildHealthRecords");
            DropTable("dbo.Staffs");
            DropTable("dbo.ChildBirthFollowUpVisitIndexViewModels");
            DropTable("dbo.Barangays");
        }
    }
}
