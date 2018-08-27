using System;
using System.Collections.Generic;
using System.Text;

namespace Fludop.Core.Commands
{
    public interface ISelectCommand<TEntity>
    {
        IFromCommand<TEntity> From();
    }
}
