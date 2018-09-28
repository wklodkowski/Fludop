using System;
using System.Collections.Generic;
using System.Text;
using Fludop.Core.Tables.Attributes;

namespace Fludop.Console.Models
{
    [TableName("tbl_Books")]
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
