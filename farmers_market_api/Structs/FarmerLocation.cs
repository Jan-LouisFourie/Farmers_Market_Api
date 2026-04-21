using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmers_market_api.Enums;

namespace farmers_market_api.Structs
{
    public struct FarmerLocation
    {
        public string FarmName;
        public Provinces Province;
        public string Town;
    }

    public FarmerLocation(string farmName, Provinces province, string town)
    {
        FarmName = farmName;
        Province = province;
        Town = town;
    }
}