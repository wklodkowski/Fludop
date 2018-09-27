namespace Fludop.Core.Commands.Interfaces
{
    public interface IInsertCommand<TEntity>
    {
        IValuesCommand Values(params string[] values);
    }
}
