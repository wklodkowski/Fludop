using Fludop.Core.Query.Commands.Interfaces;
using Fludop.Core.Query.Consts;

namespace Fludop.Core.Query.Commands
{
    internal class DeleteQueryCommand<TEntity> : Query<TEntity>,
        IDeleteCommand<TEntity>
    {
        public override string Build()
        {
            base.Build();
            BuildFrom();
            BuildWhere();
            return _stringBuilder.ToString();
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
