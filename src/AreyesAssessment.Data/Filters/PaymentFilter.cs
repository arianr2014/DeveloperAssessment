using System;
using System.Linq.Expressions;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Data.Extensions;

namespace AreyesAssessment.Data.Filters
{
    public class PaymentFilter : FilterBase<Payment>
    {
        public DateTime? MinPaymentDate { get; set; }
        public DateTime? MaxPaymentDate { get; set; }
        public decimal? MinPaymentAmount { get; set; }
        public decimal? MaxPaymentAmount { get; set; }

        public override Expression<Func<Payment, bool>> ToExpression()
        {
            var filter = base.ToExpression();

            if (MinPaymentDate.HasValue)
            {
                filter = filter.And(p => p.PaymentDate >= MinPaymentDate.Value);
            }

            if (MaxPaymentDate.HasValue)
            {
                filter = filter.And(p => p.PaymentDate <= MaxPaymentDate.Value);
            }

            if (MinPaymentAmount.HasValue)
            {
                filter = filter.And(p => p.PaymentAmount >= MinPaymentAmount.Value);
            }

            if (MaxPaymentAmount.HasValue)
            {
                filter = filter.And(p => p.PaymentAmount <= MaxPaymentAmount.Value);
            }

            return filter;
        }
    }
}
