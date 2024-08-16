using AreyesAssessment.Data.Context;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Filters;
using AreyesAssessment.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreyesAssessment.Data.Implementations
{
    public class PledgeRepository : IPledgeRepository
    {
        private readonly AppDbContext _context;
        private readonly IChangelogRepository _changelogRepository;

        public PledgeRepository(AppDbContext context, IChangelogRepository changelogRepository)
        {
            _context = context;
            _changelogRepository = changelogRepository;
        }

        public async Task<IEnumerable<Pledge>> GetAllAsync()
        {
            return await _context.Pledges.ToListAsync();
        }
        public async Task<IEnumerable<Pledge>> GetFilteredAsync(PledgeFilter filter)
        {
            var expression = filter.ToExpression();
            return await _context.Pledges.Where(expression).ToListAsync();
        }

        public async Task<Pledge?> GetByIdAsync(int id)
        {
            return await _context.Pledges.FindAsync(id);
        }


        public async Task<Pledge> AddAsync(Pledge pledge)
        {
            await _context.Pledges.AddAsync(pledge);
            await _context.SaveChangesAsync();
            // Log change
            var changelog = new ChangeLog
            {
                ChangeDate = DateTime.UtcNow,
                ChangeDescription = $"Added new Pledge with ID {pledge.PledgeID}"
            };
            await _changelogRepository.AddAsync(changelog);
            return pledge;
        }

        public async Task<bool> UpdateAsync(Pledge pledge)
        {
            _context.Pledges.Update(pledge);
            var isUpdated= await _context.SaveChangesAsync();

            // Log change
            var changelog = new ChangeLog
            {
                ChangeDate = DateTime.UtcNow,
                ChangeDescription = $"Added new Pledge with ID {pledge.PledgeID}"
            };
            await _changelogRepository.AddAsync(changelog);


            return isUpdated>0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pledge = await _context.Pledges.FindAsync(id);
            if (pledge != null)
            {
                _context.Pledges.Remove(pledge);
                await _context.SaveChangesAsync();

                // Log change
                var changelog = new ChangeLog
                {
                    ChangeDate = DateTime.UtcNow,
                    ChangeDescription = $"Added new Pledge with ID {id}"
                };
                await _changelogRepository.AddAsync(changelog);

                return true;
            }
            return false;
        }
    }
}
