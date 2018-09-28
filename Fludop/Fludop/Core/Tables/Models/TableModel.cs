using System.Collections.Generic;
using Fludop.Core.Commands.Enums;

namespace Fludop.Core.Tables.Models
{
    internal class TableModel
    {
        public string TableName { get; set; }
        public CommandEnum CommandEnum { get; set; }
        public List<string> Columns { get; set; }
        public bool HasColumns => Columns != null || Columns?.Count > 0;
    }
}
