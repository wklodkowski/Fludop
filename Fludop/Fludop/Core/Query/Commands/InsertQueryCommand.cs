using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Fludop.Core.Query.Commands.Interfaces;
using Fludop.Core.Query.Consts;

namespace Fludop.Core.Query.Commands
{
    internal class InsertQueryCommand<TEntity> : Query<TEntity>,
        IInsertCommand<TEntity>,
        IValuesCommand
    {
        public List<string> Columns { get; set; }
        public List<string> ValuesList { get; set; }

        public override string Build()
        {
            base.Build();
            BuildTableName();
            BuildColumns();
            BuildValues();
            BuildWhere();
            BuildSemicolon();

            return _stringBuilder.ToString();
        }

        public IValuesCommand Values(params string[] values)
        {
            if (ValuesList == null)
                ValuesList = new List<string>();

            foreach (var value in values)
            {
                ValuesList.Add(value);
            }

            return this;
        }

        private void BuildTableName()
        {
            _stringBuilder.Append(SqlPunctuationConst.Space);
            _stringBuilder.Append(GetTableName());
        }

        private void BuildColumns()
        {
            if(Columns == null || !Columns.Any())
                return;

            _stringBuilder.Append(BuildInsertQuery(Columns));
        }

        private void BuildValues()
        {
            if (ValuesList == null || !ValuesList.Any())
                return;

            _stringBuilder.Append(SqlPunctuationConst.Space);
            _stringBuilder.Append(SqlGrammarConst.Values);
            _stringBuilder.Append(BuildInsertQuery(ValuesList));
        }

        private static string BuildInsertQuery(IEnumerable<string> insertQueryList)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(SqlPunctuationConst.Space);
            stringBuilder.Append(SqlPunctuationConst.OpenBracket);

            foreach (var insertElement in insertQueryList)
            {
                stringBuilder.Append(SqlPunctuationConst.Space);
                stringBuilder.Append(insertElement);
                stringBuilder.Append(SqlPunctuationConst.Comma);               
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append(SqlPunctuationConst.CloseBracket);

            return stringBuilder.ToString();
        }
    }
}
