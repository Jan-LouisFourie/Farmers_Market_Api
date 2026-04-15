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
        private readonly List<Farmer> farmers = new List<Farmer>
        {
            new Farmer("John Doe", "john.doe@example.com", "123-456-7890", "123 Main St", "Ontario", 4.5, true),
            new Farmer("Jane Smith", "jane.smith@example.com", "098-765-4321", "456 Oak Ave", "Quebec", 4.0, false),
            new Farmer("Bob Johnson", "bob.johnson@example.com", "555-555-5555", "789 Pine Rd", "British Columbia", 4.8, true)
        };

        [HttpGet]
        public List<Farmer> GetListOfFarmers()
        {
            return farmers;
        }

        [HttpPost]
        public List<Farmer> createfarmer([FromBody]Farmer farmer)
        {
            farmers.Add(farmer);
            return farmers;
        }

        [HttpDelete]
        public List<Farmer> Delete([FromQuery] int farmerId)
        {
            var farmer = farmers.FirstOrDefault(f => f.FarmerId == farmerId);
            if (farmer != null)
            {
                farmers.Remove(farmer);
                return farmers;
            }
            else
            {
                return farmers;
            }
        }

        [HttpPut]
        public Farmer UpdateFarmer([FromBody] Farmer updatedFarmer)
        {
            var farmer = farmers.FirstOrDefault(f => f.getFarmerId() == updatedFarmer.getFarmerId());
            if (farmer != null)
            {
                farmer = updatedFarmer;
                return farmer;
            }
            else
            {
                return null;
            }

        }
    }
}