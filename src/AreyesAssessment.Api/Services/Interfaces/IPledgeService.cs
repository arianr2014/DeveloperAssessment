using AreyesAssessment.API.DTOs;
using AreyesAssessment.Data.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreyesAssessment.API.Services.Interfaces
{
    public interface IPledgeService
    {
        Task<IEnumerable<PledgeDto>> GetAllAsync();
        Task<IEnumerable<PledgeDto>> GetFilteredAsync(PledgeFilter filter);

        Task<PledgeDto> GetByIdAsync(int id);
        Task<PledgeDto> CreateAsync(PledgeDto pledgeDto);
        Task<bool> UpdateAsync(PledgeDto pledgeDto);
        Task<bool> DeleteAsync(int id);
    }
}
