using System.Text.Json.Serialization;

namespace AreyesAssessment.API.DTOs
{
    public class DonorDto
    {
        
        public int DonorID { get; set; }
        public string DonorName { get; set; }
        public string Address { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
