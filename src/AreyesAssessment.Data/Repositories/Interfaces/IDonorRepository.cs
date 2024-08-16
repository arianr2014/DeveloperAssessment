using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreyesAssessment.Data.Interfaces
{
    public interface IDonorRepository
    {
        Task<IEnumerable<Donor>> GetAllAsync();
        Task<IEnumerable<Donor>> GetFilteredAsync(DonorFilter filter);
        Task<Donor> GetByIdAsync(int id);
        Task<Donor> AddAsync(Donor donor);
        Task<Donor> UpdateAsync(Donor donor);
        Task<bool> DeleteAsync(int id);
    }
}
