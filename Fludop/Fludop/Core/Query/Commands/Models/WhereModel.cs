using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Fludop.Core.Columns.Models;

namespace Fludop.Core.Query.Commands.Models
{
    internal class WhereModel
    {
        public string Expression { get; set; }
        public ColumnModel Column { get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }
    }
}
