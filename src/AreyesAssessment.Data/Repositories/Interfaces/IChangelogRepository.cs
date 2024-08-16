using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreyesAssessment.Data.Interfaces
{
    public interface IChangelogRepository
    {
        Task<IEnumerable<ChangeLog>> GetAllAsync();
        Task<IEnumerable<ChangeLog>> GetFilteredAsync(ChangelogFilter filter);
        Task<ChangeLog> GetByIdAsync(int id);
        Task<bool> AddAsync(ChangeLog changelog);
        Task<bool> UpdateAsync(ChangeLog changelog);
        Task DeleteAsync(int id);
    }
}