using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Fludop.Core.Commands.Enums
{
    internal enum CommandEnum
    {
        [Description("SELECT")]
        Select,
        [Description("INSERT INTO")]
        Insert,
        [Description("UPDATE")]
        Update,
        [Description("DELETE")]
        Delete
    }
}
