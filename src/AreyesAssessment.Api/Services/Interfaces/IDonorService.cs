using AreyesAssessment.API.DTOs;
using AreyesAssessment.Data.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreyesAssessment.API.Services.Interfaces
{
    public interface IDonorService
    {
        Task<IEnumerable<DonorDto>> GetAllAsync();
        Task<IEnumerable<DonorDto>> GetFilteredAsync(DonorFilter filter);
        Task<DonorDto> GetByIdAsync(int id);
        Task<DonorDto> CreateAsync(DonorDto donorDto);
        Task<DonorDto> UpdateAsync(DonorDto donorDto);
        Task<bool> DeleteAsync(int id);
    }
}
