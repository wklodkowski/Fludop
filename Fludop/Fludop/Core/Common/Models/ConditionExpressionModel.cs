using System;
using System.Collections.Generic;
using System.Text;

namespace Fludop.Core.Common.Models
{
    internal class ConditionExpressionModel : ExpressionModel
    {
        public string Expression { get; set; }
        public string Operator { get; set; }
    }
}
