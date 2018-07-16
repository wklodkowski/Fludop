using System;
using System.Collections.Generic;
using System.Text;

namespace Fludop.Core
{
    public class Fludop
    {
        private readonly StringBuilder _stringBuilder;

        public Fludop()
        {
            _stringBuilder = new StringBuilder();
        }

        public Fludop Select(params string[] columns)
        {
            _stringBuilder.Append("SELECT ");

            if (columns.Length > 0)
            {
                foreach (var column in columns)
                {
                    _stringBuilder.Append($"{column}, ");
                }
                _stringBuilder.Remove(_stringBuilder.Length - 2, 1);
            }
            else
            {
                _stringBuilder.Append("* ");
            }

            return this;
        }

        public Fludop From(string table)
        {
            _stringBuilder.Append($"FROM {table}");
            return this;
        }

        public Fludop Update(string entity)
        {
            string updateQuery = $"UPDATE {entity} ";
            _stringBuilder.Append(updateQuery);
            return this;
        }

        public Fludop Set(string column, string value)
        {
            string setQuery = $"SET {column}='{value}' ";
            _stringBuilder.Append(setQuery);
            return this;
        }

        public Fludop Where(string column, string value)
        {
            string whereQuery = $"WHERE {column}='{value}'";
            _stringBuilder.Append(whereQuery);
            return this;
        }

        public Fludop Insert(string table, params string[] values)
        {
            string insertQuery = $"INSERT INTO {table} VALUES (";
            _stringBuilder.Append(insertQuery);

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

        private void EnsureCommandCreated()
        {
            if (_stringBuilder == null)
                throw new InvalidOperationException();
        }
    }
}
