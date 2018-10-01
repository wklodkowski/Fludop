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

            var select = Core.Fludop
                .Select<Book>()
                .From()
                .Where(v => v.Title, "Dobra ksiazka")
                .Build();

            var insert = Core.Fludop.Insert<Book>()// TODO: Czy kolumny w "INSERT" powinny byc w metodzie insert czy values
                .Values("Nowy tytul", "Autor Wojtek")
                .Build();

            var insert1 = Core.Fludop.Insert<Book>(x => new { x.Author, x.Title })
                .Values("Nowy tytul", "Autor Wojtek")
                .Build();

            var update = Core.Fludop.Update<Book>()
                .Set(x => x.Author, "Mariusz") //TODO: Pytanie czy zrobić tak by sety wszystkich kolumn były w jednym SET
                .Where(x => x.Title, "Nowy tytul") //TODO: To samo co wyzej
                .Build();

            var delete = Core.Fludop.Delete<Book>()
                .From()
                .Where(x => x.Author, "Wojtek")
                .Build();

            var updateResult = Core.Fludop.Update<Book>().Set(x => x.Title, "Nowy Tytul")
                .Set(x => x.Author, "Wojtek")
                .Where(w => w.Id, "1")
                .Build();

            return selectResult;
        }
    }
}
