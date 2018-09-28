using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Fludop.Core.Commands.Consts;

namespace Fludop.Core.Commands.Enums
{
    internal enum CommandEnum
    {
        [Description(SqlGrammarConst.Select)]
        Select,
        [Description(SqlGrammarConst.Insert)]
        Insert,
        [Description(SqlGrammarConst.Update)]
        Update,
        [Description(SqlGrammarConst.Delete)]
        Delete
    }
}
