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
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IMapper _mapper;

        public DonorService(IDonorRepository donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DonorDto>> GetAllAsync()
        {
            var donors = await _donorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DonorDto>>(donors);
        }

        public async Task<DonorDto> GetByIdAsync(int id)
        {
            var donor = await _donorRepository.GetByIdAsync(id);
            return _mapper.Map<DonorDto>(donor);
        }

        public async Task<IEnumerable<DonorDto>> GetFilteredAsync(DonorFilter filter)
        {
            var filteredDonors = await _donorRepository.GetFilteredAsync(filter);
            return _mapper.Map<IEnumerable<DonorDto>>(filteredDonors);
        }


        public async Task<DonorDto> CreateAsync(DonorDto donorDto)
        {
            var donor = _mapper.Map<Donor>(donorDto);
            var createdDonor = await _donorRepository.AddAsync(donor);
            return _mapper.Map<DonorDto>(createdDonor);
        }

        public async Task<DonorDto> UpdateAsync(DonorDto donorDto)
        {
            var donor = _mapper.Map<Donor>(donorDto);
            var updateDonor =await _donorRepository.UpdateAsync(donor);
            return _mapper.Map<DonorDto>(updateDonor);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _donorRepository.DeleteAsync(id);
        }
    }
}
