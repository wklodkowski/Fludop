using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Fludop.Core.Commands
{
    public interface IFromCommand<TEntity>
    {
        IWhereCommand<TEntity> Where<TProp>(Expression<Func<TEntity, TProp>> property, string value);
        string Build();
    }
}
