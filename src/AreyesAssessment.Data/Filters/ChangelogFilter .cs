#nullable enable

using System;
using System.Linq.Expressions;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Extensions;

namespace AreyesAssessment.Data.Filters
{
    public class ChangelogFilter : FilterBase<ChangeLog>
    {
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public string? Description { get; set; }

        public override Expression<Func<ChangeLog, bool>> ToExpression()
        {
            var filter = base.ToExpression();
            if (MinDate.HasValue)
            {
                filter = filter.And(c => c.ChangeDate >= MinDate.Value);
            }
            if (MaxDate.HasValue)
            {
                filter = filter.And(c => c.ChangeDate <= MaxDate.Value);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                filter = filter.And(c => c.ChangeDescription.Contains(Description));
            }
            return filter;
        }
    }
}
