using System;
using System.Collections.Generic;
using System.Text;

namespace TestPdb.TestModels
{
    public class BeerInfoTestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brewery { get; set; }
        public int Volume { get; set; }
        public bool Available { get; set; }
        public int CurrentPrice { get; set; }
    }
}
