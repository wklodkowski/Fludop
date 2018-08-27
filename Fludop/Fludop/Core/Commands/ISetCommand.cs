﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Fludop.Core.Commands
{
    public interface ISetCommand<TEntity>
    {
        ISetCommand<TEntity> Set<TProp>(Expression<Func<TEntity, TProp>> property, string value);
        IWhereCommand<TEntity> Where<TProp>(Expression<Func<TEntity, TProp>> property, string value);
    }
}
