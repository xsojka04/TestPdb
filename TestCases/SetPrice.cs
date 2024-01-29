using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestPdb.Helpers;
using TestPdb.TestModels;

namespace TestPdb.TestCases
{
    internal class SetPrice : CaseBase
    {
        public SetPrice(string baseUrl, HttpClient client) : base(baseUrl, client)
        {
        }

        private int GetBeerId()
        {
            var beerInfo = _apiHelper.GetBeerInfo();
            return beerInfo.First().Id;
        }
        
        private void CheckBeerPrice(int beerId, int price)
        {
            var beerInfo = _apiHelper.GetBeerInfo();
            var beer = beerInfo.First(x => x.Id == beerId);
            var currentPrice = beer.CurrentPrice;
            if (currentPrice != price)
                throw new Exception("Test nastavení ceny neprošel");
        }

        private void TestBeerPriceSetting(int beerId, int price)
        {
            _apiHelper.SetPrice(beerId, price);
            CheckBeerPrice(beerId, price);
        }

        public override void Test()
        {
            var beerId = GetBeerId();
            TestBeerPriceSetting(beerId, 5000);
            TestBeerPriceSetting(beerId, 4200);
        }
    }
}
