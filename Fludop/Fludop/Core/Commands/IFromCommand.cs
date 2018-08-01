using System;
using System.Collections.Generic;
using System.Text;

namespace Fludop.Core.Commands
{
    public interface IFromCommand
    {
        IWhereCommand Where(string column, string value);
        string Build();
    }
}
