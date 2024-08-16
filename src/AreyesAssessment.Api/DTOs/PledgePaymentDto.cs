using AreyesAssessment.API.DTOs;
using System.Text.Json.Serialization;

namespace AreyesAssessment.Api.DTOs
{
    public class PledgePaymentDto
    {
        public int PledgeID { get; set; }
        public int PaymentID { get; set; }
        
        public PledgeDto Pledge { get; set; }
        
        public PaymentDto Payment { get; set; }
    }
}
