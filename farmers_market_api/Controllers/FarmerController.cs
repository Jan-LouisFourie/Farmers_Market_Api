using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmers_market_api.Models;
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

        [HttpDelete]
        public List<string> DeleteFarmer([FromQuery] string name)
        {
            if (!farmers.Contains(name))
            {
                farmers.Remove(name);
                return farmers;
            }
            else
            {
                return farmers;
            }
        }

        [HttpPut]
        public List<string> UpdateFarmer([FromBody] UpdateRequest request)
        {
            if (farmers.Contains(request.OldName))
            {
                int index = farmers.IndexOf(request.OldName);
                
                if(index != -1)
                {
                    farmers[index] = request.NewName;
                }
                return farmers;
            }
            else
            {
                return farmers;
            }
        }
    }
}