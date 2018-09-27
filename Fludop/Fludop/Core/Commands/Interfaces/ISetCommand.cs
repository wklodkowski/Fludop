using System;
using System.Linq.Expressions;

namespace Fludop.Core.Commands.Interfaces
{
    public interface ISetCommand<TEntity>
    {
        ISetCommand<TEntity> Set<TProp>(Expression<Func<TEntity, TProp>> property, string value);
        IWhereCommand<TEntity> Where<TProp>(Expression<Func<TEntity, TProp>> property, string value);
    }
}
