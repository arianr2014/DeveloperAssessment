using AreyesAssessment.Data.Context;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AreyesAssessment.Data.Filters;
using System.Linq;

namespace AreyesAssessment.Data.Implementations
{
    public class DonorRepository : IDonorRepository
    {
        private readonly AppDbContext _context;
        private readonly IChangelogRepository _changelogRepository;

        public DonorRepository(AppDbContext context, IChangelogRepository changelogRepository)
        {
            _context = context;
            _changelogRepository = changelogRepository;
        }

        public async Task<IEnumerable<Donor>> GetAllAsync()
        {
            return await _context.Donors.ToListAsync();
        }
        public async Task<IEnumerable<Donor>> GetFilteredAsync(DonorFilter filter)
        {
            var expression = filter.ToExpression();
            return await _context.Donors.Where(expression).ToListAsync();
        }

        public async Task<Donor> GetByIdAsync(int id)
        {
            return await _context.Donors.FindAsync(id);
        }

        public async Task<Donor> AddAsync(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();

            // Log change
            var changelog = new ChangeLog
            {
                ChangeDate = DateTime.UtcNow,
                ChangeDescription = $"Added new donor with ID {donor.DonorID}"
            };
            await _changelogRepository.AddAsync(changelog);

            return donor;
        }

        public async Task<Donor> UpdateAsync(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();

            // Log change
            var changelog = new ChangeLog
            {
                ChangeDate = DateTime.UtcNow,
                ChangeDescription = $"Updated donor with ID {donor.DonorID}"
            };
            await _changelogRepository.AddAsync(changelog);

            return donor;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
                await _context.SaveChangesAsync();

                // Log change
                var changelog = new ChangeLog
                {
                    ChangeDate = DateTime.UtcNow,
                    ChangeDescription = $"Deleted donor with ID {id}"
                };
                await _changelogRepository.AddAsync(changelog);

                return true;
            }
            return false;
        }
    }
}
