using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmers_market_api.Exceptions
{
    public class ListingNotFoundException : Exception
    {
        public ListingNotFoundException(string? message) : base(message)
        {
        }
    }
}