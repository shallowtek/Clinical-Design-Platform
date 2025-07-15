using MCDP.Web.Models.USDM;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class M11PdfExporter
{
    static Func<IContainer, IContainer> CellStyle => c =>
                   c.Border(1)
                    .BorderColor(Colors.Grey.Lighten2)
                    .Padding(2);

    static void RenderBulletList(IContainer container, IEnumerable<string> items)
    {
        container.Column(column =>
        {
            foreach (var item in items)
            {
                column.Item().Row(row =>
                {
                    row.ConstantColumn(10).Text("•");
                    row.RelativeColumn().Text(item).FontSize(10);
                });
            }
        });
    }


    public static byte[] Generate(Study study)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var doc = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(40);

                // Header
                page.Header().Text($"Protocol: {study.ProtocolIdentifier} — {study.Title}")
                              .FontSize(16)
                              .SemiBold();

                // Content
                page.Content().Column(column =>
                {
                    column.Spacing(20);

                    // 0 FOREWORD
                    column.Item().Element(c => RenderForeword(c, study));

                    // 1. Study Identification
                    column.Item().Element(c => RenderSection(c, "1. Study Identification", new[]
                    {
                        $"Sponsor Protocol Identifier: {study.ProtocolIdentifier}",
                        $"Full Title: {study.Title}"
                    }));

                    // 2. Protocol Summary
                    column.Item().Element(c => RenderSection(c, "2. Protocol Summary", new[]
                    {
                        "Provide brief summary and rationale of the study."
                    }));

                    // 3. Objectives and Purpose
                    column.Item().Element(c => RenderSection(c, "3. Objectives and Purpose", study.Objectives.Select(o => $"{o.Type}: {o.Description}")));

                    // 4. Study Design
                    column.Item().Element(c => RenderSection(c, "4. Study Design", new[]
                    {
                        "Describe design (e.g., randomized, double-blind, parallel-group, placebo-controlled)"
                    }));

                    // 5. Study Population – Criteria
                    column.Item().Element(c => RenderCriteriaSection(c, study));

                    // 6. Investigational Product(s)
                    column.Item().Element(c => RenderSection(c, "6. Investigational Product(s)", study.Interventions.Select(i => $"{i.Name}: {i.Description}")));

                    // 7. Schedule of Activities
                    column.Item().Element(c => RenderScheduleOfActivities(c, study));

                    // 8. Assessment Plan
                    column.Item().Element(c => RenderSection(c, "8. Assessment Plan", new[]
                    {
                        "Outline assessment methodologies and timing as per ICH M11 Appendix A."
                    }));

                    // 9. Safety Considerations
                    column.Item().Element(c => RenderSection(c, "9. Safety Considerations", new[]
                    {
                        "Describe safety monitoring, AE/SAE definitions, and reporting procedures."
                    }));

                    // 10. Statistical Analysis Plan
                    column.Item().Element(c => RenderSection(c, "10. Statistical Analysis Plan", new[]
                    {
                        "Detail statistical methods, analysis populations, and handling of missing data."
                    }));

                    // 11. Ethics and Dissemination
                    column.Item().Element(c => RenderSection(c, "11. Ethics and Dissemination", new[]
                    {
                        "State regulatory approvals, consent process, and dissemination plan."
                    }));

                    // 12. Appendices
                    column.Item().Element(c => RenderSection(c, "12. Appendices", new[]
                    {
                        "Include Schedule of Activities (Appendix A), Abbreviations (Appendix B), IC Form (Appendix C), etc."
                    }));
                });

                // Footer
                page.Footer().AlignRight().Text($"Generated: {DateTime.UtcNow:yyyy-MM-dd}");
            });
        });

        return doc.GeneratePdf();
    }

    static void RenderForeword(IContainer container, Study study)
    {
        container.Column(column =>
        {
            column.Spacing(10);
            column.Item().Text("0 FOREWORD").Bold().FontSize(14);

            // 0.1 Template Revision History
            column.Item().Text("0.1 Template Revision History").Bold();
            column.Item().Table(table =>
            {
                table.ColumnsDefinition(cols =>
                {
                    cols.ConstantColumn(60);
                    cols.RelativeColumn();
                });

                // Header
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("Date");





                    header.Cell().Element(CellStyle).Text("Description of Revision");
                });

                // Data rows (replace with actual revisions or default)
                foreach (var rev in study.RevisionHistory ?? new List<Revision>())
                {
                    table.Cell().Element(CellStyle).Text(rev.Date.ToString("yyyy-MM-dd"));
                    table.Cell().Element(CellStyle).Text(rev.Description);
                }

               
            });

            // 0.2 Intended Use
            column.Item().Text("0.2 Intended Use").Bold();
            column.Item().Text("This template is intended for interventional clinical trial protocols of the Investigational Product across all phases and therapeutic areas, structured per ICH M11 for consistency and electronic exchange.");

            // 0.3 Template Conventions
            column.Item().Text("0.3 Template Conventions and Instructions").Bold();
            column.Item().Element(c => RenderBulletList(c, new[]
            {
                "Universal text: appears in all protocols",
                "Conditional text {in braces}: include if applicable",
                "Optional text (blue): may be modified or removed",
                "Controlled terminology [in brackets]: pick-list values",
                "Remove all instructional text prior to finalization"
            }));
        });
    }

    static void RenderSection(IContainer container, string title, IEnumerable<string> items)
    {
        container.Column(column =>
        {
            column.Spacing(5);
            column.Item().Text(title).Bold();
            column.Item().Element(c => RenderBulletList(c, items));
        });
    }

    static void RenderCriteriaSection(IContainer container, Study study)
    {
        container.Column(column =>
        {
            column.Spacing(5);
            column.Item().Text("5. Study Population – Criteria").Bold();

            var incl = study.Criteria.Where(c => c.IsInclusion).Select(c => c.Text);
            var excl = study.Criteria.Where(c => !c.IsInclusion).Select(c => c.Text);

            if (incl.Any())
            {
                column.Item().Text("Inclusion:");
                column.Item().Element(c => RenderBulletList(c, incl));
            }

            if (excl.Any())
            {
                column.Item().Text("Exclusion:");
                column.Item().Element(c => RenderBulletList(c, excl));
            }
        });
    }

    static void RenderScheduleOfActivities(IContainer container, Study study)
    {
        container.Column(column =>
        {
            column.Spacing(5);
            column.Item().Text("7. Schedule of Activities").Bold();
            column.Item().Text("See Appendix A for detailed Schedule of Activities table formatted per ICH M11.");
        });
    }

}


