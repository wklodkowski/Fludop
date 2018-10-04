namespace Fludop.Core.Query.Commands.Interfaces
{
    public interface IDeleteCommand<TEntity>
    {
        IFromCommand<TEntity> From();
    }
}
