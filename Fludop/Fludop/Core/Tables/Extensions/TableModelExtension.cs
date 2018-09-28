using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Fludop.Core.Tables.Models;

namespace Fludop.Core.Tables.Extensions
{
    internal static class TableModelExtension
    {
        public static string GetColumns(this TableModel tableModel)
        {
            if (!tableModel.HasColumns)
                return string.Empty;

            var stringBuilder = new StringBuilder();
            foreach (var column in tableModel.Columns)
            {
                stringBuilder.Append(column);
                stringBuilder.Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 1);

            return stringBuilder.ToString();
        }

        public static string GetMainCommand(this TableModel tableModel)
        {
            string description = null;
            var type = tableModel.CommandEnum.GetType();
            var values = Enum.GetValues(type);

            foreach (int val in values)
            {
                if (val != ((IConvertible) tableModel.CommandEnum).ToInt32(CultureInfo.InvariantCulture))
                    continue;

                var memInfo = type.GetMember(type.GetEnumName(val));
                var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (descriptionAttributes.Length > 0)
                {
                    description = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                }

                break;
            }
            return description;
        }
    }
}
