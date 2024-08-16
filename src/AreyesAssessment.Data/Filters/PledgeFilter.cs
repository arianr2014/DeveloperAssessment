using System;
using System.Linq.Expressions;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Extensions;

namespace AreyesAssessment.Data.Filters
{
    public class PledgeFilter : FilterBase<Pledge>
    {
        public DateTime? MinPledgeDate { get; set; }
        public DateTime? MaxPledgeDate { get; set; }
        public decimal? MinPledgeAmount { get; set; }
        public decimal? MaxPledgeAmount { get; set; }

        public override Expression<Func<Pledge, bool>> ToExpression()
        {
            var filter = base.ToExpression();

            if (MinPledgeDate.HasValue)
            {
                filter = filter.And(p => p.PledgeDate >= MinPledgeDate.Value);
            }

            if (MaxPledgeDate.HasValue)
            {
                filter = filter.And(p => p.PledgeDate <= MaxPledgeDate.Value);
            }

            if (MinPledgeAmount.HasValue)
            {
                filter = filter.And(p => p.PledgeAmount >= MinPledgeAmount.Value);
            }

            if (MaxPledgeAmount.HasValue)
            {
                filter = filter.And(p => p.PledgeAmount <= MaxPledgeAmount.Value);
            }

            return filter;
        }
    }
}
