namespace Fludop.Core.Commands.Interfaces
{
    public interface IDeleteCommand<TEntity>
    {
        IFromCommand<TEntity> From();
    }
}
