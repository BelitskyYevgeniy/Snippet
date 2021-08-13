using Snippet.Data.Entities.Base;
using System;
using System.Linq.Expressions;

namespace Snippet.Data.Interfaces.Filters
{
    public interface IFilter<TEntity> where TEntity: BaseEntity
    {
        Expression<Func<TEntity, bool>> Predicate { get; }
        int Degree { get; set; }
    }
}