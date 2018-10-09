using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Fludop.Core.Common.Models;

namespace Fludop.Core.Common.Infrastructure
{
    internal class ConditionExpressionVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;
        public HashSet<MemberExpression> Members { get; }
        public List<ConditionExpressionModel> ConditionExpressionList { get; set; }

        public ConditionExpressionVisitor(ParameterExpression parameter)
        {
            _parameter = parameter;
            Members = new HashSet<MemberExpression>();
            ConditionExpressionList = new List<ConditionExpressionModel>();
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression == _parameter)
            {
                ConditionExpressionList.Add(new ConditionExpressionModel
                {
                    Column = node.Member.Name,
                    Expression = node.Expression.ToString()
                });
            }
            return base.VisitMember(node);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            //TODO: Get && and || operator
            var memberLeft = node.Left as MemberExpression;
            if (memberLeft?.Expression is ParameterExpression)
            {
                var f = Expression.Lambda(node.Right).Compile();
                var value = f.DynamicInvoke();

                ConditionExpressionList.Add(new ConditionExpressionModel
                {
                    Expression = node.NodeType.ToString(),
                    Column = memberLeft.Member.Name,
                    Value = value.ToString()
                });
            }

            return base.VisitBinary(node);
        }
    }
}
