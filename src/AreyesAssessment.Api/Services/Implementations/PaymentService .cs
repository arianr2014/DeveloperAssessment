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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var payments = await _paymentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<IEnumerable<PaymentDto>> GetFilteredAsync(PaymentFilter filter)
        {
            var filteredPayments = await _paymentRepository.GetFilteredAsync(filter);
            return _mapper.Map<IEnumerable<PaymentDto>>(filteredPayments);
        }

        public async Task<PaymentDto> GetByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<PaymentDto> CreateAsync(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            var createdPayment = await _paymentRepository.AddAsync(payment);
            return _mapper.Map<PaymentDto>(createdPayment);
        }

        public async Task<bool> UpdateAsync(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            return await _paymentRepository.UpdateAsync(payment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _paymentRepository.DeleteAsync(id);
        }
    }
}
