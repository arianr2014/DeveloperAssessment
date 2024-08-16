using System.Text.Json.Serialization;

namespace AreyesAssessment.API.DTOs
{
    public class PledgeDto
    {
        
        public int PledgeID { get; set; }
        public int DonorID { get; set; }
        public decimal PledgeAmount { get; set; }
        public DateTime PledgeDate { get; set; }
    }
}
