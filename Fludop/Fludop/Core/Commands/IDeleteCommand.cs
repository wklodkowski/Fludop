using System;
using System.Collections.Generic;
using System.Text;

namespace Fludop.Core.Commands
{
    public interface IDeleteCommand<TEntity>
    {
        IFromCommand<TEntity> From();
    }
}
