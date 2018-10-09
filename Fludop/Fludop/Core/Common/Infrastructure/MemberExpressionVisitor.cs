using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Fludop.Core.Common.Infrastructure
{
    internal class MemberExpressionVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;
        public HashSet<MemberExpression> Members { get; }
        public MemberExpressionVisitor(ParameterExpression parameter)
        {
            _parameter = parameter;
            Members = new HashSet<MemberExpression>();
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression == _parameter)
            {
                Members.Add(node);
            }
            return base.VisitMember(node);
        }
    }
}
