using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmers_market_api.Enums;
using farmers_market_api.Exceptions;
using farmers_market_api.Models;

namespace farmers_market_api.Repositories
{
    public class ProduceRepository
    {
        private readonly List<ProduceListing> produceListings = new List<ProduceListing>()
        {
            new (1, 1, "Tomatoes", Category.Vegetables, 2.5, 100, true, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-3), "Fresh and juicy tomatoes."),
            new (2, 2, "Strawberries", Category.Fruits, 4.0, 50, true, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-4), "Sweet and ripe strawberries."),
            new (3, 3, "Carrots", Category.Vegetables, 1.8, 200, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-6), "Crunchy and fresh carrots."),
            new (4, 1, "Apples", Category.Fruits, 3.2, 150, true, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1), "Crisp and delicious apples."),
            new (5, 2, "Lettuce", Category.Vegetables, 1.5, 80, true, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), "Fresh green lettuce leaves."),
            new (6, 3, "Potatoes", Category.Vegetables, 1.0, 300, true, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-5), "Organic potatoes, perfect for baking."),
            new (7, 1, "Oranges", Category.Fruits, 2.8, 120, true, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3), "Juicy oranges rich in vitamin C."),
            new (8, 2, "Broccoli", Category.Vegetables, 2.2, 90, true, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-2), "Nutritious broccoli florets."),
            new (9, 3, "Bananas", Category.Fruits, 1.9, 200, true, DateTime.Now.AddDays(-9), DateTime.Now.AddDays(-6), "Ripe bananas, great for smoothies."),
            new (10, 1, "Spinach", Category.Vegetables, 2.0, 60, true, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-0.5), "Tender spinach leaves."),
            new (11, 2, "Grapes", Category.Fruits, 3.5, 75, true, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-2), "Sweet seedless grapes."),
            new (12, 3, "Onions", Category.Vegetables, 1.2, 180, true, DateTime.Now.AddDays(-12), DateTime.Now.AddDays(-8), "Yellow onions, perfect for cooking."),
            new (13, 1, "Lemons", Category.Fruits, 2.0, 100, true, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-3), "Fresh lemons for cooking and drinks."),
            new (14, 2, "Peppers", Category.Vegetables, 2.8, 70, true, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1), "Colorful bell peppers."),
            new (15, 3, "Basil", Category.Herbs, 3.0, 40, true, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), "Fresh basil leaves."),
            new (16, 1, "Cucumbers", Category.Vegetables, 1.5, 120, true, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-4), "Crisp cucumbers."),
            new (17, 2, "Peaches", Category.Fruits, 3.8, 60, true, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-5), "Juicy summer peaches."),
            new (18, 3, "Garlic", Category.Vegetables, 1.8, 90, true, DateTime.Now.AddDays(-15), DateTime.Now.AddDays(-10), "Fresh garlic bulbs."),
            new (19, 1, "Pears", Category.Fruits, 2.9, 85, true, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-4), "Sweet and juicy pears."),
            new (20, 2, "Zucchini", Category.Vegetables, 2.1, 110, true, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-2), "Fresh zucchini squash."),
            new (21, 3, "Mint", Category.Herbs, 2.5, 35, true, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1), "Aromatic mint leaves."),
            new (22, 1, "Cherries", Category.Fruits, 5.0, 45, true, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3), "Sweet dark cherries."),
            new (23, 2, "Eggplant", Category.Vegetables, 2.4, 65, true, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-3), "Purple eggplants."),
            new (24, 3, "Rosemary", Category.Herbs, 3.2, 30, true, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-2), "Fragrant rosemary sprigs."),
            new (25, 1, "Blueberries", Category.Fruits, 4.5, 55, true, DateTime.Now.AddDays(-9), DateTime.Now.AddDays(-6), "Antioxidant-rich blueberries."),
            new (26, 2, "Cauliflower", Category.Vegetables, 2.3, 75, true, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-4), "White cauliflower heads."),
            new (27, 3, "Thyme", Category.Herbs, 2.8, 45, true, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-3), "Versatile thyme herb."),
            new (28, 1, "Raspberries", Category.Fruits, 4.2, 50, true, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-5), "Tart raspberries."),
            new (29, 2, "Cabbage", Category.Vegetables, 1.7, 95, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-7), "Green cabbage heads."),
            new (30, 3, "Oregano", Category.Herbs, 2.9, 40, true, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-4), "Italian oregano."),
            new (31, 1, "Mangoes", Category.Fruits, 3.9, 40, true, DateTime.Now.AddDays(-11), DateTime.Now.AddDays(-8), "Tropical mangoes."),
            new (32, 2, "Kale", Category.Vegetables, 2.6, 55, true, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1), "Nutrient-dense kale."),
            new (33, 3, "Parsley", Category.Herbs, 2.4, 50, true, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-2), "Fresh parsley bunches."),
            new (34, 1, "Pineapples", Category.Fruits, 4.8, 35, true, DateTime.Now.AddDays(-12), DateTime.Now.AddDays(-9), "Sweet pineapples."),
            new (35, 2, "Brussels Sprouts", Category.Vegetables, 2.7, 80, true, DateTime.Now.AddDays(-9), DateTime.Now.AddDays(-6), "Mini cabbage sprouts."),
            new (36, 3, "Cilantro", Category.Herbs, 2.3, 55, true, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), "Fresh cilantro."),
            new (37, 1, "Kiwis", Category.Fruits, 3.1, 70, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-7), "Fuzzy kiwis."),
            new (38, 2, "Asparagus", Category.Vegetables, 4.0, 45, true, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-3), "Tender asparagus spears."),
            new (39, 3, "Dill", Category.Herbs, 2.7, 35, true, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1), "Aromatic dill weed."),
            new (40, 1, "Watermelons", Category.Fruits, 6.0, 25, true, DateTime.Now.AddDays(-14), DateTime.Now.AddDays(-11), "Large watermelons."),
            new (41, 2, "Green Beans", Category.Vegetables, 2.5, 100, true, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-4), "Fresh green beans."),
            new (42, 3, "Sage", Category.Herbs, 3.1, 30, true, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-5), "Earthy sage leaves."),
            new (43, 1, "Cantaloupes", Category.Fruits, 4.2, 30, true, DateTime.Now.AddDays(-13), DateTime.Now.AddDays(-10), "Sweet cantaloupes."),
            new (44, 2, "Peas", Category.Vegetables, 2.9, 85, true, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-2), "Fresh green peas."),
            new (45, 3, "Tarragon", Category.Herbs, 3.5, 25, true, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), "French tarragon."),
            new (46, 1, "Grapefruits", Category.Fruits, 2.6, 60, true, DateTime.Now.AddDays(-9), DateTime.Now.AddDays(-6), "Tangy grapefruits."),
            new (47, 2, "Corn", Category.Vegetables, 1.8, 150, true, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-4), "Sweet corn on the cob."),
            new (48, 3, "Chicken Eggs", Category.Eggs, 3.5, 120, true, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), "Free-range chicken eggs."),
            new (49, 1, "Milk", Category.Dairy, 2.2, 50, true, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-0.5), "Fresh whole milk."),
            new (50, 2, "Honey", Category.Other, 5.5, 40, true, DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-15), "Pure local honey.")
        };

        public List<ProduceListing> GetAllProduce()
        {
            return produceListings;
        }

        public ProduceListing AddProduce(ProduceListing produce)
        {
            if (string.IsNullOrEmpty(produce.ProduceName)){throw new InvalidProduceFormatException("Produce listing cannot be null or empty.");}
            if (produce.PricePerKg <= 0) { throw new InvalidProduceFormatException("Price per kg must be greater than zero."); }
            if (produce.QuantityKg <= 0) { throw new InvalidProduceFormatException("Quantity in kg cannot be negative."); }

            int newId = produceListings.Count > 0 ? produceListings.Max(p => p.ListingId) + 1 : 1;
            produce.ListingId = newId;
            produceListings.Add(produce);
            return produce;
        }

        public ProduceListing? GetProduceById(int id)
        {
            for (int i = 0; i < produceListings.Count; i++)
            {
                if (produceListings[i].ListingId == id)
                {
                    return produceListings[i];
                }
                else if (i == produceListings.Count - 1)
                {
                    throw new ListingNotFoundException($"Produce listing with ID {id} not found.");
                }
            }
            return null;
        }

        public List<ProduceListing> GetProduceByCategory(Category category)
        {
            return produceListings.Where(p => p.Category == category).ToList();
        }

        public List<ProduceListing> GetAvailableProduce()
        {
            return produceListings.Where(p => p.IsAvailable).ToList();
        }

        
    }
}