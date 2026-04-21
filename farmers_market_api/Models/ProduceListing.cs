using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmers_market_api.Enums;

namespace farmers_market_api.Models
{
    public class ProduceListing
    {
        public int ListingId { get; set; }
        public int FarmerId { get; set; }
        public string ProduceName { get; set; } = string.Empty;
        public Category Category { get; set; } = Category.Other;
        public double PricePerKg { get; set; } = 0.0;
        public double QuantityKg { get; set; } = 0.0;
        public bool IsAvailable { get; set; } = true;
        public DateTime HarvestDate { get; set; } = DateTime.Now;
        public DateTime DateListed { get; set; } = DateTime.Now;
        public string? Description { get; set; } = string.Empty;

        public ProduceListing(int listingId, int farmerId, string produceName, Category category, double pricePerKg, double quantityKg, bool isAvailable, DateTime harvestDate, DateTime dateListed, string? description)
        {
            ListingId = listingId;
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

        public ProduceListing()
        {
        }

        public string GetFormattedSummary()
        {
            return $"""
            Produce: {ProduceName}
            Category: {Category}
            Price: {PricePerKg}/kg
            Quantity: {QuantityKg} kg available
            Description: {Description ?? "No description provided."}
            """;
        }

        public double CalculatePotentialRevenue()
        {
            return PricePerKg * QuantityKg;
        }
    }
}