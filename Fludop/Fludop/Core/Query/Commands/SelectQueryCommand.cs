using System;
using System.Collections.Generic;
using Fludop.Core.Query.Commands.Interfaces;
using Fludop.Core.Query.Consts;

namespace Fludop.Core.Query.Commands
{
    internal class SelectQueryCommand<TEntity> : Query<TEntity>, 
        ISelectCommand<TEntity>
    {
        public List<string> Columns { get; set; }
        public List<string> Where { get; set; }

        public override string Build()
        {
            base.Build();

            _stringBuilder.Append(SqlPunctuationConst.Space);

            foreach (var column in Columns)
            {
                _stringBuilder.Append(column);
                _stringBuilder.Append(SqlPunctuationConst.Comma);
                _stringBuilder.Append(SqlPunctuationConst.Space);
            }

            return _stringBuilder.ToString();
        }
    }
}
