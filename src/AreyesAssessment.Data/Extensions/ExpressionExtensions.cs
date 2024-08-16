using System;
using System.Linq.Expressions;

namespace AreyesAssessment.Data.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> And<T>(
            this Expression<Func<T, bool>> first,
            Expression<Func<T, bool>> second)
        {
            // Combine the two expressions
            var invokedExpr = Expression.Invoke(second, first.Parameters);
            var combinedExpr = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(first.Body, invokedExpr),
                first.Parameters);

            return combinedExpr;
        }
    }
}
