using Fludop.Core.Query.Commands.Interfaces;

namespace Fludop.Core.Query.Commands
{
    internal class InsertQueryCommand<TEntity> : Query<TEntity>,
        IInsertCommand<TEntity>,
        IValuesCommand
    {
        public IValuesCommand Values(params string[] values)
        {
            throw new System.NotImplementedException();
        }
    }
}
