using AreyesAssessment.API.DTOs;
using AreyesAssessment.Data.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreyesAssessment.API.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        Task<IEnumerable<PaymentDto>> GetFilteredAsync(PaymentFilter filter);
        Task<PaymentDto> GetByIdAsync(int id);
        Task<PaymentDto> CreateAsync(PaymentDto paymentDto);
        Task<bool> UpdateAsync(PaymentDto paymentDto);
        Task<bool> DeleteAsync(int id);
    }
}
