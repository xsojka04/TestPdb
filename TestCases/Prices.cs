using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestPdb.Helpers;
using TestPdb.TestModels;

namespace TestPdb.TestCases
{
    internal class Prices : CaseBase
    {
        public Prices(string baseUrl, HttpClient client) : base(baseUrl, client)
        {
        }

        public override void Test()
        {
            var prices = _apiHelper.GetPrices();
            if (prices is null)
                throw new Exception("Prices endpoint nefunguje");
            if (prices.Count == 0)
                throw new Exception("Prices endpoint vrací prázdný seznam");
        }
    }
}
