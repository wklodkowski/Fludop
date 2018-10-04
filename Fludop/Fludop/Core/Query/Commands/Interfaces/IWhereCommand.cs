namespace Fludop.Core.Query.Commands.Interfaces
{
    public interface IWhereCommand<TEntity>
    {
        string Build();
    }
}
