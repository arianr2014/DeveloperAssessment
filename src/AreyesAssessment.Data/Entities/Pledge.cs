using System;
using System.Collections.Generic;

namespace AreyesAssessment.Data.Entities
{
    public class Pledge
    {
    public int PledgeID { get; set; }
    public int DonorID { get; set; }
    public DateTime PledgeDate { get; set; }
    public decimal PledgeAmount { get; set; }

    public Donor Donor { get; set; } = null!;

    // Cambia la colección de Payments a una colección de la tabla intermedia PledgePayment
    public ICollection<PledgePayment> PledgePayments { get; set; } = new List<PledgePayment>();

  
    }
}
