using System;
using System.Collections.Generic;
using System.Text;

namespace Fludop.Core.Commands
{
    public interface IInsertCommand<TEntity>
    {
        IValuesCommand Values(params string[] values);
    }
}
