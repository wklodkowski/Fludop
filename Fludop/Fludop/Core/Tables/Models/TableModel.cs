using System.Collections.Generic;
using Fludop.Core.Commands.Enums;

namespace Fludop.Core.Tables.Models
{
    internal class TableModel
    {
        public string TableName { get; set; }
        public CommandEnum CommandEnum { get; set; }
        public List<string> QueryCommand { get; set; }
        public bool HasColumns => QueryCommand != null || QueryCommand?.Count > 0;
    }
}
