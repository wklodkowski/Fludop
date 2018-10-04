using System.ComponentModel;
using Fludop.Core.Query.Consts;

namespace Fludop.Core.Query.Commands.Enums
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
