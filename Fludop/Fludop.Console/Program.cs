using System;
using System.Security.Cryptography.X509Certificates;
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
                .Select<Book>(x => new {x.Author, x.Title})
                .From()
                .Where(v => v.Title, "Dobra ksiazka")
                .Build();

            var selectResult1 = Core.Fludop
                .Select<Book>()
                .From()
                .Where(v => v.Title, "Dobra ksiazka")
                .Build();

            var updateResult = Core.Fludop.Update<Book>().Set(x => x.Title, "Nowy Tytul")
                .Set(x => x.Author, "Wojtek")
                .Where(w => w.Id, "1")
                .Build();

            return selectResult;
        }
    }
}
