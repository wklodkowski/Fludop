using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Fludop.Core.Tables.Extensions
{
    internal static class TablePropertyExtension
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
    }
}
