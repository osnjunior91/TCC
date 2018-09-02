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

            using (var getTwitter = new GetTwitter())
            {
                getTwitter.GetAllTwitter("bolsonaro");
            }
            Console.WriteLine("********** Fim de execução **********");
            Console.ReadKey();
        }
    }
}
