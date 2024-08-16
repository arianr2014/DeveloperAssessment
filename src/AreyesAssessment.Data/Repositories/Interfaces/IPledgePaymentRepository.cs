using AreyesAssessment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreyesAssessment.Data.Interfaces
{
    public interface IPledgePaymentRepository
    {
        Task<IEnumerable<PledgePayment>> GetAllAsync();
        Task<PledgePayment> GetByIdAsync(int pledgeId, int paymentId);
        Task AddAsync(PledgePayment pledgePayment);
        Task RemoveAsync(int pledgeId, int paymentId);
        Task<IEnumerable<PledgePayment>> GetByPledgeIdAsync(int pledgeId);
        Task<IEnumerable<PledgePayment>> GetByPaymentIdAsync(int paymentId);
    }
}
