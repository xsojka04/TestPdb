using System;
using System.Linq;
using System.Net.Http;
using TestPdb.TestModels;

namespace TestPdb.TestCases
{
    internal class BuyBeerAndPay : CaseBase
    {
        public BuyBeerAndPay(string baseUrl, HttpClient client) : base(baseUrl, client)
        {
        }

        private BeerInfoTestModel ChooseBeer()
        {
            var list = _apiHelper.GetBeerInfo();
            return list[new Random().Next(list.Count)];
        }

        private BeerInfoTestModel GetBeer(int id)
        {
            return _apiHelper.GetBeerInfo().First(x => x.Id == id);
        }

        public override void Test()
        {
            var place = "table1-seat1";
            var seatInfo = _apiHelper.GetSeatInfo(place);
            _apiHelper.GetCheckout(seatInfo.Id);
            var beer = ChooseBeer();
            var beerBuy = _apiHelper.PostBeerBuy(seatInfo.Id, beer.Id);
            var checkout = _apiHelper.GetCheckout(seatInfo.Id);
            var updatedBeer = GetBeer(beer.Id);

            if (beer.CurrentPrice >= updatedBeer.CurrentPrice)
                throw new Exception("Pivo po nákupu nezdražilo");
            if (beerBuy.Total != checkout.Total)
                throw new Exception("Nesedí cena nákupu a platby");
            if (beer.CurrentPrice != beerBuy.Price)
                throw new Exception("Nesedí cena piva a nákupu");
        }
    }
}
