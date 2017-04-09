namespace cho500.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChildHealthRecords", "BloodTypeID", "dbo.BloodTypes");
            DropForeignKey("dbo.People", "BarangayID", "dbo.Barangays");
            DropIndex("dbo.ChildHealthRecords", new[] { "BloodTypeID" });
            DropIndex("dbo.People", new[] { "BarangayID" });
            CreateTable(
                "dbo.HouseHoldClassificationPerVisits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Classification = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HouseholdMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseholdProfileID = c.String(nullable: false),
                        PersonID = c.Int(nullable: false),
                        RelationToHead = c.Int(nullable: false),
                        HouseholdProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.HouseholdProfiles", t => t.HouseholdProfile_Id)
                .Index(t => t.PersonID)
                .Index(t => t.HouseholdProfile_Id);
            
            CreateTable(
                "dbo.HouseholdProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseholdProfileID = c.String(nullable: false),
                        FourPsCCTBeneficiary = c.Boolean(nullable: false),
                        Address = c.String(),
                        BarangayID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barangays", t => t.BarangayID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.BarangayID)
                .Index(t => t.PersonID);
            
            AddColumn("dbo.ChildBirthFollowUpVisits", "PhysicianID", c => c.Int(nullable: false));
            AddColumn("dbo.People", "ExtensionName", c => c.String(maxLength: 3));
            AddColumn("dbo.People", "NameTittle", c => c.String(maxLength: 25));
            AddColumn("dbo.People", "HighestEducationalAttainment", c => c.Int(nullable: false));
            AddColumn("dbo.People", "EducationStats", c => c.Int(nullable: false));
            AddColumn("dbo.People", "Degree", c => c.String());
            AddColumn("dbo.People", "Religion", c => c.String(maxLength: 50));
            AddColumn("dbo.People", "PlaceOfBirth", c => c.String());
            AddColumn("dbo.People", "WorkSkills", c => c.String());
            AddColumn("dbo.People", "EmploymentAgency", c => c.Int(nullable: false));
            AddColumn("dbo.People", "FatherPersonId", c => c.Int(nullable: false));
            AddColumn("dbo.People", "MotherPersonId", c => c.Int(nullable: false));
            AddColumn("dbo.People", "HouseholdProfileID", c => c.String());
            AddColumn("dbo.People", "PhilHealthNo", c => c.String());
            AddColumn("dbo.People", "PhicMembership", c => c.Int(nullable: false));
            AddColumn("dbo.People", "SponsoredMembership", c => c.Int(nullable: false));
            AddColumn("dbo.People", "IndividuallyPayingProgram", c => c.Int(nullable: false));
            AddColumn("dbo.People", "MembershipCategoryGroup", c => c.Int(nullable: false));
            AddColumn("dbo.People", "CurrentMembershipStatus", c => c.Int(nullable: false));
            AddColumn("dbo.People", "LandlineNumber", c => c.String());
            AddColumn("dbo.People", "EmergencyContactName", c => c.String(maxLength: 50));
            AddColumn("dbo.People", "EmergencyContactNumberCP", c => c.String());
            AddColumn("dbo.People", "EmergencyContactNumberLL", c => c.String());
            AddColumn("dbo.People", "Relation", c => c.String());
            AddColumn("dbo.People", "EmergencyContactBirthday", c => c.DateTime());
            AddColumn("dbo.People", "LastDateUpdated", c => c.DateTime());
            AddColumn("dbo.People", "BloodTypeID", c => c.Int());
            AddColumn("dbo.Consultations", "PhysicianID", c => c.Int(nullable: false));
            CreateIndex("dbo.ChildBirthFollowUpVisits", "PhysicianID");
            CreateIndex("dbo.People", "BloodTypeID");
            CreateIndex("dbo.Consultations", "PhysicianID");
            AddForeignKey("dbo.People", "BloodTypeID", "dbo.BloodTypes", "BloodTypeID");
            AddForeignKey("dbo.Consultations", "PhysicianID", "dbo.Physicians", "PhysicianID", cascadeDelete: true);
            AddForeignKey("dbo.ChildBirthFollowUpVisits", "PhysicianID", "dbo.Physicians", "PhysicianID", cascadeDelete: true);
            DropColumn("dbo.ChildBirthFollowUpVisits", "Physician");
            DropColumn("dbo.ChildHealthRecords", "BloodTypeID");
            DropColumn("dbo.People", "Address");
            DropColumn("dbo.People", "HouseholdNo");
            DropColumn("dbo.People", "BarangayID");
            DropColumn("dbo.Consultations", "Physician");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Consultations", "Physician", c => c.String());
            AddColumn("dbo.People", "BarangayID", c => c.Int(nullable: false));
            AddColumn("dbo.People", "HouseholdNo", c => c.Int(nullable: false));
            AddColumn("dbo.People", "Address", c => c.String());
            AddColumn("dbo.ChildHealthRecords", "BloodTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.ChildBirthFollowUpVisits", "Physician", c => c.String());
            DropForeignKey("dbo.HouseholdProfiles", "PersonID", "dbo.People");
            DropForeignKey("dbo.HouseholdMembers", "HouseholdProfile_Id", "dbo.HouseholdProfiles");
            DropForeignKey("dbo.HouseholdProfiles", "BarangayID", "dbo.Barangays");
            DropForeignKey("dbo.HouseholdMembers", "PersonID", "dbo.People");
            DropForeignKey("dbo.ChildBirthFollowUpVisits", "PhysicianID", "dbo.Physicians");
            DropForeignKey("dbo.Consultations", "PhysicianID", "dbo.Physicians");
            DropForeignKey("dbo.People", "BloodTypeID", "dbo.BloodTypes");
            DropIndex("dbo.HouseholdProfiles", new[] { "PersonID" });
            DropIndex("dbo.HouseholdProfiles", new[] { "BarangayID" });
            DropIndex("dbo.HouseholdMembers", new[] { "HouseholdProfile_Id" });
            DropIndex("dbo.HouseholdMembers", new[] { "PersonID" });
            DropIndex("dbo.Consultations", new[] { "PhysicianID" });
            DropIndex("dbo.People", new[] { "BloodTypeID" });
            DropIndex("dbo.ChildBirthFollowUpVisits", new[] { "PhysicianID" });
            DropColumn("dbo.Consultations", "PhysicianID");
            DropColumn("dbo.People", "BloodTypeID");
            DropColumn("dbo.People", "LastDateUpdated");
            DropColumn("dbo.People", "EmergencyContactBirthday");
            DropColumn("dbo.People", "Relation");
            DropColumn("dbo.People", "EmergencyContactNumberLL");
            DropColumn("dbo.People", "EmergencyContactNumberCP");
            DropColumn("dbo.People", "EmergencyContactName");
            DropColumn("dbo.People", "LandlineNumber");
            DropColumn("dbo.People", "CurrentMembershipStatus");
            DropColumn("dbo.People", "MembershipCategoryGroup");
            DropColumn("dbo.People", "IndividuallyPayingProgram");
            DropColumn("dbo.People", "SponsoredMembership");
            DropColumn("dbo.People", "PhicMembership");
            DropColumn("dbo.People", "PhilHealthNo");
            DropColumn("dbo.People", "HouseholdProfileID");
            DropColumn("dbo.People", "MotherPersonId");
            DropColumn("dbo.People", "FatherPersonId");
            DropColumn("dbo.People", "EmploymentAgency");
            DropColumn("dbo.People", "WorkSkills");
            DropColumn("dbo.People", "PlaceOfBirth");
            DropColumn("dbo.People", "Religion");
            DropColumn("dbo.People", "Degree");
            DropColumn("dbo.People", "EducationStats");
            DropColumn("dbo.People", "HighestEducationalAttainment");
            DropColumn("dbo.People", "NameTittle");
            DropColumn("dbo.People", "ExtensionName");
            DropColumn("dbo.ChildBirthFollowUpVisits", "PhysicianID");
            DropTable("dbo.HouseholdProfiles");
            DropTable("dbo.HouseholdMembers");
            DropTable("dbo.HouseHoldClassificationPerVisits");
            CreateIndex("dbo.People", "BarangayID");
            CreateIndex("dbo.ChildHealthRecords", "BloodTypeID");
            AddForeignKey("dbo.People", "BarangayID", "dbo.Barangays", "BarangayID", cascadeDelete: true);
            AddForeignKey("dbo.ChildHealthRecords", "BloodTypeID", "dbo.BloodTypes", "BloodTypeID", cascadeDelete: true);
        }
    }
}
