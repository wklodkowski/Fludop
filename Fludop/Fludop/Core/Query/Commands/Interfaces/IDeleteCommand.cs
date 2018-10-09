using System;
using System.Linq.Expressions;

namespace Fludop.Core.Query.Commands.Interfaces
{
    public interface IDeleteCommand<TEntity>
    {
        IWhereCommand<TEntity> Where<TProp>(Expression<Func<TEntity, TProp>> property);
    }
}
