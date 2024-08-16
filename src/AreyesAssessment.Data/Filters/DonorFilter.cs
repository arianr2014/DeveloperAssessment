using System;
using System.Linq.Expressions;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Extensions;

namespace AreyesAssessment.Data.Filters
{
    public class DonorFilter : FilterBase<Donor>
    {
        public string? DonorName { get; set; }
        public string? Address { get; set; }

        public override Expression<Func<Donor, bool>> ToExpression()
        {
            var filter = base.ToExpression();

            if (!string.IsNullOrEmpty(DonorName))
            {
                filter = filter.And(d => d.DonorName.Contains(DonorName));
            }

            if (!string.IsNullOrEmpty(Address))
            {
                filter = filter.And(d => d.Address.Contains(Address));
            }

            return filter;
        }
    }
}
