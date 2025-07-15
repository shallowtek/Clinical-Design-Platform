using MCDP.Web.Models.USDM;
using MCDP.Web.Models.M11;
using Microsoft.EntityFrameworkCore;
using Endpoint = MCDP.Web.Models.USDM.Endpoint;

public class ClinicalDbContext : DbContext
{
    public ClinicalDbContext(DbContextOptions<ClinicalDbContext> options)
        : base(options) { }

    public DbSet<TitlePage> TitlePages { get; set; }

    public DbSet<ProtocolSummary> ProtocolSummaries { get; set; }

    public DbSet<Study> Studies { get; set; }
    public DbSet<Identifier> Identifiers { get; set; }
    public DbSet<Arm> Arms { get; set; }
    public DbSet<Epoch> Epochs { get; set; }
    public DbSet<Objective> Objectives { get; set; }
    public DbSet<Criterion> Criteria { get; set; }
    public DbSet<Intervention> Interventions { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Endpoint> Endpoints { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<ArmEpoch> ArmEpochs { get; set; }
    public DbSet<Revision> RevisionHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var study1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var study2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");

        modelBuilder.Entity<ProtocolSummary>().HasData(

             new ProtocolSummary
             {
                 Id = 1,
                 Synopsis = "A Phase I, open-label study to evaluate safety and tolerability of Compound X in healthy volunteers.",
                 ObjectivesAndEstimands = "Primary: assess safety and tolerability; Secondary: characterize pharmacokinetics.",
                 OverallDesign = "Open-label, single ascending dose.",
                 TrialSchema = "Single arm, dose escalation.",
                 ScheduleJson = @"[
                {""VisitName"":""Screening"",""Day"":-14,""Activity"":""Consent, eligibility""},
                {""VisitName"":""Day 1"",""Day"":1,""Activity"":""Dosing, PK sampling""},
                {""VisitName"":""Follow-up"",""Day"":28,""Activity"":""Safety assessments""}
            ]"
             },
        new ProtocolSummary
        {
            Id = 2,
            Synopsis = "A Phase II, randomized, double-blind, placebo-controlled study to evaluate efficacy of Drug A in patients with chronic kidney disease.",
            ObjectivesAndEstimands = "Primary: change in glomerular filtration rate (GFR); Secondary: safety and tolerability.",
            OverallDesign = "Randomized, double-blind, placebo-controlled, parallel-group.",
            TrialSchema = "Two-arm parallel, randomization 2:1 (Drug A : Placebo).",
            ScheduleJson = @"[
                {""VisitName"":""Screening"",""Day"":-28,""Activity"":""Consent, lab tests""},
                {""VisitName"":""Baseline"",""Day"":0,""Activity"":""Randomization, first dose""},
                {""VisitName"":""Week 12"",""Day"":84,""Activity"":""Efficacy assessment""},
                {""VisitName"":""Follow-up"",""Day"":90,""Activity"":""Safety follow-up""}
            ]"
        },
        new ProtocolSummary
        {
            Id = 3,
            Synopsis = "An observational registry to assess long-term outcomes of biologic therapy in rheumatoid arthritis patients.",
            ObjectivesAndEstimands = "Primary: treatment patterns and long-term safety; Secondary: patient-reported outcomes.",
            OverallDesign = "Multicenter, prospective observational registry.",
            TrialSchema = "Annual visits over 5 years.",
            ScheduleJson = @"[
                {""VisitName"":""Enrollment"",""Day"":0,""Activity"":""Consent, baseline assessments""},
                {""VisitName"":""Year 1"",""Day"":365,""Activity"":""Clinical evaluation""},
                {""VisitName"":""Year 2"",""Day"":730,""Activity"":""Clinical evaluation""}
            ]"
        }

        );

        // Seed initial data for TitlePages
        modelBuilder.Entity<TitlePage>().HasData(
              new TitlePage
              {
                  Id = 1,
                  SponsorConfidentiality = "Sponsor confidential — do not distribute",
                  FullTitle = "A Randomized, Double-Blind, Placebo-Controlled Study of Compound X in Subjects with Condition Y",
                  TrialAcronym = "RX-YZ",
                  SponsorName = "PharmaCo Inc.",
                  SponsorAddress = "123 Clinical Road, Research City, Country",
                  ProtocolIdentifier = "PC-2025-001",
                  IsOriginalProtocol = true,
                  VersionNumber = "1.0",
                  VersionDate = new DateTime(2025, 2, 3),
                  CreatedDate = new DateTime(2025, 1, 4)
              },
            new TitlePage
            {
                Id = 2,
                SponsorConfidentiality = "Internal use only — confidentiality applies",
                FullTitle = "A Phase II, Multicenter, Open-Label Study of Drug A in Patients with Chronic Kidney Disease",
                TrialAcronym = "CKD-A2",
                SponsorName = "RenalHealth Ltd.",
                SponsorAddress = "45 Nephron Ave, MedCity, Country",
                ProtocolIdentifier = "RH-CKD-2025-002",
                IsOriginalProtocol = false,
                VersionNumber = "2.1",
                VersionDate = new DateTime(2025, 4, 15),
                CreatedDate = new DateTime(2025, 1, 3)
            },
            new TitlePage
            {
                Id = 3,
                SponsorConfidentiality = "Confidential — do not circulate externally",
                FullTitle = "An Observational Registry to Evaluate Long-Term Outcomes of Biologic Therapy in Rheumatoid Arthritis",
                TrialAcronym = "BioRA",
                SponsorName = "ImmuneTech Corp.",
                SponsorAddress = "789 Pharma Park, BioTown, Country",
                ProtocolIdentifier = "IT-RA-2025-003",
                IsOriginalProtocol = true,
                VersionNumber = "1.0",
                VersionDate = new DateTime(2025, 1, 20),
                CreatedDate = new DateTime(2025, 1, 2)
            },
            new TitlePage
            {
                Id = 4,
                SponsorConfidentiality = "Company confidential — internal distribution only",
                FullTitle = "A Phase III, Double-Blind, Placebo-Controlled Trial of Vaccine V Against Virus Z in Healthy Adults",
                TrialAcronym = "VAC-Z",
                SponsorName = "GlobalVax Biotech",
                SponsorAddress = "101 Vaccine Blvd, ImmunoCity, Country",
                ProtocolIdentifier = "GV-2025-004",
                IsOriginalProtocol = true,
                VersionNumber = "3.0",
                VersionDate = new DateTime(2025, 5, 10),
                CreatedDate = new DateTime(2025, 1, 1)
            }
        );



        modelBuilder.Entity<Study>().HasData(
            new Study
            {
                Id = study1Id,
                Title = "XYZ-101 in Type 2 Diabetes",
                ProtocolIdentifier = "XYZ-101-T2D-2025",
                CreatedOn = new DateTime(2025, 1, 1)
            },
            new Study
            {
                Id = study2Id,
                Title = "ABC-202 for Hypertension",
                ProtocolIdentifier = "ABC-202-HTN-2025",
                CreatedOn = new DateTime(2025, 2, 1)
            }
        );

        modelBuilder.Entity<Identifier>().HasData(
            new Identifier { Id = Guid.Parse("a1111111-0000-0000-0000-000000000001"), Type = "Sponsor ID", Value = "XYZ-101", StudyId = study1Id },
            new Identifier { Id = Guid.Parse("a1111111-0000-0000-0000-000000000002"), Type = "Sponsor ID", Value = "ABC-202", StudyId = study2Id }
        );

        modelBuilder.Entity<Objective>().HasData(
            new Objective { Id = Guid.Parse("b2222222-0000-0000-0000-000000000001"), Type = "Primary", Description = "Reduce HbA1c", StudyId = study1Id },
            new Objective { Id = Guid.Parse("b2222222-0000-0000-0000-000000000002"), Type = "Primary", Description = "Lower Systolic BP", StudyId = study2Id }
        );

        modelBuilder.Entity<Criterion>().HasData(
            new Criterion { Id = Guid.Parse("c3333333-0000-0000-0000-000000000001"), IsInclusion = true, Text = "Age 18-65", StudyId = study1Id },
            new Criterion { Id = Guid.Parse("c3333333-0000-0000-0000-000000000002"), IsInclusion = false, Text = "Renal failure", StudyId = study1Id },
            new Criterion { Id = Guid.Parse("c3333333-0000-0000-0000-000000000003"), IsInclusion = true, Text = "Age 30-75", StudyId = study2Id },
            new Criterion { Id = Guid.Parse("c3333333-0000-0000-0000-000000000004"), IsInclusion = false, Text = "Severe liver disease", StudyId = study2Id }
        );

        modelBuilder.Entity<Activity>().HasData(
            new Activity { Id = Guid.Parse("d4444444-0000-0000-0000-000000000001"), Name = "Blood Draw", Description = "Routine lab draw", Category = "Procedure", StudyId = study1Id },
            new Activity { Id = Guid.Parse("d4444444-0000-0000-0000-000000000002"), Name = "ECG", Description = "Electrocardiogram", Category = "Assessment", StudyId = study2Id }
        );

        modelBuilder.Entity<Endpoint>().HasData(
            new Endpoint { Id = Guid.Parse("e5555555-0000-0000-0000-000000000001"), Name = "HbA1c Reduction", Type = "Primary", Description = "Measured at week 12", StudyId = study1Id },
            new Endpoint { Id = Guid.Parse("e5555555-0000-0000-0000-000000000002"), Name = "BP Reduction", Type = "Primary", Description = "Measured at week 8", StudyId = study2Id }
        );

        modelBuilder.Entity<Visit>().HasData(
            new Visit { Id = Guid.Parse("f6666666-0000-0000-0000-000000000001"), Name = "Screening", Day = -14, StudyId = study1Id },
            new Visit { Id = Guid.Parse("f6666666-0000-0000-0000-000000000002"), Name = "Baseline", Day = 0, StudyId = study2Id }
        );
    }
}
