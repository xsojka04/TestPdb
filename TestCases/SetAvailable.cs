using System;
using System.Linq;
using System.Net.Http;

namespace TestPdb.TestCases
{
    internal class SetAvailable : CaseBase
    {
        public SetAvailable(string baseUrl, HttpClient client) : base(baseUrl, client)
        {
        }

        private int GetBeerId()
        {
            var beerInfo = _apiHelper.GetBeerInfo();
            return beerInfo.First().Id;
        }
        
        private void CheckBeerAvailable(int beerId, bool available)
        {
            var beerInfo = _apiHelper.GetBeerInfo();
            var beer = beerInfo.FirstOrDefault(x => x.Id == beerId);
            if (beer is null && !available)
                return;
            else if (beer != null)
            {
                var currentAvailable = beer.Available;
                if (currentAvailable != available)
                    throw new Exception("Test nastavení dostupnosti neprošel");
            }
            else
                throw new Exception("Test nastavení dostupnosti neprošel");
        }

        private void TestBeerAvailableSetting(int beerId, bool available)
        {
            _apiHelper.SetAvailable(beerId, available);
            CheckBeerAvailable(beerId, available);
        }

        public override void Test()
        {
            var beerId = GetBeerId();
            TestBeerAvailableSetting(beerId, true);
            TestBeerAvailableSetting(beerId, false);
            TestBeerAvailableSetting(beerId, true);
            TestBeerAvailableSetting(beerId, false);
            TestBeerAvailableSetting(beerId, true);
        }
    }
}
