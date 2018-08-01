using System;
using System.Collections.Generic;
using System.Text;

namespace Fludop.Core.Commands
{
    public interface IDeleteCommand
    {
        IFromCommand From(string table);
    }
}
