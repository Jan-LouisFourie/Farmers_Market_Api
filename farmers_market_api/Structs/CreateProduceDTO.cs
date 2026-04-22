using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmers_market_api.Enums;

namespace farmers_market_api.Structs
{
    public readonly struct CreateProduceDTO
    {
        public readonly int FarmerId;
        public readonly string ProduceName;
        public readonly Category Category;
        public readonly double PricePerKg;
        public readonly double QuantityKg;
        public readonly bool IsAvailable;
        public readonly DateTime HarvestDate;
        public readonly DateTime DateListed;
        public readonly string? Description;

        public CreateProduceDTO(int farmerId, string produceName, Category category, double pricePerKg, double quantityKg, bool isAvailable, DateTime harvestDate, DateTime dateListed, string? description)
        {
            FarmerId = farmerId;
            ProduceName = produceName;
            Category = category;
            PricePerKg = pricePerKg;
            QuantityKg = quantityKg;
            IsAvailable = isAvailable;
            HarvestDate = harvestDate;
            DateListed = dateListed;
            Description = description;
        }
    }
}