using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmers_market_api.Enums;
using farmers_market_api.Models;
using farmers_market_api.Repositories;
using farmers_market_api.Structs;
using Microsoft.AspNetCore.Mvc;
using farmers_market_api.Exceptions;

namespace farmers_market_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProduceController : ControllerBase
    {
        private readonly ProduceRepository _produceRepository = new ProduceRepository();

        [HttpGet]
        public IActionResult GetListOfProduce()
        {
            return Ok(_produceRepository.GetAllProduce());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduceById(int id)
        {       
            try
            {
                var produce = _produceRepository.GetProduceById(id);
                return Ok(produce);
            }
            catch (ListingNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/summary")]
        public IActionResult GetProduceSummary(int id)
        {
            var produce = _produceRepository.GetProduceById(id);

            if (produce == null) return NotFound();

            return Ok(produce.GetFormattedSummary());
        }

        [HttpGet("{id}/revenue")]
        public IActionResult GetPotentialRevenue(int id)
        {
            var produce = _produceRepository.GetProduceById(id);

            if (produce == null) return NotFound();

            return Ok(produce.CalculatePotentialRevenue());
        }

        [HttpGet("/available")]
        public IActionResult GetAvailableProduce()
        {
            return Ok(_produceRepository.GetAvailableProduce());

        }

        [HttpGet("category/{category}")]
        public IActionResult GetProduceByCategory([FromRoute] Category category)
        {
            return Ok(_produceRepository.GetProduceByCategory(category));

        }

        [HttpPost]
        public IActionResult CreateProduceListing([FromBody] CreateProduceDTO listing)
        {
            if (listing.PricePerKg <= 0 || listing.ProduceName.Length <= 0)
            {
                return BadRequest("Price per kg and name must be greater than zero.");
            }

            try
            {
                var newListing = new ProduceListing
                {
                    FarmerId = listing.FarmerId,
                    ProduceName = listing.ProduceName,
                    Category = listing.Category,
                    PricePerKg = listing.PricePerKg,
                    QuantityKg = listing.QuantityKg,
                    IsAvailable = listing.IsAvailable,
                    HarvestDate = listing.HarvestDate,
                    DateListed = listing.DateListed,
                    Description = listing.Description
                };

                _produceRepository.AddProduce(newListing);
                return Created($"localhost:5005/api/produce/{newListing.ListingId}", newListing);
            }
            catch (InvalidProduceFormatException ex)
            {
                return BadRequest(ex.Message);
            }
             catch (Exception ex)
            {
                return BadRequest(ex.Message);
             }

        }
    }
}