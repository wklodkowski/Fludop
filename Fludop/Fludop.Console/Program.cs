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

            var result = Core.Fludop
                .Select("Column1", "Column2", "Column3")
                .From("Table1")
                .Build();

            var insert = Core.Fludop.Update("Table1")
                .Set("Column1", "Test")
                .Where("Column1", "Wojtek")
                .Build();

            return insert;
        }
    }
}
