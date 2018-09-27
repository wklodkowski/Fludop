using System;
using System.Linq.Expressions;

namespace Fludop.Core.Commands.Interfaces
{
    public interface IUpdateCommand<TEntity>
    {
        ISetCommand<TEntity> Set<TProp>(Expression<Func<TEntity, TProp>> property, string value);
    }
}
