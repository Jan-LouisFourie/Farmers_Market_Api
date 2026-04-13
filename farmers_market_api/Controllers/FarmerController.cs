using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace farmers_market_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmerController : ControllerBase
    {
        private List<string> farmers = new List<string>{ "Kobus", "Ben", "Jacob"};

        [HttpGet]
        public List<string> GetListOfFarmers()
        {
            return farmers;
        }

        [HttpPost]
        public List<string> createfarmer([FromBody]string name)
        {
            farmers.Add(name);
            return farmers;
        }
    }
}