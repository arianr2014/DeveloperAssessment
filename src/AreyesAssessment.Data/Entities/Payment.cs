using System;
using System.Collections.Generic;

namespace AreyesAssessment.Data.Entities
{
    public class Payment
    { 
        
    public int PaymentID { get; set; }
    public int DonorID { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }

    public Donor Donor { get; set; } = null!;

    // Cambia la colección de Pledges a una colección de la tabla intermedia PledgePayment
    public ICollection<PledgePayment> PledgePayments { get; set; } = new List<PledgePayment>();

    }
}
