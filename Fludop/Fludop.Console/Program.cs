using System;
using Fludop.Core;
using Fludop.Console.Models;

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
            var selectResult = Core.Fludop
                .Select<Book>()
                .From()
                .Where(v => v.Title, "Dobra ksiazka")
                .Build();

            return selectResult;
        }
    }
}
