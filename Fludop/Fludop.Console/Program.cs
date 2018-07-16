using System;
using Fludop.Core;

namespace Fludop.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var testFludop = TestFludop();
            System.Console.WriteLine(testFludop);
            System.Console.ReadKey();
        }

        private static string TestFludop()
        {
            var fludop = new Core.Fludop();

            var result = fludop
                .Select("Column1", "Column2", "Column3")
                .From("Table1")
                .Build();

            var selectAll = fludop
                .Select()
                .From("Table1")
                .Build();

            var insert = fludop
                .Insert("Table1", "Value1", "Value2", "Value3")
                .Build();

            var update = fludop
                .Update("Books")
                .Set("Title", "New Title")
                .Where("Number", "100")
                .Build();

            return result;
        }
    }
}
