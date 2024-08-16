using System.Collections.Generic;

namespace AreyesAssessment.Data.Entities
{
    public class Donor
    { public int DonorID { get; set; }
        public string DonorName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool ActiveStatus { get; set; } = true;

        // Relación uno a muchos con Pledges
        public ICollection<Pledge> Pledges { get; set; } = new List<Pledge>();

        // Relación uno a muchos con Payments
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
