using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreyesAssessment.Data.Entities
{
    public class PledgePayment
    {
        public int PledgeID { get; set; }
        public Pledge Pledge { get; set; } = null!;

        public int PaymentID { get; set; }
        public Payment Payment { get; set; } = null!;
    }
}