using System;
using System.Collections.Generic;
using System.Text;

namespace Fludop.Core.Commands
{
    public interface IUpdateCommand
    {
        ISetCommand Set(string column, string value);
    }
}
