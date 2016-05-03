namespace IsolDesign.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ApplicantId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Photo = c.String(),
                        Description = c.String(),
                        SkypeLink = c.String(),
                        Facebook = c.String(),
                        LinkedIn = c.String(),
                        Homepage = c.String(),
                    })
                .PrimaryKey(t => t.ApplicantId);
            
            CreateTable(
                "dbo.Competencies",
                c => new
                    {
                        CompetencyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CompetencyId);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        PartnerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Photo = c.String(),
                        Description = c.String(),
                        SkypeLink = c.String(),
                        Facebook = c.String(),
                        LinkedIn = c.String(),
                        Homepage = c.String(),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartnerId)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        WorkTitle = c.String(),
                        Type = c.String(),
                        Description = c.String(),
                        Photo = c.String(),
                        Drawing = c.String(),
                        Video = c.String(),
                        PartnerId = c.Int(),
                        Credits = c.String(),
                        Deadline = c.DateTime(),
                        CustomerId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.Partners", t => t.PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.PartnerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.PortfolioSubjects",
                c => new
                    {
                        PortfolioSubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Photo1 = c.String(),
                        Photo2 = c.String(),
                        Photo3 = c.String(),
                        PartnerId = c.Int(nullable: false),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PortfolioSubjectId)
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("dbo.Partners", t => t.PartnerId, cascadeDelete: true)
                .Index(t => t.PartnerId)
                .Index(t => t.ApplicantId);
            
            CreateTable(
                "dbo.Subcontractors",
                c => new
                    {
                        SubcontractorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Homepage = c.String(),
                        ContactName = c.String(),
                        ContactPhone = c.String(),
                        ContactEmail = c.String(),
                        PartnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubcontractorId)
                .ForeignKey("dbo.Partners", t => t.PartnerId, cascadeDelete: true)
                .Index(t => t.PartnerId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        DevMethodId = c.Int(nullable: false),
                        EconomyId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                        ProjectLeader_PartnerId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: false) // ************ changed this to false
                .ForeignKey("dbo.DevMethods", t => t.DevMethodId, cascadeDelete: true)
                .ForeignKey("dbo.Economies", t => t.EconomyId, cascadeDelete: true)
                .ForeignKey("dbo.Partners", t => t.ProjectLeader_PartnerId)
                .Index(t => t.DevMethodId)
                .Index(t => t.EconomyId)
                .Index(t => t.AssignmentId)
                .Index(t => t.ProjectLeader_PartnerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Category = c.Int(nullable: false),
                        Homepage = c.String(),
                        ContactName = c.String(),
                        ContactPhone = c.String(),
                        ContactEmail = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.DevMethods",
                c => new
                    {
                        DevMethodId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DevMethodId);
            
            CreateTable(
                "dbo.Economies",
                c => new
                    {
                        EconomyId = c.Int(nullable: false, identity: true),
                        Offer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaterialCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalHours = c.Int(nullable: false),
                        HourPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatusHours = c.Int(nullable: false),
                        StatusMaterials = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatusTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatusDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EconomyId);
            
            CreateTable(
                "dbo.Patents",
                c => new
                    {
                        PatentId = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Description = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatentId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
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
                "dbo.CompetencyApplicants",
                c => new
                    {
                        Competency_CompetencyId = c.Int(nullable: false),
                        Applicant_ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Competency_CompetencyId, t.Applicant_ApplicantId })
                .ForeignKey("dbo.Competencies", t => t.Competency_CompetencyId, cascadeDelete: true)
                .ForeignKey("dbo.Applicants", t => t.Applicant_ApplicantId, cascadeDelete: true)
                .Index(t => t.Competency_CompetencyId)
                .Index(t => t.Applicant_ApplicantId);
            
            CreateTable(
                "dbo.PartnerCompetencies",
                c => new
                    {
                        Partner_PartnerId = c.Int(nullable: false),
                        Competency_CompetencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Partner_PartnerId, t.Competency_CompetencyId })
                .ForeignKey("dbo.Partners", t => t.Partner_PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.Competencies", t => t.Competency_CompetencyId, cascadeDelete: true)
                .Index(t => t.Partner_PartnerId)
                .Index(t => t.Competency_CompetencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Teams", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectLeader_PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Patents", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "EconomyId", "dbo.Economies");
            DropForeignKey("dbo.Projects", "DevMethodId", "dbo.DevMethods");
            DropForeignKey("dbo.Projects", "AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.Assignments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Partners", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Subcontractors", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.PortfolioSubjects", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.PortfolioSubjects", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.PartnerCompetencies", "Competency_CompetencyId", "dbo.Competencies");
            DropForeignKey("dbo.PartnerCompetencies", "Partner_PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Assignments", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.CompetencyApplicants", "Applicant_ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.CompetencyApplicants", "Competency_CompetencyId", "dbo.Competencies");
            DropIndex("dbo.PartnerCompetencies", new[] { "Competency_CompetencyId" });
            DropIndex("dbo.PartnerCompetencies", new[] { "Partner_PartnerId" });
            DropIndex("dbo.CompetencyApplicants", new[] { "Applicant_ApplicantId" });
            DropIndex("dbo.CompetencyApplicants", new[] { "Competency_CompetencyId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Patents", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "ProjectLeader_PartnerId" });
            DropIndex("dbo.Projects", new[] { "AssignmentId" });
            DropIndex("dbo.Projects", new[] { "EconomyId" });
            DropIndex("dbo.Projects", new[] { "DevMethodId" });
            DropIndex("dbo.Teams", new[] { "ProjectId" });
            DropIndex("dbo.Subcontractors", new[] { "PartnerId" });
            DropIndex("dbo.PortfolioSubjects", new[] { "ApplicantId" });
            DropIndex("dbo.PortfolioSubjects", new[] { "PartnerId" });
            DropIndex("dbo.Assignments", new[] { "CustomerId" });
            DropIndex("dbo.Assignments", new[] { "PartnerId" });
            DropIndex("dbo.Partners", new[] { "TeamId" });
            DropTable("dbo.PartnerCompetencies");
            DropTable("dbo.CompetencyApplicants");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Patents");
            DropTable("dbo.Economies");
            DropTable("dbo.DevMethods");
            DropTable("dbo.Customers");
            DropTable("dbo.Projects");
            DropTable("dbo.Teams");
            DropTable("dbo.Subcontractors");
            DropTable("dbo.PortfolioSubjects");
            DropTable("dbo.Assignments");
            DropTable("dbo.Partners");
            DropTable("dbo.Competencies");
            DropTable("dbo.Applicants");
        }
    }
}
