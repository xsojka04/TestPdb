using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestPdb.Helpers;
using TestPdb.TestModels;

namespace TestPdb.TestCases
{
    internal class BeerInfo : CaseBase
    {
        public BeerInfo(string baseUrl, HttpClient client) : base(baseUrl, client)
        {
        }

        public override void Test()
        {
            var beerInfo = _apiHelper.GetBeerInfo();
            if (beerInfo is null)
                throw new Exception("BeerInfo endpoint nefunguje");
            if (beerInfo.Count == 0)
                throw new Exception("BeerInfo endpoint vrací prázdný seznam");
        }
    }
}
