using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantRater116.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}