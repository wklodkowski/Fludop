using System;
using System.Collections.Generic;
using System.Text;

namespace Fludop.Core.ModelConfigurations.Attributes
{
    /// <summary>
    /// Specifies the database table that a class is mapped to.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableNameAttribute : Attribute
    {
        public TableNameAttribute(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException();
            }
            TableName = tableName;
        }

        public string TableName { get; }
    }
}
