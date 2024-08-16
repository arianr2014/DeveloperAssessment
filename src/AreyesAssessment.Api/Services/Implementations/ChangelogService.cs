using AreyesAssessment.API.DTOs;
using AreyesAssessment.API.Services.Interfaces;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Filters;
using AreyesAssessment.Data.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreyesAssessment.API.Services.Implementations
{
    public class ChangelogService : IChangelogService
    {
        private readonly IChangelogRepository _changelogRepository;
        private readonly IMapper _mapper;

        public ChangelogService(IChangelogRepository changelogRepository, IMapper mapper)
        {
            _changelogRepository = changelogRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChangelogDto>> GetAllAsync()
        {
            var changelogs = await _changelogRepository.GetAllAsync(); // Uso del método simple
            return _mapper.Map<IEnumerable<ChangelogDto>>(changelogs);
        }

        public async Task<IEnumerable<ChangelogDto>> GetFilteredAsync(ChangelogFilter filter)
        {
            var filteredChangelogs = await _changelogRepository.GetFilteredAsync(filter);
            return _mapper.Map<IEnumerable<ChangelogDto>>(filteredChangelogs);
        }
    }
}
