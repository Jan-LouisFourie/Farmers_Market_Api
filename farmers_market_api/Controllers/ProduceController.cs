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
    public class ProduceController : ControllerBase
    {
        private readonly List<ProduceListing> produceListings = new List<ProduceListing>()
        {
            new (1, 1, "Tomatoes", "Vegetables", 2.5, 100, true, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-3), "Fresh and juicy tomatoes."),
            new (2, 2, "Strawberries", "Fruits", 4.0, 50, true, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-4), "Sweet and ripe strawberries."),
            new (3, 3, "Carrots", "Vegetables", 1.8, 200, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-6), "Crunchy and fresh carrots.")
        };

        [HttpGet]
        public IActionResult GetListOfProduce()
        {
            return Ok(produceListings);
        }

        [HttpGet("{id}")]
        public IActionResult GetFormattedSummary(int id)
        {
            var produce = produceListings.FirstOrDefault(p => p.ListingId == id);
            
            if (produce == null) return NotFound();

            return Ok(produce.GetFormattedSummary());
        }
    }
}