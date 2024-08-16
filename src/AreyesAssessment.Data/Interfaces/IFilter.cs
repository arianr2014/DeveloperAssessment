using System;
using System.Linq.Expressions;

namespace AreyesAssessment.Data.Interfaces
{
    public interface IFilter<T>
    {
        Expression<Func<T, bool>> ToExpression();
    }
}
