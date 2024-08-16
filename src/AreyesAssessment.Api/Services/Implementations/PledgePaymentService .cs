using AreyesAssessment.Api.DTOs;
using AreyesAssessment.API.Services.Interfaces;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreyesAssessment.API.Services.Implementations
{
    public class PledgePaymentService : IPledgePaymentService
    {
        private readonly IPledgePaymentRepository _pledgePaymentRepository;
        private readonly IMapper _mapper;

        public PledgePaymentService(IPledgePaymentRepository pledgePaymentRepository, IMapper mapper)
        {
            _pledgePaymentRepository = pledgePaymentRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PledgePaymentDto>> GetAllAsync()
        {
            var pledgePayments = await _pledgePaymentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PledgePaymentDto>>(pledgePayments);
        }

        public async Task<PledgePaymentDto> GetByIdAsync(int pledgeId, int paymentId)
        {
            var pledgePayment = await _pledgePaymentRepository.GetByIdAsync(pledgeId, paymentId);
            return _mapper.Map<PledgePaymentDto>(pledgePayment);
        }

        public async Task AddAsync(PledgePaymentDto pledgePaymentDto)
        {
            var pledgePayment = _mapper.Map<PledgePayment>(pledgePaymentDto);
            await _pledgePaymentRepository.AddAsync(pledgePayment);
        }

        public async Task RemoveAsync(int pledgeId, int paymentId)
        {
            await _pledgePaymentRepository.RemoveAsync(pledgeId, paymentId);
        }

        public async Task<IEnumerable<PledgePaymentDto>> GetByPledgeIdAsync(int pledgeId)
        {
            var pledgePayments = await _pledgePaymentRepository.GetByPledgeIdAsync(pledgeId);
            return _mapper.Map<IEnumerable<PledgePaymentDto>>(pledgePayments);
        }

        public async Task<IEnumerable<PledgePaymentDto>> GetByPaymentIdAsync(int paymentId)
        {
            var pledgePayments = await _pledgePaymentRepository.GetByPaymentIdAsync(paymentId);
            return _mapper.Map<IEnumerable<PledgePaymentDto>>(pledgePayments);
        }
    }
}
