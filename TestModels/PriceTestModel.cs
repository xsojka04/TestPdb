using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestPdb.TestModels
{
    public class PriceTestModel
    {
        [JsonProperty("price")]
        public int Price { get; set; }

        public PriceTestModel(int price)
        {
            Price = price;
        }
    }
}
