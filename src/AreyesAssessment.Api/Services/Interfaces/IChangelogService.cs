using AreyesAssessment.API.DTOs;
using AreyesAssessment.Data.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreyesAssessment.API.Services.Interfaces
{
    public interface IChangelogService
    {
        Task<IEnumerable<ChangelogDto>> GetAllAsync()   ;

        Task<IEnumerable<ChangelogDto>> GetFilteredAsync(ChangelogFilter filter);

    }
}
