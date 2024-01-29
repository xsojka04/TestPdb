using System;
using System.Net.Http;
using System.Xml.Linq;
using TestPdb.Helpers;
using TestPdb.TestCases;

namespace TestPdb
{
    public class Test : IDisposable
    {
        private HttpClient _client;
        private string _baseUrl = "https://pdb-pivni-burza.herokuapp.com";

        public Test()
        {
            _client =  new HttpClient();
        }

        //Spuštění jednoho testu
        private void RunOne(CaseBase caseBase, string name)
        {
            try
            {
                ConsoleHelper.WriteLineInfo($"Test {name}");
                caseBase.Test();
                ConsoleHelper.WriteLineSuccess($"Test {name} proběhl úspěšně");
            } catch (Exception e)
            {
                ConsoleHelper.WriteLineError(e.Message);
            }
        }

        public bool Run()
        {
            try
            {
                RunOne(new BeerInfo(_baseUrl, _client), "BeerInfo");
                RunOne(new SetPrice(_baseUrl, _client), "SetPrice");
                RunOne(new SetAvailable(_baseUrl, _client), "SetAvailable");
                RunOne(new Prices(_baseUrl, _client), "Prices");
                RunOne(new BuyBeerAndPay(_baseUrl, _client), "nákupu");
                RunOne(new BuyBeersAndPay(_baseUrl, _client), "několika nákupů na 1 účet");
                RunOne(new BuyBeersAndPayMultipleSeats(_baseUrl, _client), "několika nákupů na několik účtů");
            } catch
            {
                return false;
            }

            ConsoleHelper.WriteLineSuccess($"\n\nTestování proběhlo úspěšně\n\n");
            return true;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
