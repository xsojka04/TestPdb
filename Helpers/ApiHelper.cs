using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TestPdb.TestCases;
using TestPdb.TestModels;

namespace TestPdb.Helpers
{
    public class ApiHelper
    {
        private readonly string _baseUrl;
        private readonly HttpClient _client;

        public ApiHelper(string baseUrl, HttpClient client)
        {
            _baseUrl = baseUrl;
            _client = client;
        }

        public List<BeerInfoTestModel>  GetBeerInfo()
        {
            return new RequestHelper<List<BeerInfoTestModel>>(_client, _baseUrl, "beer-info").GetData();
        }

        public List<BeerRecordsTestModel> GetPrices()
        {
            return new RequestHelper<List<BeerRecordsTestModel>>(_client, _baseUrl, "prices").GetData();
        }

        public void SetPrice(int beerId, int price)
        {
            new RequestHelper<object>(_client, _baseUrl, $"beer/{beerId}/set-price").PostData(price, "price");
        }

        public void SetAvailable(int beerId, bool available)
        {
            new RequestHelper<object>(_client, _baseUrl, $"beer/{beerId}/set-available").PutData(available ? 1 : 0, "available");
        }

        public SeatInfoTestModel GetSeatInfo(string name)
        {
            return new RequestHelper<SeatInfoTestModel>(_client, _baseUrl, $"seat-info/{name}").GetData();
        }

        public BeerBuyTestModel PostBeerBuy(int seatId, int beerId)
        {
            return new RequestHelper<BeerBuyTestModel>(_client, _baseUrl, $"seat/{seatId}/buy/{beerId}").PostData();
        }

        public CheckoutTestModel GetCheckout(int seatId)
        {
            return new RequestHelper<CheckoutTestModel>(_client, _baseUrl, $"seat/{seatId}/checkout").PutData();
        }
    }
}
