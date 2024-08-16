using AreyesAssessment.Data.Context;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AreyesAssessment.Data.Filters;
using System.Linq;


namespace AreyesAssessment.Data.Implementations
{
    public class ChangelogRepository : IChangelogRepository
    {
        private readonly AppDbContext _context;

        public ChangelogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChangeLog>> GetAllAsync()
        {
            return await _context.changelog.ToListAsync();
        }

        public async Task<IEnumerable<ChangeLog>> GetFilteredAsync(ChangelogFilter filter)
        {
            var expression = filter.ToExpression();
            return await _context.changelog.Where(expression).ToListAsync();
        }

        public async Task<ChangeLog> GetByIdAsync(int id)
        {
            return await _context.changelog.FindAsync(id);
        }

        public async Task<bool> AddAsync(ChangeLog changelog)
        {
            await _context.changelog.AddAsync(changelog);
            var isAdd= await _context.SaveChangesAsync();
            return isAdd>0;
        }

        public async Task<bool> UpdateAsync(ChangeLog changelog)
        {
            _context.changelog.Update(changelog);
            var isUpdated= await _context.SaveChangesAsync();
            return isUpdated>0;
        }

        public async Task DeleteAsync(int id)
        {
            var changelog = await _context.changelog.FindAsync(id);
            if (changelog != null)
            {
                _context.changelog.Remove(changelog);
                await _context.SaveChangesAsync();
            }
        }
    }
}
