using System.ComponentModel.DataAnnotations;

namespace MCDP.Web.Models.M11
{
    public class TitlePage
    {
        public int Id { get; set; }

        public string SponsorConfidentiality { get; set; }

        [Required]
        public string FullTitle { get; set; }

        public string TrialAcronym { get; set; }

        public string SponsorName { get; set; }

        public string SponsorAddress { get; set; }

        [Required]
        public string ProtocolIdentifier { get; set; }

        public bool IsOriginalProtocol { get; set; }

        public string VersionNumber { get; set; }

        public DateTime? VersionDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
