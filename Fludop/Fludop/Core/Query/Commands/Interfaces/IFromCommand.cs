using System;
using System.Linq.Expressions;

namespace Fludop.Core.Query.Commands.Interfaces
{
    public interface IFromCommand<TEntity>
    {
        IWhereCommand<TEntity> Where<TProp>(Expression<Func<TEntity, TProp>> property, string value);
        string Build();
    }
}
