using System.Collections.Generic;

namespace TestPdb.TestModels
{
    public class BeerRecordsTestModel
    {
        public int Id { get; set; }
        public List<RecordTestModel> Records { get; set; }
    }
}
