using AreyesAssessment.Data.Context;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Filters;
using AreyesAssessment.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace AreyesAssessment.Data.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;
        private readonly IChangelogRepository _changelogRepository;


        public PaymentRepository(AppDbContext context, IChangelogRepository changelogRepository)
        {
            _context = context;
            _changelogRepository = changelogRepository;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetFilteredAsync(PaymentFilter filter)
        {
            var expression = filter.ToExpression();
            return await _context.Payments.Where(expression).ToListAsync();
        }


        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<Payment> AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();

            // Log change
            var changelog = new ChangeLog
            {
                ChangeDate = DateTime.UtcNow,
                ChangeDescription = $"Added new payment with ID {payment.PaymentID}"
            };
            await _changelogRepository.AddAsync(changelog);

            return payment;
        }

        public async Task<bool> UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            var isUpdated =  await _context.SaveChangesAsync();

            // Log change
            var changelog = new ChangeLog
            {
                ChangeDate = DateTime.UtcNow,
                ChangeDescription = $"Added new payment with ID {payment.PaymentID}"
            };
            await _changelogRepository.AddAsync(changelog);

            return isUpdated > 0;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();

                // Log change
                var changelog = new ChangeLog
                {
                    ChangeDate = DateTime.UtcNow,
                    ChangeDescription = $"Added new payment with ID {id}"
                };
                await _changelogRepository.AddAsync(changelog);

                return true;
            }

            return false;
        }
    }
}
