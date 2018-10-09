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
            var select = Core.Fludop
                .Select<Book>(x => new { x.Author, x.Title })
                .Where(v => v.Title == "Dobra ksiazka")
                .Build();

            var select0 = Core.Fludop
                .Select<Book>()
                .Where(v => v.Title == "Dobra ksiazka")
                .Build();

            var select1 = Core.Fludop.Select<Book>().Where(x => x.Author == "Autor" && 
                                                                x.Title == "aaa" || 
                                                                x.Id >= 3 && 
                                                                x.Title == "bbb" &&
                                                                x.Id <= 4 || 
                                                                x.Title == "sds").Build();

            var insert = Core.Fludop.Insert<Book>()// TODO: Czy kolumny w "INSERT" powinny byc w metodzie insert czy values
                .Values("1", "Nowy tytul", "Autor Wojtek")
                .Build();

            var insert1 = Core.Fludop.Insert<Book>(x => new { x.Author, x.Title })
                .Values("Nowy tytul", "Autor Wojtek")
                .Build();

            var update = Core.Fludop.Update<Book>()
                .Set(x => x.Author == "Mariusz" && x.Title == "Puchatek")
                .Where(x => x.Id == 2)
                .Build();

            var delete = Core.Fludop.Delete<Book>()
                .Where(x => x.Author == "Wojtek")
                .Build();

            return select1;
        }
    }
}
