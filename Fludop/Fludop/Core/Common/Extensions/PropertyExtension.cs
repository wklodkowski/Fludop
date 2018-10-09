using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Fludop.Core.Common.Infrastructure;

namespace Fludop.Core.Common.Extensions
{
    internal static class PropertyExtension
    {
        //public static string GetName<TEntity, TProp>(this Expression<Func<TEntity, TProp>> exp)
        //{
        //    if (!(exp.Body is MemberExpression body))
        //    {
        //        var ubody = (UnaryExpression)exp.Body;
        //        body = ubody.Operand as MemberExpression;
        //    }

        //    if (body == null)
        //    {
        //        throw new InvalidOperationException();
        //    }

        //    return body.Member.Name;
        //}

        public static List<string> GetNames<TEntity>(this Expression<Func<TEntity, object>> exp)
        {
            var members = exp.GetPropertyAccesses();
            return members.Select(member => member.Member.Name).ToList();
        }

        private static IEnumerable<MemberExpression> GetPropertyAccesses<T, TResult>(this Expression<Func<T, TResult>> expression)
        {
            var visitor = new MemberExpressionVisitor(expression.Parameters.First());
            visitor.Visit(expression);
            return visitor.Members;
        }

        public static List<MemberExpression> GetConditionList<TEntity, TProp>(this Expression<Func<TEntity, TProp>> property)
        {
            var result = new ConditionExpressionVisitor(property.Parameters.First());
            result.Visit(property);
            // TODO: Implement getting conditionlist
            return new List<MemberExpression>();
        }
    }
}
