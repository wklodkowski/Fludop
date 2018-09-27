namespace Fludop.Core.Commands.Interfaces
{
    public interface IWhereCommand<TEntity>
    {
        string Build();
    }
}
