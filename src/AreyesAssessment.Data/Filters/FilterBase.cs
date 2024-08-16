using System;
using System.Linq.Expressions;
using AreyesAssessment.Data.Interfaces;

namespace AreyesAssessment.Data.Filters
{
    public abstract class FilterBase<T> : IFilter<T>
    {
        public virtual Expression<Func<T, bool>> ToExpression()
        {
            return entity => true; // Por defecto, no filtra nada
        }
    }
}
