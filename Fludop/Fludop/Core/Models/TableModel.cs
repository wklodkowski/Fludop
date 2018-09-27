using System;
using System.Collections.Generic;
using System.Text;
using Fludop.Core.Commands.Enums;

namespace Fludop.Core.Models
{
    internal class TableModel
    {
        public string TableName { get; set; }
        public CommandEnum CommandEnum { get; set; }
        public List<string> Columns { get; set; }
        public bool HasColumns => Columns.Count > 0;
    }
}
