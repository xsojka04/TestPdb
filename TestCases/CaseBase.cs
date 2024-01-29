using System.Net.Http;
using TestPdb.Helpers;

namespace TestPdb.TestCases
{
    abstract class CaseBase : ICase
    {
        protected string _baseUrl;
        protected HttpClient _client;
        protected ApiHelper _apiHelper;

        public CaseBase(string baseUrl, HttpClient client)
        {
            _baseUrl = baseUrl;
            _client = client;
            _apiHelper = new ApiHelper(_baseUrl, _client);
        }

        public abstract void Test();
    }
}
