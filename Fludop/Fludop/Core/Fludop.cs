using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Fludop.Core.Commands;
using Fludop.Core.Commands.Enums;
using Fludop.Core.Commands.Interfaces;
using Fludop.Core.ModelConfigurations.Conventions;
using Fludop.Core.Models;

namespace Fludop.Core
{
    public static class Fludop
    {
        public static ISelectCommand<TEntity> Select<TEntity>(params Expression<Func<TEntity, string>>[] columns)
        {
            var tableConvenction = new TableConvention<TEntity>();
            var tableModel = new TableModel()
            {
                TableName = tableConvenction.GetTableName(),
                CommandEnum = CommandEnum.Select,
                Columns = new List<string>()
            };

            if (columns.Length > 0)
            {
                foreach (var column in columns)
                {
                    tableModel.Columns.Add(column.Name);
                }
            }
            else
            {
                tableModel.Columns.Add("*");
            }

            return new FludopBuilder<TEntity>(tableModel);
        }

        public static IInsertCommand<TEntity> Insert<TEntity>(string table)
        {
            string insertQuery = $"INSERT INTO {table} ";
            return new FludopBuilder<TEntity>(insertQuery);
        }

        public static IUpdateCommand<TEntity> Update<TEntity>()
            where TEntity : class
        {
            string updateQuery = $"UPDATE {typeof(TEntity).Name} ";
            return new FludopBuilder<TEntity>(updateQuery);
        }

        public static IDeleteCommand<TEntity> Delete<TEntity>()
        {
            return new FludopBuilder<TEntity>(string.Empty);
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
                _stringBuilder.Append(query);
            }

            public IFromCommand<TEntity> From()
            {
                _stringBuilder.Append($"FROM {typeof(TEntity).Name} ");
                return this;
            }

            public ISetCommand<TEntity> Set<TProp>(Expression<Func<TEntity, TProp>> property, string value)
            {
                string setQuery = $"SET {property.Name}='{value}' ";
                _stringBuilder.Append(setQuery);
                return this;
            }

            public IWhereCommand<TEntity> Where<TProp>(Expression<Func<TEntity, TProp>> property, string value)
            {
                string whereQuery = $"WHERE {property.Name}='{value}' ";
                _stringBuilder.Append(whereQuery);
                return this;
            }

            public IValuesCommand Values(params string[] values)
            {
                string valueQuery = $"VALUES (";
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
        }
    }
}
