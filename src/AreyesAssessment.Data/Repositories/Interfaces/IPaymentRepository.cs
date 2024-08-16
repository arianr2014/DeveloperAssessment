using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreyesAssessment.Data.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<IEnumerable<Payment>> GetFilteredAsync(PaymentFilter filter);
        Task<Payment> GetByIdAsync(int id);
        Task<Payment> AddAsync(Payment payment);
        Task<bool> UpdateAsync(Payment payment);
        Task<bool> DeleteAsync(int id);
    }
}
