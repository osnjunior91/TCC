using GetTwitterLib;
using GetTwitterLib.Infrastructure.Twitter;
using System;
using System.Configuration;

namespace GetTwitterTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********** Teste de Serviço**********");

            using (var getTwitter = new ServiceTwitter())
            {
                var teste = getTwitter.GetTwitter();
            }

            Console.ReadKey();
        }
    }
}
