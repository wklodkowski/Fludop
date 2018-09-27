using System;
using System.Collections.Generic;
using System.Text;
using Fludop.Core.ModelConfigurations.Attributes;
using Fludop.Core.ModelConfigurations.Extensions;

namespace Fludop.Core.ModelConfigurations.Conventions
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
