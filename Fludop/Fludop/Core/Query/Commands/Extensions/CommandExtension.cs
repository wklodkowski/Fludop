using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using Fludop.Core.Query.Commands.Enums;

namespace Fludop.Core.Query.Commands.Extensions
{
    internal static class CommandExtension
    {
        public static string GetMainCommand(this CommandEnum commandEnum)
        {
            string description = null;
            var newType = commandEnum.GetType();
            var values = Enum.GetValues(newType);

            foreach (int val in values)
            {
                if (val != ((IConvertible)commandEnum).ToInt32(CultureInfo.InvariantCulture))
                    continue;

                var memInfo = newType.GetMember(newType.GetEnumName(val));
                var descriptionAttributes = memInfo.First().GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (descriptionAttributes.Length > 0)
                {
                    description = ((DescriptionAttribute)descriptionAttributes.First()).Description;
                }

                break;
            }
            return description;
        }
    }
}
