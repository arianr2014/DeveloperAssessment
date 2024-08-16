using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreyesAssessment.Data.Interfaces
{
    public interface IPledgeRepository
    {
        Task<IEnumerable<Pledge>> GetAllAsync();
        Task<IEnumerable<Pledge>> GetFilteredAsync(PledgeFilter filter);
        Task<Pledge> GetByIdAsync(int id);
        Task<Pledge> AddAsync(Pledge pledge);
        Task<bool> UpdateAsync(Pledge pledge);
        Task<bool> DeleteAsync(int id);
    }
}
