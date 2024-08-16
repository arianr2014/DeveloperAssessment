using AreyesAssessment.Data.Context;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;



namespace AreyesAssessment.Data.Repositories.Implementations
{
    public class PledgePaymentRepository : IPledgePaymentRepository
    {
        private readonly AppDbContext _context;
        private readonly IChangelogRepository _changelogRepository;

        public PledgePaymentRepository(AppDbContext context, IChangelogRepository changelogRepository)
        {
            _context = context;
            _changelogRepository = changelogRepository;

        }

        public async Task<IEnumerable<PledgePayment>> GetAllAsync()
        {
            return await _context.PledgePayments
                .Include(pp => pp.Pledge)
                .Include(pp => pp.Payment)
                .ToListAsync();
        }

        public async Task<PledgePayment> GetByIdAsync(int pledgeId, int paymentId)
        {
            return await _context.PledgePayments
                .Include(pp => pp.Pledge)
                .Include(pp => pp.Payment)
                .FirstOrDefaultAsync(pp => pp.PledgeID == pledgeId && pp.PaymentID == paymentId);
        }

        public async Task AddAsync(PledgePayment pledgePayment)
        {
            _context.PledgePayments.Add(pledgePayment);
            await _context.SaveChangesAsync();

            // Log change
            var changelog = new ChangeLog
            {
                ChangeDate = DateTime.UtcNow,
                ChangeDescription = $"Added new pledgePayment with PledgeID {pledgePayment.PledgeID} and PaymentID {pledgePayment.PaymentID}"
            };
            await _changelogRepository.AddAsync(changelog);

        }

        public async Task RemoveAsync(int pledgeId, int paymentId)
        {
            var pledgePayment = await _context.PledgePayments
                .FirstOrDefaultAsync(pp => pp.PledgeID == pledgeId && pp.PaymentID == paymentId);

            if (pledgePayment != null)
            {
                _context.PledgePayments.Remove(pledgePayment);
                await _context.SaveChangesAsync();

                // Log change
                var changelog = new ChangeLog
                {
                    ChangeDate = DateTime.UtcNow,
                    ChangeDescription = $"Remove pledgePayment with PledgeID {pledgePayment.PledgeID} and PaymentID {pledgePayment.PaymentID}"
                };
                await _changelogRepository.AddAsync(changelog);
            }
        }

        public async Task<IEnumerable<PledgePayment>> GetByPledgeIdAsync(int pledgeId)
        {
            return await _context.PledgePayments
                .Where(pp => pp.PledgeID == pledgeId)
                .Include(pp => pp.Payment)
                .Include(pp => pp.Pledge)
                .ToListAsync();
        }

        public async Task<IEnumerable<PledgePayment>> GetByPaymentIdAsync(int paymentId)
        {
            return await _context.PledgePayments
                .Where(pp => pp.PaymentID == paymentId)
                .Include(pp => pp.Pledge)
                .Include(pp => pp.Payment)
                .ToListAsync();
        }
    }
}
