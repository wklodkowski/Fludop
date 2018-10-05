using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Fludop.Core.Common.Extensions
{
    internal static class PropertyExtension
    {
        public static string GetName<TEntity, TProp>(this Expression<Func<TEntity, TProp>> exp)
        {
            if (!(exp.Body is MemberExpression body))
            {
                var ubody = (UnaryExpression)exp.Body;
                body = ubody.Operand as MemberExpression;
            }

            if (body == null)
            {
                throw new InvalidOperationException();
            }

            return body.Member.Name;
        }

        public static List<string> GetNames<T>(this Expression<Func<T, object>> expression)
        {
            if (expression.Body is MemberExpression)
            {
                var x = ((MemberExpression)expression.Body).Member.Name;
            }
            else
            {
                var op = ((UnaryExpression)expression.Body).Operand;
                var p = ((MemberExpression)op).Member.Name;
            }


            return new List<string>();
        }
    }
}
