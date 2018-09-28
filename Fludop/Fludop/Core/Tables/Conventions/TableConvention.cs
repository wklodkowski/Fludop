using Fludop.Core.Tables.Attributes;
using Fludop.Core.Tables.Extensions;

namespace Fludop.Core.Tables.Conventions
{
    internal class TableConvention<TEntity>
    {
        public string GetTableName()
        {
            var tableName = typeof(TEntity).GetAttributeValue((TableNameAttribute atr) => atr.TableName);
            return string.IsNullOrEmpty(tableName) ? GetDefaultTableName() : tableName;
        }

        private static string GetDefaultTableName()
        {
            return $"{typeof(TEntity).Name}s";
        }
    }
}
