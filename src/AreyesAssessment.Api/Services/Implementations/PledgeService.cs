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
    public class PledgeService : IPledgeService
    {
        private readonly IPledgeRepository _pledgeRepository;
        private readonly IMapper _mapper;

        public PledgeService(IPledgeRepository pledgeRepository, IMapper mapper)
        {
            _pledgeRepository = pledgeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PledgeDto>> GetAllAsync()
        {
            var pledges = await _pledgeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PledgeDto>>(pledges);
        }

        public async Task<IEnumerable<PledgeDto>> GetFilteredAsync(PledgeFilter filter)
        {
            var filteredPledges = await _pledgeRepository.GetFilteredAsync(filter);
            return _mapper.Map<IEnumerable<PledgeDto>>(filteredPledges);
        }


        public async Task<PledgeDto> GetByIdAsync(int id)
        {
            var pledge = await _pledgeRepository.GetByIdAsync(id);
            return _mapper.Map<PledgeDto>(pledge);
        }

        public async Task<PledgeDto> CreateAsync(PledgeDto pledgeDto)
        {
            var pledge = _mapper.Map<Pledge>(pledgeDto);
            var createdPledge = await _pledgeRepository.AddAsync(pledge);
            return _mapper.Map<PledgeDto>(createdPledge);
        }

        public async Task<bool> UpdateAsync(PledgeDto pledgeDto)
        {
            var pledge = _mapper.Map<Pledge>(pledgeDto);
            return await _pledgeRepository.UpdateAsync(pledge);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _pledgeRepository.DeleteAsync(id);
        }
    }
}
