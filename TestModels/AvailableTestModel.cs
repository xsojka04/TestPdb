using Newtonsoft.Json;

namespace TestPdb.TestModels
{
    public class AvailableTestModel
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        public AvailableTestModel(int available)
        {
            Available = available;
        }
    }
}
