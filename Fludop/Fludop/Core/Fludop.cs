using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Fludop.Core.Commands;
using Fludop.Core.Commands.Consts;
using Fludop.Core.Commands.Enums;
using Fludop.Core.Commands.Interfaces;
using Fludop.Core.Tables.Conventions;
using Fludop.Core.Tables.Extensions;
using Fludop.Core.Tables.Models;

namespace Fludop.Core
{
    public static class Fludop
    {
        public static ISelectCommand<TEntity> Select<TEntity>()
        {
            return Select<TEntity>(x => new{});
        }
        public static ISelectCommand<TEntity> Select<TEntity>(Func<TEntity, object> columnObject)
        {
            var columnsModel = new List<string>();

            var columns = columnObject.GetType().GetProperties();

            if (columns.Length > 0)
            {
                columnsModel.AddRange(columns.Select(column => column.Name));
            }
            else
            {
                columnsModel.Add("*");
            }

            var tableModel = GetTable<TEntity>(CommandEnum.Select, columnsModel);

            return new FludopBuilder<TEntity>(tableModel);
        }

        public static IInsertCommand<TEntity> Insert<TEntity>()
        {
            return Insert<TEntity>(x => new {});
        }

        public static IInsertCommand<TEntity> Insert<TEntity>(Func<TEntity, object> columnObject)
        {
            var columnsModel = new List<string>();

            var columns = columnObject.GetType().GetProperties();

            if (columns.Length > 0)
            {
                columnsModel.Add("(");
                columnsModel.AddRange(columns.Select(column => column.Name));
                columnsModel.Add(")");
            }

            var tableModel = GetTable<TEntity>(CommandEnum.Insert, columnsModel);
            return new FludopBuilder<TEntity>(tableModel);
        }

        public static IUpdateCommand<TEntity> Update<TEntity>()
            where TEntity : class
        {
            var tableModel = GetTable<TEntity>(CommandEnum.Update, null);
            return new FludopBuilder<TEntity>(tableModel);
        }

        public static IDeleteCommand<TEntity> Delete<TEntity>()
        {
            var tableModel = GetTable<TEntity>(CommandEnum.Update, null);
            return new FludopBuilder<TEntity>(tableModel);
        }

        private static TableModel GetTable<TEntity>(CommandEnum commandEnum, List<string> columns)
        {
            var tableConvenction = new TableConvention<TEntity>();
            var tableModel = new TableModel()
            {
                TableName = tableConvenction.GetTableName(),
                CommandEnum = commandEnum,
                Columns = columns
            };

            return tableModel;
        }

        private class FludopBuilder<TEntity> : ISelectCommand<TEntity>,
            IInsertCommand<TEntity>,
            IUpdateCommand<TEntity>,
            IDeleteCommand<TEntity>,
            IFromCommand<TEntity>,
            IWhereCommand<TEntity>,
            IValuesCommand,
            ISetCommand<TEntity>
        {
            private readonly StringBuilder _stringBuilder;
            private readonly TableModel _tableModel;

            public FludopBuilder(TableModel tableModel)
            {
                _tableModel = tableModel;
                _stringBuilder = new StringBuilder();
            }

            public IFromCommand<TEntity> From()
            {
                Initialize();
                _stringBuilder.Append($"{SqlGrammarConst.From} {_tableModel.TableName} ");
                return this;
            }

            public ISetCommand<TEntity> Set<TProp>(Expression<Func<TEntity, TProp>> property, string value)
            {
                Initialize();
                string setQuery = $"{SqlGrammarConst.Set} {property.Name}='{value}' ";
                _stringBuilder.Append(setQuery);
                return this;
            }

            public IWhereCommand<TEntity> Where<TProp>(Expression<Func<TEntity, TProp>> property, string value)
            {
                string whereQuery = $"{SqlGrammarConst.Where} {property.Name}='{value}' ";
                _stringBuilder.Append(whereQuery);
                return this;
            }

            public IValuesCommand Values(params string[] values)
            {
                Initialize();
                string valueQuery = $"{SqlGrammarConst.Values} (";
                _stringBuilder.Append(valueQuery);
                foreach (var value in values)
                {
                    _stringBuilder.Append($"{value}, ");
                }

                _stringBuilder.Remove(_stringBuilder.Length - 2, 2);
                _stringBuilder.Append(")");

                return this;
            }

            public string Build()
            {
                _stringBuilder.Append(";");
                var query = _stringBuilder.ToString();
                _stringBuilder.Clear();
                return query;
            }

            private void Initialize()
            {
                if (_stringBuilder.Length > 0)
                    return;

                _stringBuilder.Append(_tableModel.GetMainCommand());
                _stringBuilder.Append(" ");
                _stringBuilder.Append($"{_tableModel.GetColumns()} ");
            }
        }
    }
}
