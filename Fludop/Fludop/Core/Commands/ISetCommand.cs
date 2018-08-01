using System;
using System.Collections.Generic;
using System.Text;

namespace Fludop.Core.Commands
{
    public interface ISetCommand
    {
        ISetCommand Set(string column, string value);
        IWhereCommand Where(string column, string value);
    }
}
