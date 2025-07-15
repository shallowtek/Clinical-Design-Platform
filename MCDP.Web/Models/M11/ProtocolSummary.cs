using System.ComponentModel.DataAnnotations;
namespace MCDP.Web.Models.M11
{
    public class ProtocolSummary
    {
        public int TitlePageId { get; set; }
        public int Id { get; set; }
        [Required] public string Synopsis { get; set; }
        [Required] public string ObjectivesAndEstimands { get; set; }
        public string OverallDesign { get; set; }
        public string TrialSchema { get; set; }
        // For Schedule of Activities we can store JSON or a separate table
        public string ScheduleJson { get; set; }
    }
}