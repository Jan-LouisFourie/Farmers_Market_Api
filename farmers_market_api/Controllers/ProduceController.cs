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
            new (3, 3, "Carrots", "Vegetables", 1.8, 200, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-6), "Crunchy and fresh carrots."),
            new (4, 1, "Apples", "Fruits", 3.2, 150, true, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1), "Crisp and delicious apples."),
            new (5, 2, "Lettuce", "Vegetables", 1.5, 80, true, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), "Fresh green lettuce leaves."),
            new (6, 3, "Potatoes", "Vegetables", 1.0, 300, true, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-5), "Organic potatoes, perfect for baking."),
            new (7, 1, "Oranges", "Fruits", 2.8, 120, true, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3), "Juicy oranges rich in vitamin C."),
            new (8, 2, "Broccoli", "Vegetables", 2.2, 90, true, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-2), "Nutritious broccoli florets."),
            new (9, 3, "Bananas", "Fruits", 1.9, 200, true, DateTime.Now.AddDays(-9), DateTime.Now.AddDays(-6), "Ripe bananas, great for smoothies."),
            new (10, 1, "Spinach", "Vegetables", 2.0, 60, true, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-0.5), "Tender spinach leaves.")
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

            return Ok(produce);
        }

        [HttpGet("{id}/summary")]
        public IActionResult GetProduceSummary(int id)
        {
            var produce = produceListings.FirstOrDefault(p => p.ListingId == id);

            if (produce == null) return NotFound();

            return Ok(produce.GetFormattedSummary());
        }

        [HttpGet("{id}/revenue")]
        public IActionResult GetPotentialRevenue(int id)
        {
            var produce = produceListings.FirstOrDefault(p => p.ListingId == id);

            if (produce == null) return NotFound();

            return Ok(produce.CalculatePotentialRevenue());
        }

        [HttpGet("/available")]
        public IActionResult GetAvailableProduce([FromQuery] string name)
        {
            List<ProduceListing> availableProduce = new List<ProduceListing>();
            for (int i = 0; i < produceListings.Count; i++)
            {
                if (produceListings[i].IsAvailable)
                {
                    availableProduce.Add(produceListings[i]);
                }
            }
            return Ok(availableProduce);

        }

        [HttpGet("category/{category}")]
        public IActionResult GetProduceByCategory([FromRoute] string category)
        {
            return Ok(produceListings.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList());

        }

        [HttpPost]
        public IActionResult CreateProduceListing([FromBody] ProduceListing listing)
        {
            produceListings.Add(listing);
            return Created($"localhost:5005/api/produce/{listing.ListingId}", produceListings);
        }
    }
}