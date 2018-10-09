using System;
using System.Linq.Expressions;

namespace Fludop.Core.Query.Commands.Interfaces
{
    public interface IInsertCommand<TEntity>
    {
        IValuesCommand Values(params string[] values);
    }
}
