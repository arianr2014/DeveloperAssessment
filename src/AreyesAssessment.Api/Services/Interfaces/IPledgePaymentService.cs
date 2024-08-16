using AreyesAssessment.Api.DTOs;


namespace AreyesAssessment.API.Services.Interfaces
{
    public interface IPledgePaymentService
    {
        Task<IEnumerable<PledgePaymentDto>> GetAllAsync();
        Task<PledgePaymentDto> GetByIdAsync(int pledgeId, int paymentId);
        Task AddAsync(PledgePaymentDto pledgePaymentDto);
        Task RemoveAsync(int pledgeId, int paymentId);
        Task<IEnumerable<PledgePaymentDto>> GetByPledgeIdAsync(int pledgeId);
        Task<IEnumerable<PledgePaymentDto>> GetByPaymentIdAsync(int paymentId);
    }
}
