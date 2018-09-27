namespace Fludop.Core.Commands.Interfaces
{
    public interface ISelectCommand<TEntity>
    {
        IFromCommand<TEntity> From();
    }
}
