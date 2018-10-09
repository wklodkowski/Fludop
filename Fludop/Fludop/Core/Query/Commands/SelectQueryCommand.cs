using System;
using System.Collections.Generic;
using System.Linq;
using Fludop.Core.Query.Commands.Interfaces;
using Fludop.Core.Query.Consts;

namespace Fludop.Core.Query.Commands
{
    internal class SelectQueryCommand<TEntity> : Query<TEntity>, 
        ISelectCommand<TEntity>
    {
        public List<string> Columns { get; set; }

        public override string Build()
        {
            base.Build();
            BuildColumns();
            BuildFrom();
            BuildWhere();
            BuildSemicolon();

            return _stringBuilder.ToString();
        }

        private void BuildColumns()
        {
            _stringBuilder.Append(SqlPunctuationConst.Space);

            if (Columns == null || !Columns.Any())
            {
                _stringBuilder.Append(SqlPunctuationConst.Asterisk);
                return;
            }
                
            foreach (var column in Columns)
            {
                _stringBuilder.Append(column);
                _stringBuilder.Append(SqlPunctuationConst.Comma);
                _stringBuilder.Append(SqlPunctuationConst.Space);
            }

            _stringBuilder.Remove(_stringBuilder.Length - 2, 1);
        }

        private void BuildFrom()
        {
            _stringBuilder.Append(SqlPunctuationConst.Space);
            _stringBuilder.Append(SqlGrammarConst.From);
            _stringBuilder.Append(SqlPunctuationConst.Space);
            _stringBuilder.Append(GetTableName());
        }
    }
}
