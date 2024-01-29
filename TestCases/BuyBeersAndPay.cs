using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using TestPdb.TestModels;

namespace TestPdb.TestCases
{
    internal class BuyBeersAndPay : CaseBase
    {
        public BuyBeersAndPay(string baseUrl, HttpClient client) : base(baseUrl, client)
        {
        }

        private BeerInfoTestModel ChooseRandomBeer()
        {
            var list = _apiHelper.GetBeerInfo();
            return list[new Random().Next(list.Count)];
        }

        private int BuyBeer(int seatId)
        {
            var beer = ChooseRandomBeer();
            var beerBuy = _apiHelper.PostBeerBuy(seatId, beer.Id);
            return beer.CurrentPrice;
        }

        public override void Test()
        {
            int totalPrice = 0;
            var place = "table1-seat1";
            var seatInfo = _apiHelper.GetSeatInfo(place);
            _apiHelper.GetCheckout(seatInfo.Id);
            int repeat = 10;
            for (int i = 0; i < repeat; i++)
                totalPrice += BuyBeer(seatInfo.Id);
            var checkout = _apiHelper.GetCheckout(seatInfo.Id);

            if (totalPrice != checkout.Total)
                throw new Exception("Nesedí cena nákupu a cena piv");
        }
    }
}
