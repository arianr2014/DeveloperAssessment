using System.Text.Json.Serialization;

namespace AreyesAssessment.API.DTOs
{
    public class PaymentDto
    {
        //[JsonIgnore]
        public int PaymentID { get; set; }
        public int DonorID { get; set; }
    
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
