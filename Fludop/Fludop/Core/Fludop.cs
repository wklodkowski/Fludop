using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Fludop.Core.Common.Extensions;
using Fludop.Core.Query.Commands;
using Fludop.Core.Query.Commands.Enums;
using Fludop.Core.Query.Commands.Interfaces;
using Fludop.Core.Query.Consts;
using Fludop.Core.Tables.Conventions;
using Fludop.Core.Tables.Extensions;
using Fludop.Core.Tables.Models;

namespace Fludop.Core
{
    public static class Fludop
    {
        public static ISelectCommand<TEntity> Select<TEntity>()
            where TEntity : class
        {
            return Select<TEntity>(x => new { });
        }

        public static ISelectCommand<TEntity> Select<TEntity>(Expression<Func<TEntity, object>> columnObject)
            where TEntity : class
        {
            var columns = columnObject.GetNames();
            var query = new SelectQueryCommand<TEntity>
            {
                MainCommand = CommandEnum.Select,
                Columns = columns.Any() ? columns : null
            };

            return query;
        }

        public static IInsertCommand<TEntity> Insert<TEntity>()
            where TEntity : class
        {
            return Insert<TEntity>(x => new {});
        }

        public static IInsertCommand<TEntity> Insert<TEntity>(Expression<Func<TEntity, object>> columnObject)
            where TEntity : class
        {
            var columns = columnObject.GetNames();
            var query = new InsertQueryCommand<TEntity>
            {
                MainCommand = CommandEnum.Insert,
                Columns = columns.Any() ? columns : null
            };          
            
            return query;
        }

        public static IUpdateCommand<TEntity> Update<TEntity>()
            where TEntity : class
        {
            var query = new UpdateQueryCommand<TEntity>
            {
                MainCommand = CommandEnum.Update
            };

            return query;
        }

        public static IDeleteCommand<TEntity> Delete<TEntity>()
            where TEntity : class
        {
            var query = new DeleteQueryCommand<TEntity>
            {
                MainCommand = CommandEnum.Delete
            };

            return query;
        }
    }
}
