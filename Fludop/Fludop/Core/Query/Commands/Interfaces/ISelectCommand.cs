namespace Fludop.Core.Query.Commands.Interfaces
{
    public interface ISelectCommand<TEntity>
    {
        IFromCommand<TEntity> From();
    }
}
