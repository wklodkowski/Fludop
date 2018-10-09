using System;
using System.Linq.Expressions;

namespace Fludop.Core.Query.Commands.Interfaces
{
    public interface IUpdateCommand<TEntity>
    {
        ISetCommand<TEntity> Set<TProp>(Expression<Func<TEntity, TProp>> property);
    }
}
