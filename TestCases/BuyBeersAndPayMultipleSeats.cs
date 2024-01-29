using System;
using System.Linq;
using System.Net.Http;
using TestPdb.TestModels;

namespace TestPdb.TestCases
{
    internal class BuyBeersAndPayMultipleSeats : CaseBase
    {
        public BuyBeersAndPayMultipleSeats(string baseUrl, HttpClient client) : base(baseUrl, client)
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

        private int[] OrderringOrder(int repeatCount, int seatCount)
        {
            var orderingOrder = new int[repeatCount * seatCount];
            for (int i = 0; i < seatCount; i++)
            {
                int offset = i * repeatCount;
                for (int j = 0; j < repeatCount; j++)
                {
                    orderingOrder[offset + j] = i;
                }
            }
            return orderingOrder.OrderBy(x => new Random().Next()).ToArray();
        }

        private int[] SeatIds(string[] seatNames)
        {
            var seatIds = new int[seatNames.Count()];
            for (int i = 0; i < seatNames.Count(); i++)
            {
                seatIds[i] = _apiHelper.GetSeatInfo(seatNames[i]).Id;
            }
            return seatIds;
        }

        private int[] TotalPrices(string[] seatNames)
        {
            var totalPrices = new int[seatNames.Count()];
            for (int i = 0; i < seatNames.Count(); i++)
            {
                totalPrices[i] = 0;
            }
            return totalPrices;
        }

        private void CheckoutAll(int[] seatIds)
        {
            for (int i = 0; i < seatIds.Count(); i++)
                _apiHelper.GetCheckout(seatIds[i]);
        }

        public override void Test()
        {
            string[] seatNames = { "table1-seat1", "table1-seat2", "table2-seat1" };
            int repeatCount = 10;
            var seatIds = SeatIds(seatNames);
            var totalPrices = TotalPrices(seatNames);
            var orderingOrder = OrderringOrder(repeatCount, seatNames.Count());

            CheckoutAll(seatIds);
            
            foreach (var id in orderingOrder)
            {
                totalPrices[id] += BuyBeer(seatIds[id]);
            }

            for (int i = 0; i < seatIds.Count(); i++)
            {
                var checkout = _apiHelper.GetCheckout(seatIds[i]);

                if (totalPrices[i] != checkout.Total)
                    throw new Exception("Nesedí cena nákupu a cena piv");
            }
        }
    }
}
