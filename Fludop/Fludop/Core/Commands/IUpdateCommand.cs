using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Fludop.Core.Commands
{
    public interface IUpdateCommand<TEntity>
    {
        ISetCommand<TEntity> Set<TProp>(Expression<Func<TEntity, TProp>> property, string value);
    }
}
