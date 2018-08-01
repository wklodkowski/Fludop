using System;
using System.Collections.Generic;
using System.Text;
using Fludop.Core.Commands;

namespace Fludop.Core
{
    public class Fludop : ISelectCommand, 
        IInsertCommand,
        IUpdateCommand,
        IDeleteCommand,
        IFromCommand, 
        IWhereCommand,
        IValuesCommand,
        ISetCommand
    {
        private readonly StringBuilder _stringBuilder;

        private Fludop(string query)
        {
            _stringBuilder = new StringBuilder();
            _stringBuilder.Append(query);
        }

        public static ISelectCommand Select(params string[] columns)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT ");

            if (columns.Length > 0)
            {
                foreach (var column in columns)
                {
                    stringBuilder.Append($"{column}, ");
                }
                stringBuilder.Remove(stringBuilder.Length - 2, 1);
            }
            else
            {
                stringBuilder.Append("* ");
            }

            return new Fludop(stringBuilder.ToString());
        }

        public IFromCommand From(string table)
        {
            _stringBuilder.Append($"FROM {table}");
            return this;
        }

        public static IUpdateCommand Update(string entity)
        {
            string updateQuery = $"UPDATE {entity} ";
            return new Fludop(updateQuery);
        }

        public ISetCommand Set(string column, string value)
        {
            string setQuery = $"SET {column}='{value}' ";
            _stringBuilder.Append(setQuery);
            return this;
        }

        public IWhereCommand Where(string column, string value)
        {
            string whereQuery = $"WHERE {column}='{value}'";
            _stringBuilder.Append(whereQuery);
            return this;
        }

        public static IInsertCommand Insert(string table)
        {
            string insertQuery = $"INSERT INTO {table} ";
            return new Fludop(insertQuery);
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

        public static IDeleteCommand Delete()
        {
            return new Fludop(string.Empty);
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
