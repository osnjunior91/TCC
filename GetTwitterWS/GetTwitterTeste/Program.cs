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

            try
            {
                using (var getTwitter = new GetTwitter())
                {
                    getTwitter.GetAllTwitter("bolsonaro");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n********** ERROR **********\n");
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n****************************\n\n");
            }
            finally
            {
                Console.WriteLine("********** Fim de execução **********");
                Console.ReadKey();
            }
        }
    }
}
